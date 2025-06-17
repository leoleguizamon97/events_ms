using Dapper;
using NetApiPostgreSQL.Models;
using Npgsql;

namespace NetApiPostgreSQL.Repositories
{
    public class Eventos : EventosInterface
    {
        private PostgresSQL _connectionString;

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        public Eventos(PostgresSQL connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<bool> DeleteEvento(int id)
        {
            var db = dbConnection();
            var sql = @"UPDATE ""Event""
                        SET deleted_at = now()
                        WHERE id = @Id";
            var result = await db.ExecuteAsync(sql, new { Id = id });
            return result > 0;
        }

        public async Task<IEnumerable<Models.Evento>> GetAll()
        {
            var db = dbConnection();
            var sql = @"SELECT * FROM ""Event""";
            return await db.QueryAsync<Evento>(sql, new { });
        }

        public async Task<Models.Evento> GetEvento(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT * FROM ""Event"" WHERE id = @id";
            return await db.QueryFirstOrDefaultAsync<Evento>(sql, new { id });
        }

        public async Task<bool> InsertEvento(Evento evento)
        {
            var db = dbConnection();
            var sql = @"
        INSERT INTO ""Event"" (
            title, description, place, starts_at, ends_at,
            capacity, user_creator_id, group_creator_id, created_at, updated_at
        ) VALUES (
            @Title, @Description, @Place, @Starts_At, @Ends_At,
            @Capacity, @User_Creator_Id, @Group_Creator_Id, now(), now()
        )";

            var result = await db.ExecuteAsync(sql, evento);
            return result > 0;
        }

        public async Task<bool> UpdateEvento(Evento evento)
        {
            var db = dbConnection();
            var sql = @"UPDATE ""Event"" SET
                            title = @Title,
                            description = @Description,
                            place = @Place,
                            starts_at = @Starts_At,
                            ends_at = @Ends_At,
                            capacity = @Capacity,
                            user_creator_id = @User_Creator_Id,
                            group_creator_id = @Group_Creator_Id,
                            updated_at = now()
                        WHERE id = @Id";

            var result = await db.ExecuteAsync(sql, evento);
            return result > 0;
        }
    }
}

namespace NetApiPostgreSQL
{
    public class PostgresSQL
    {
        public PostgresSQL(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public string ConnectionString {  get; set; }

    }
}

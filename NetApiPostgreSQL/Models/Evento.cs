

using System.ComponentModel.DataAnnotations;
using NpgsqlTypes;

namespace NetApiPostgreSQL.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Place { get; set; }
        //public NpgsqlPoint Coordinates { get; set; }
        public DateTime? Starts_at { get; set; }
        public DateTime? Ends_at { get; set; } 
        public required int Capacity { get; set; }
        public int User_creator_id { get; set; }
        public int? Group_creator_id { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public DateTime? Deleted_at { get; set; }
    }
}

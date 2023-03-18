using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Note
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}

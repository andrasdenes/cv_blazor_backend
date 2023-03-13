using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Job
    {
        public int JobId { get; set; }
        
        [Required]
        public string JobTitle { get; set; }
        
        [Required]
        public string CompanyName { get; set; }
        
        public string CompanyUrl { get; set;}
        
        public string Image { get; set; }
        
        [Required]
        public string ImageAlt { get; set; }
        
        [Required]
        public string From { get; set; }
        
        public string To { get; set; }
        
        [Required]
        public string Description { get; set; }
    }
}

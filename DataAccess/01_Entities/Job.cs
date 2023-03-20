namespace DataAccess.Entities
{
    public class Job
    {
        public Guid id { get; set; }
        public List<string> TechStack { get; set; }
        public List<string> Achievements { get; set; }
        public string JobTitle { get; set; }
        public string Description { get; set; }
        public Uri Image { get; set; }
        public string ImageAlt { get; set; }
        public Uri CompanyUrl { get; set; }
        public string CompanyName { get; set;}
        public string From { get; set; }
        public string To { get; set; }
    }
}

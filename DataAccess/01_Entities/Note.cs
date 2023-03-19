namespace DataAccess.Entities
{
    public class Note
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}

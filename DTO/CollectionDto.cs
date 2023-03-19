namespace DTO
{
    public class CollectionDto<T>
    {
        public List<T>? Collection { get; set; } = new List<T> { };
    }
}

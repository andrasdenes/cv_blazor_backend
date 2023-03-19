namespace DataAccess.HandlerInterfaces
{
    public interface IHandler
    {
        public object CreateSingle(string title, string description);
        public object GetAll();
        public object GetSingle(Guid id);
    }
}
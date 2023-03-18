using DataAccess.Entities;

namespace DataAccess.Handlers
{
    public interface IHandler
    {
        public object CreateSingleNote(string title, string description);
    }
}
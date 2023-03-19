using DataAccess.Entities;

namespace DataAccess.HandlerInterfaces
{
    public interface INoteHandler : IHandler
    {
        public Note CreateSingle(string title, string description);
        public List<Note> GetAll();
        public Note GetSingle(Guid id);
    }
}

using DataAccess.Entities;
using DataAccess.HandlerInterfaces;

namespace DataAccess.HandlerImplementations
{
    public class NoteHandler : Handler, INoteHandler
    {
        private readonly NoteContext _ctx;
        public NoteHandler(NoteContext context)
        {
            _ctx = context;
        }

        public Note CreateSingle(string title, string description)
        {
            Note note = new Note()
            {
                Title = title,
                Description = description
            };
            _ctx.Notes?.Add(note);
            _ctx.SaveChanges();

            return note;
        }

        public Note GetSingle(Guid id)
        {
            Note note = _ctx.Notes.FirstOrDefault(x=>x.Id == id);
            return note;
        }

        public List<Note> GetAll()
        {
            var notes = _ctx.Notes?.ToList();
            return notes;
        }
    }
}

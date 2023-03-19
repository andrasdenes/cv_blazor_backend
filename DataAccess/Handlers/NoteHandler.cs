using DataAccess.Entities;

namespace DataAccess.Handlers
{
    public class NoteHandler : IHandler
    {
        private readonly NoteContext _ctx;
        public NoteHandler(NoteContext context)
        {
            _ctx = context;
        }

        public object CreateSingle(string title, string description)
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

        public object GetSingle(Guid id)
        {
            Note note = _ctx.Notes.FirstOrDefault(x=>x.Id == id);
            return note;
        }

        public object GetAll()
        {
            var notes = _ctx.Notes?.ToList();
            return notes;
        }
    }
}

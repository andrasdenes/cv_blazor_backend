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

        public object CreateSingleNote(string title, string description)
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
    }
}

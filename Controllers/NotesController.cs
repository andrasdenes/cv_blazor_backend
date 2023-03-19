using DataAccess;
using DataAccess.Entities;
using DataAccess.HandlerInterfaces;
using DataAccess.HandlerImplementations;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace CVBackend.Controllers
{
    [ApiController]
    [Route($"{ApiRouteController}")]
    public class NotesController : BaseController
    {
        public IHandler Handler { get; set; }
        public string ControllerName { get; set; }
        public NotesController(IHandlerFactory factory)
        {
            Handler = factory.Create(typeof(NoteHandler));
            ControllerName = "Notes"; 
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            var noteCollection = new CollectionDto<NoteDto>();
            var notes = Handler.GetAll();
            if(notes != null ) 
            {
                foreach (var note in notes as List<Note>)
                { 
                    NoteDto noteDto = new NoteDto();
                    noteDto.Title = note.Title;
                    noteDto.Description = note.Description;
                    noteDto.Link = BuildLink(note);
                    noteCollection.Collection.Add(noteDto);
                }
            }
            return Ok(noteCollection);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(Guid id)
        {
            Note note = Handler.GetSingle(id) as Note;
            var noteDto = new NoteDto();
            noteDto.Title = note.Title;
            noteDto.Description = note.Description;
            noteDto.Link = BuildLink(note);
            return Ok(noteDto);
        }

        private Uri BuildLink(Note note)
        {
            string uriString = $"{BaseUrl}/{ApiRoutePrefix}/{ControllerName}/{note.Id}";
            return new Uri(uriString);
        }
        //public HttpResponseMessage CreateSingleNote()
        //{
        //    Handler.CreateSingleNote("asd123_", "_asd321");
        //    return new HttpResponseMessage(statusCode: System.Net.HttpStatusCode.OK);

        //}
    }
}

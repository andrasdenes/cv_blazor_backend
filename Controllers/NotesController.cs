using DataAccess;
using DataAccess.Entities;
using DataAccess.HandlerImplementations;
using DataAccess.HandlerInterfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace CVBackend.Controllers
{
    [ApiController]
    [Route($"{ApiRouteController}")]
    public class NotesController : BaseController
    {
        public INoteHandler Handler { get; set; }
        public string ControllerName { get; set; }
        public NotesController(IHandlerFactory factory)
        {
            Handler = (INoteHandler)factory.Create(typeof(NoteHandler));
            ControllerName = "Notes"; 
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            var noteCollection = new CollectionDto<NoteDto>();
            var notes = Handler.GetAll();
            if(notes != null ) 
            {
                foreach (var note in notes)
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
            Note note = Handler.GetSingle(id);
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

        [HttpPost]
        public HttpResponseMessage CreateSingleNote()
        {
            Handler.CreateSingle("asd123_", "_asd321");
            return new HttpResponseMessage(statusCode: System.Net.HttpStatusCode.OK);

        }
    }
}

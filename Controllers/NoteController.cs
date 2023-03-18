using DataAccess;
using DataAccess.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace CVBackend.Controllers
{
    [ApiController]
    public class NoteController
    {
        public IHandler Handler { get; set; }
        public NoteController(IHandlerFactory factory)
        {
            Handler = factory.Create(typeof(NoteHandler));
        }

        [HttpGet]
        [Route("/api/notes/create")]
        public HttpResponseMessage CreateSingleNote()
        {
            Handler.CreateSingleNote("asd", "asd");
            return new HttpResponseMessage(statusCode: System.Net.HttpStatusCode.OK);

        }
    }
}

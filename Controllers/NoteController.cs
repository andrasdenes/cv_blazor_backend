using DataAccess;
using DataAccess.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace CVBackend.Controllers
{
    [ApiController]
    public class NoteController : BaseController
    {
        public IHandler Handler { get; set; }
        public NoteController(IHandlerFactory factory)
        {
            Handler = factory.Create(typeof(NoteHandler));
        }

        [HttpGet]
        [Route($"{ApiRoutePrefix}/create")]
        public HttpResponseMessage CreateSingleNote()
        {
            Handler.CreateSingleNote("asd123_", "_asd321");
            return new HttpResponseMessage(statusCode: System.Net.HttpStatusCode.OK);

        }
    }
}

using DataAccess;
using DataAccess.HandlerImplementations;
using DataAccess.HandlerInterfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace CVBackend.Controllers
{
    [ApiController]
    [Route($"{ApiRouteController}")]
    public class JobsController : BaseController
    {
        public IJobHandler Handler { get; set; }
        public readonly string ControllerName = "Jobs";
        public JobsController(IHandlerFactory factory)
        {
            Handler = (IJobHandler)factory.Create(typeof(JobHandler));
        }

        [HttpGet]
        public CollectionDto<JobDto> GetAll()
        {
            return Handler.GetAllJobs();
        }

        [HttpGet("{id}")]
        public JobDto Get(Guid Id)
        {
            return new JobDto();
        }

        [HttpGet("pdf")]
        public byte[] GeneratePdf()
        {
            var doc = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    page.Header()
                    .Text("Dénes András")
                    .SemiBold()
                    .FontSize(18)
                    .FontColor(Colors.BlueGrey.Darken1);
                });
            });
            return doc.GeneratePdf();
        }
    }
}

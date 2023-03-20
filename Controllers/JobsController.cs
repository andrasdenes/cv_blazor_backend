using DataAccess;
using DataAccess.HandlerImplementations;
using DataAccess.HandlerInterfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;

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
            return new CollectionDto<JobDto>();
        }

        [HttpGet("{id}")]
        public JobDto Get(Guid Id)
        {
            return new JobDto();
        }
    }
}

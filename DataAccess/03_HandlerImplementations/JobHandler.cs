using AutoMapper;
using DataAccess.HandlerInterfaces;
using DTO;

namespace DataAccess.HandlerImplementations
{
    public class JobHandler : Handler, IJobHandler
    {
        private readonly JobContext _ctx;
        private readonly IMapper _mapper;

        public JobHandler(JobContext context, IMapper mapper)
        {
            _ctx = context;
            _mapper = mapper;   
        }

        public CollectionDto<JobDto> GetAllJobs()
        {
            var jobsEntity = _ctx.Jobs.ToList();
            var jobsDto = _mapper.Map<CollectionDto<JobDto>>(jobsEntity);
            return jobsDto;
        }

        public JobDto GetJobById(Guid Id)
        {
            var jobEntity = _ctx.Jobs.FirstOrDefault(x => x.Id == Id);
            var jobDto = _mapper.Map<JobDto>(jobEntity);
            return jobDto;
        }
    }
}

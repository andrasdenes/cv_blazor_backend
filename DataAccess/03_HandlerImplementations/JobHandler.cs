using DataAccess.Entities;
using DataAccess.HandlerInterfaces;
using DTO;

namespace DataAccess.HandlerImplementations
{
    public class JobHandler : Handler, IJobHandler
    {
        private readonly JobContext _ctx;

        public JobHandler(JobContext context)
        {
            _ctx = context;  
        }

        public CollectionDto<JobDto> GetAllJobs()
        {
            var jobsEntity = _ctx.Jobs.ToList();
            var jobsDto = new CollectionDto<JobDto>();
            foreach (var job in jobsEntity)
            { 
                var jobDto = MapEntitiyToDto(job);
                jobsDto.Collection.Add(jobDto);
            }
            return jobsDto;
        }

        public JobDto GetJobById(Guid Id)
        {
            var jobEntity = _ctx.Jobs.FirstOrDefault(x => x.Id == Id);
            var jobDto = MapEntitiyToDto(jobEntity);
            return jobDto;
        }

        private JobDto MapEntitiyToDto(Job job)
        {
            JobDto jobDto = new JobDto();
            jobDto.JobTitle = job.JobTitle;
            jobDto.Achievements = job.Achievements;
            jobDto.CompanyName = job.CompanyName;
            jobDto.Description = job.Description;
            jobDto.CompanyUrl = job.CompanyUrl;
            jobDto.From = job.From;
            jobDto.To = job.To;
            jobDto.Image = job.Image;
            jobDto.ImageAlt = job.ImageAlt;
            jobDto.TechStack = job.TechStack;
            return jobDto;
        }
    }
}

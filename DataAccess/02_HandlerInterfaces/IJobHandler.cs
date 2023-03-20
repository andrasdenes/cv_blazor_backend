using DTO;

namespace DataAccess.HandlerInterfaces
{
    public interface IJobHandler : IHandler
    {
        public JobDto GetJobById(Guid Id);
        public CollectionDto<JobDto> GetAllJobs();
    }
}

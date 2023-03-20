using AutoMapper;
using DataAccess.Entities;
using DTO;

namespace DataAccess.MapperConfigurations
{
    public class EntityToDtoMapperConfiguration : Profile
    {
        public EntityToDtoMapperConfiguration() 
        {
            CreateMap<Job, JobDto>().ReverseMap();
        }
    }
}

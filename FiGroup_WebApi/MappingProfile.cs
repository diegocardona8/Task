using AutoMapper;
using FiGroup_WebApi.Dtos;
using FiGroup_WebApi.Models;

namespace FiGroup_WebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Task, TaskDto>();
        }
    }
}

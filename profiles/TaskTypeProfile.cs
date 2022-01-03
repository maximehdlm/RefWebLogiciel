using AutoMapper;
using RefWebLogiciel.Models;
using RefWebLogiciel.Dtos;


namespace RefWebLogiciel.profiles
{
    public class TypeOfTaskProfile : Profile
    {
        public TypeOfTaskProfile()
        {   
            
            CreateMap<ProjectTaskType, ProjectTaskTypeReadDto>();
            CreateMap<ProjectTaskTypeCreateDto, ProjectTaskType>();
        }

    }
}
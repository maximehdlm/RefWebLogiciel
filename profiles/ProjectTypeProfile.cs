using AutoMapper;
using RefWebLogiciel.Models;
using RefWebLogiciel.Dtos;

namespace RefWebLogiciel.Profiles
{
    public class ProjectTypeProfile : Profile 
    {
        //ici je configure le mapping entre mon model et mon dto
        public ProjectTypeProfile()
        {
            CreateMap<ProjectType, ProjectTypeReadDto>();
            CreateMap<ProjectTypeCreateDto, ProjectType>();
            CreateMap<ProjectTypeUpdateDto, ProjectType>();
        }
    }
}
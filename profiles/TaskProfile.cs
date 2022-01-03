using AutoMapper;
using RefWebLogiciel.Models;
using RefWebLogiciel.Dtos;

namespace RefWebLogiciel.profiles
{
    public class TaskProfile : Profile
    {
        
        public TaskProfile()
        {
            // Ici on lui donne une route ( source, destination )
            // Par exemple pour un get on lui dit de passer par l'entité Task et de poursuivre par le Dtos qui nous indique ce que nous devons lire ou pas.
            CreateMap<ProjectTask, ProjectTaskReadDto>();
            CreateMap<ProjectTaskCreateDto, ProjectTask>();
            CreateMap<ProjectTaskUpdateDto, ProjectTask>();
            CreateMap<ProjectTaskStatusUpdateDto, ProjectTask>();
        }

        
    }
}
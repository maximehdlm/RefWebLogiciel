using AutoMapper;
using RefWebLogiciel.Models;
using RefWebLogiciel.Dtos;

namespace RefWebLogiciel.Profiles
{
    public class UserSpecializationProfile : Profile
    {
        public UserSpecializationProfile()
        {
            CreateMap<UserSpecialization, UserSpecializationReadDto>();
            CreateMap<UserSpecializationCreateDto, UserSpecialization>();
            CreateMap<UserSpecializationUpdateDto, UserSpecialization>();
        }
    }
}
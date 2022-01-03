using AutoMapper;
using RefWebLogiciel.Models;
using RefWebLogiciel.Dtos;

namespace RefWebLogiciel.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
        }
    }
}

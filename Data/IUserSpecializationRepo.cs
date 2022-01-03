using System.Collections.Generic;
using RefWebLogiciel.Models;

namespace RefWebLogiciel.Data
{
    public interface IUserSpecializationRepo
    {
        bool SaveChanges();
        IEnumerable<UserSpecialization> GetAllUserSpecializations();
        UserSpecialization GetUserSpecializationById(int id);
        void CreateUserSpecialization(UserSpecialization specialization);
        void UpdateUserSpecializationById(int id);
        void DeleteUserSpecializationById(int id);
    }
}
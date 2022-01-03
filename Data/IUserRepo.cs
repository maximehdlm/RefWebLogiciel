using System.Collections.Generic;
using RefWebLogiciel.Models;


namespace RefWebLogiciel.Data
{
    public interface IUserRepo
    {
        bool SaveChanges();
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void CreateUser(User user);
        void UpdateUserById(int id);
        void DeleteUserById(int id);
    }
}
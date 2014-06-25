using System.Collections.Generic;
using CodeFirstDemo.Infrastructure.Data.Entity;

namespace CodeFirstDemo.IService
{
    public interface IUserService
    {
        List<User> GetUsers();
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}

using System.Collections.Generic;
using System.Linq;
using CodeFirstDemo.Infrastructure.Data.Entity;
using CodeFirstDemo.IRepostory;
using CodeFirstDemo.IService;

namespace CodeFirstDemo.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRespostory _userRespostory;

        public UserService(IUserRespostory userRespostory)
        {
            _userRespostory = userRespostory;
        }

        public List<User> GetUsers()
        {
            var users = _userRespostory.GetAll().ToList();
            return users;
        }

        public void AddUser(User user)
        {
            _userRespostory.Add(user);
        }

        public void UpdateUser(User user)
        {
            _userRespostory.Update(user);
        }

        public void DeleteUser(int id)
        {
            _userRespostory.Delete(id);
        }
    }
}

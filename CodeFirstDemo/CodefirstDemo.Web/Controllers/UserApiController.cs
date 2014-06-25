using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Http;
using CodeFirstDemo.IService;
using ModelUser = CodeFirstDemo.Infrastructure.Data.Entity.User;
using User = CodefirstDemo.Web.Models.User;

namespace CodefirstDemo.Web.Controllers
{
    public class UserApiController : ApiController
    {
        private readonly IUserService _userService;

        public UserApiController(IUserService userService)
        {
            _userService = userService;
        }

        public IEnumerable<User> Get()
        {
            var users = _userService.GetUsers();

            return users.Select(x => new User
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Age = x.Age.ToString(CultureInfo.InvariantCulture),
                Email = x.Email,
                GroupName = ""
            }).ToList();
        }

        public void Post(User user)
        {
            var modelUser = new ModelUser
            {
                Age = int.Parse(user.Age),
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            _userService.AddUser(modelUser);
        }

        public void Put(User user)
        {
            var modelUser = new ModelUser
            {
                Id = user.Id,
                Age = int.Parse(user.Age),
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            _userService.UpdateUser(modelUser);
        }

        public void Delete(int id)
        {
            _userService.DeleteUser(id);
        }
    }
}

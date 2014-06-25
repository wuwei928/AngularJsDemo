using System.Web.Http;
using CodeFirstDemo.IRepostory;

namespace CodefirstDemo.Web.Controllers
{
    public class BaseApiController : ApiController
    {
         private readonly IUserRespostory _userRespostory;

         public BaseApiController(IUserRespostory userRespostory)
        {
            _userRespostory = userRespostory;
        }

         protected IUserRespostory UserRespostory
         {
             get
             {
                 return _userRespostory;
             }
         }
    }
}
using System;
using System.Linq;
using System.Linq.Expressions;
using CodeFirstDemo.Infrastructure.Data.Entity;
using CodeFirstDemo.IRepostory;

namespace CodeFirstDemo.Repostory
{
    public class UserRespostory : BaseRepository<User>, IUserRespostory
    {
        public UserRespostory(IDbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CodeFirstDemo.Infrastructure.Data.Entity;

namespace CodeFirstDemo.Infrastructure.Data.Initialize
{
    public class SampleData : CreateDatabaseIfNotExists<CodeFirstDBContext>
    {
        protected override void Seed(CodeFirstDBContext context)
        {
            var user = new User
            {
                Id = 1,
                FirstName = "wu",
                LastName = "wei",
                Age = 32,
                Email = "wuwei@126.com"
            };
            var group = new UserGroup
            {
                Id = 1,
                Name = "C# group"
            };
            context.User.Add(user);
            context.UserGroup.Add(group);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}

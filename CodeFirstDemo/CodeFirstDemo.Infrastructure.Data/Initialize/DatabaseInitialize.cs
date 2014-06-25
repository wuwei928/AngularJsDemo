using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo.Infrastructure.Data.Initialize
{
    public class DatabaseInitialize
    {
        public static void Initialize()
        {
            Database.SetInitializer(new SampleData());
            using (var demoContext = new CodeFirstDBContext())
            {
                demoContext.Database.Initialize(false);
            }
        }
    }
}

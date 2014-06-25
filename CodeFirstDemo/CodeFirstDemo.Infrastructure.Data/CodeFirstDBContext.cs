using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text.RegularExpressions;
using CodeFirstDemo.Infrastructure.Data.Entity;

namespace CodeFirstDemo.Infrastructure.Data
{
    public class CodeFirstDBContext : DbContext
    {
        public CodeFirstDBContext():base("default")
        {
            
        }
        public DbSet<User> User { get; set; }

        public DbSet<UserGroup> UserGroup { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}

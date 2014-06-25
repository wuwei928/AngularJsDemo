using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using CodeFirstDemo.Infrastructure.Data;

namespace CodeFirstDemo.Repostory
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        private readonly IDbContextProvider _dbContextProvider;
        protected CodeFirstDBContext Context
        {
            get
            {
                return _dbContextProvider.GetCodeFirstDBContext();
            }
        }

        public BaseRepository(IDbContextProvider dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }



        public void Add(TEntity t)
        {
            Context.Set<TEntity>().Add(t);
            SafeSaveChanges();
        }

        public void Update(TEntity t)
        {
            var entry = Context.Entry(t);
            Context.Set<TEntity>().Attach(t);
            entry.State = EntityState.Modified;
            SafeSaveChanges();
        }

        public void Delete(int id)
        {
            var entity = Get(id);
            Context.Set<TEntity>().Remove(entity);
            SafeSaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>();
        }

        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public void SafeSaveChanges()
        {
            foreach (var error in Context.GetValidationErrors())
            {
                var entityType = error.Entry.Entity.GetType().BaseType;

                foreach (var validationError in error.ValidationErrors)
                {
                    var property = entityType.GetProperty(validationError.PropertyName);
                    if (property.GetCustomAttributes(typeof(RequiredAttribute), true).Any())
                    {
                        property.GetValue(error.Entry.Entity, null);
                    }
                }
            }

            Context.SaveChanges();
        }
    }
}

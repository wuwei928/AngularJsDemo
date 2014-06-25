using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo.IRepostory
{
    public interface IBaseRespostory<TEntity> where TEntity  :class 
    {

        void Add(TEntity t);
        void Update(TEntity t);
        void Delete(int id);
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
    }
}

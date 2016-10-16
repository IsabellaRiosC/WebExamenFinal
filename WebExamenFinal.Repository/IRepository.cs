using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebExamenFinal.Repository
{
    public interface IRepository<T>
    {
        int Add(T entity);
        int Update(T entity);

        int Delete(T entity);

        List<T> GetList();

        T GetById(Expression<Func<T,bool>> match);

        IEnumerable<T> ListById(Expression<Func<T, bool>> match);
        IEnumerable<T> OrderedListByDateAndSize(Expression<Func<T, DateTime>> match, int size);
        IEnumerable<T> PaginatedList(Expression<Func<T, DateTime>> match, int page,int size);

        
    }


}

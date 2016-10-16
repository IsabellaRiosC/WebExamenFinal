using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace WebExamenFinal.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected WebContextDb db;

        public BaseRepository()
        {
            db = new WebContextDb();
        }

        public BaseRepository(WebContextDb webcontext)
        {
            db = webcontext;
        }

        public int Add(T entity)
        {

           
            db.Set<T>().Add(entity);
                return db.SaveChanges();
            
                
        }

        public int Delete(T entity)
        {
           
                db.Entry(entity).State = EntityState.Deleted;

                return db.SaveChanges();
            
        }

        public T GetById(Expression<Func<T, bool>> match)
        {
          
                
                return db.Set<T>().FirstOrDefault(match);
           
        }

        public List<T> GetList()
        {
            
            return db.Set<T>().ToList();

            
        }

        public IEnumerable<T> OrderedListByDateAndSize(Expression<Func<T, DateTime>> match, int size)
        {
            return db.Set<T>().OrderByDescending(match).Take(size);
        }

        public IEnumerable<T> PaginatedList(Expression<Func<T, DateTime>> match, int page, int size)
        {
            return db.Set<T>().OrderByDescending(match).Page(page,size);
        }

        public int Update(T entity)        {

             db.Entry(entity).State = EntityState.Modified;

            return db.SaveChanges();
            
        }


        public IEnumerable<T> ListById(Expression<Func<T, bool>> match)
        {
            return db.Set<T>().Where(match);

        }

    }
}

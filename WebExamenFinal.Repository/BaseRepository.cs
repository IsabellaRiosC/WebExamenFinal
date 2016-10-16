using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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

        public int Agregar(T entity)
        {
            db.Set<T>().Add(entity);
            return db.SaveChanges();
        }

        public int Eliminar(T entity)
        {

            db.Entry(entity).State = EntityState.Deleted;
            return db.SaveChanges();

        }

        public T ObtenerPorCodigo(Expression<Func<T, bool>> match)
        {
             return db.Set<T>().FirstOrDefault(match);

        }

        public List<T> ObtenerLista()
        {
            return db.Set<T>().ToList();

        }

    
        public IEnumerable<T> ListaPaginada(Expression<Func<T, int>> match, int page, int size)
        {
            return db.Set<T>().OrderByDescending(match).Page(page, size);
        }

        public int Actualizar(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return db.SaveChanges();

        }



    }
}

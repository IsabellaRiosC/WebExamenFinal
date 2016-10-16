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
        int Agregar(T entity);
        int Actualizar(T entity);
        int Eliminar(T entity);
        List<T> ObtenerLista();
        T ObtenerPorCodigo(Expression<Func<T, bool>> match);
        IEnumerable<T> ListaPaginada(Expression<Func<T, int>> match,int page, int size);
        //IEnumerable<T> ListById(Expression<Func<T, bool>> match);
        //IEnumerable<T> OrderedListByDateAndSize(Expression<Func<T, DateTime>> match, int size);

    }
}

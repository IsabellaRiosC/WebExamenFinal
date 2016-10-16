using System.Web.Mvc;
using WebExamenFinal.Filters;
using WebExamenFinal.Repository;

namespace WebExamenFinal.Areas.Maestro.Controllers
{   
    [Authorize] 
    [ExceptionControl]
    [OutputCache(Duration =0)]
    public class BaseController<T> : Controller where T: class 
    {
        protected IRepository<T>  _repository;
        public BaseController(IRepository<T> repository)
        {
            _repository = repository;
        }
    }
}
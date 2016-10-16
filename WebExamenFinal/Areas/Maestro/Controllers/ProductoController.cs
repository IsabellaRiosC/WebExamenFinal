using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebExamenFinal.Model;
using WebExamenFinal.Repository;
namespace WebExamenFinal.Areas.Maestro.Controllers
{
    public class ProductoController : BaseController<Product>
    {
        public ProductoController(IRepository<Product> repository) : base(repository)
        {
        }
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Lista(int? page, int? size)
        {
            if (!page.HasValue || !size.HasValue)
            {
                page = 1;
                size = 20;
            }
            return PartialView("_Lista", _repository.ListaPaginada((x => x.Id), page.Value, size.Value).Where(x => x.IsDiscontinued != true));
        }

        public int CantidadPaginas(int pageSize)
        {
            var totalRecords = _repository.ObtenerLista().Where(x => x.IsDiscontinued !=true).Count();
            return totalRecords % pageSize > 0 ? (totalRecords / pageSize) + 1 : totalRecords / pageSize;
        }

        public ActionResult Crear()
        {
            var model = new Product();
            return PartialView("_Crear", model);
        }

        [HttpPost]
        public ActionResult Crear(Product producto)
        {
            if (!ModelState.IsValid)
            {
                var model = new Product();
                return PartialView("_Crear", model);
            }
            _repository.Agregar(producto);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }


        public ActionResult Detalle(int id)
        {
            var producto = _repository.ObtenerPorCodigo(x => x.Id == id);
            if (producto == null) return RedirectToAction("Index");
            return PartialView("_Detalle", producto);
        }

        public ActionResult Editar(int id)
        {
            var producto = _repository.ObtenerPorCodigo(x => x.Id == id);
            if (producto == null) return RedirectToAction("Index");
            return PartialView("_Editar", producto);
        }

        [HttpPost]
        public ActionResult Editar(Product producto)
        {
            if (!ModelState.IsValid) return PartialView("_Editar", producto);
            _repository.Actualizar(producto);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }


        public ActionResult Eliminar(int id)
        {
            var producto = _repository.ObtenerPorCodigo(x => x.Id == id);
            if (producto == null) return RedirectToAction("Index");
            return PartialView("_Eliminar", producto);
        }

        [HttpPost]
        public ActionResult Eliminar(Product producto)
        {
            _repository.Eliminar(producto);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }


    }
}
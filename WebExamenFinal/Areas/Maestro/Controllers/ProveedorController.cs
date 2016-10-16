using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebExamenFinal.Model;
using WebExamenFinal.Repository;

namespace WebExamenFinal.Areas.Maestro.Controllers
{
    public class ProveedorController : BaseController<Supplier>
    {
        public ProveedorController(IRepository<Supplier> repository) : base(repository)
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
            return PartialView("_Lista", _repository.ListaPaginada((x => x.Id), page.Value, size.Value));
        }

        public int CantidadPaginas(int pageSize)
        {
            var totalRecords = _repository.ObtenerLista().Count();
            return totalRecords % pageSize > 0 ? (totalRecords / pageSize) + 1 : totalRecords / pageSize;
        }

        public ActionResult Crear()
        {
            var model = new Supplier();
            return PartialView("_Crear", model);
        }

        [HttpPost]
        public ActionResult Crear(Supplier proveedor)
        {
            if (!ModelState.IsValid)
            {
                var model = new Supplier();
                return PartialView("_Crear", model);
            }
            _repository.Agregar(proveedor);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
               

        public ActionResult Editar(int id)
        {
            var proveedor = _repository.ObtenerPorCodigo(x => x.Id == id);
            if (proveedor == null) return RedirectToAction("Index");
            return PartialView("_Editar", proveedor);
        }

        [HttpPost]
        public ActionResult Editar(Supplier proveedor)
        {
            if (!ModelState.IsValid) return PartialView("_Editar", proveedor);
            _repository.Actualizar(proveedor);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public ActionResult Detalle(int id)
        {
            var proveedor = _repository.ObtenerPorCodigo(x => x.Id == id);
            if (proveedor == null) return RedirectToAction("Index");
            return PartialView("_Detalle", proveedor);
        }

        public ActionResult Eliminar(int id)
        {
            var proveedor = _repository.ObtenerPorCodigo(x => x.Id == id);
            if (proveedor == null) return RedirectToAction("Index");
            return PartialView("_Eliminar", proveedor);
        }

        [HttpPost]
        public ActionResult Eliminar(Supplier proveedor)
        {
            _repository.Eliminar(proveedor);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}
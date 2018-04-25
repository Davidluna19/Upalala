using PañaleraUpalala.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PañaleraUpalala.Services
{
    public class ProductoController : Controller
    {
        private ProductoRepository _repo;

        public ProductoController()
        {
            _repo = new ProductoRepository();
        }

        // GET: Producto
        public ActionResult Index()
        {
            var model = _repo.ObetnerTodos();
            ViewBag.db = new ApplicationDbContext();
            return View(model);
        }

        // GET: Producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = _repo.Buscar(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = _repo.Buscar(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Producto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                _repo.Eliminar(id);
                return RedirectToAction("Index","Producto");
            }

            catch
            {
                return RedirectToAction("Index","Producto");
            }
        }
    }
}

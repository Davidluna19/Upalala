using PañaleraUpalala.Models;
using PañaleraUpalala.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PañaleraUpalala.Controllers
{
    public class LineasCompraController : Controller
    {
        private LineasCompraRepository _repo;

        public LineasCompraController()
        {
            _repo = new LineasCompraRepository();
        }

        // GET: LineasCompra
        public ActionResult Index(int id)
        {
            var model = _repo.Buscar(id);
            ViewBag.db = new ApplicationDbContext();
            return View(model);
        }

        // GET: LineasCompra/Details/5
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

        // GET: LineasCompra/Create
        public ActionResult Create()
        {
            var db = new ApplicationDbContext();
            LineasCompraCreateView model = new LineasCompraCreateView();
            model.productos = db.Productos.ToList();
            return View(model);
        }

        // POST: LineasCompra/Create
        [HttpPost]
        public ActionResult Create(LineasCompraCreateView model)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    LineasCompra linea = new LineasCompra();
                    ///linea.compraId = model.compraId;
                    linea.productoId = model.productoId;
                    linea.cantidad = model.cantidad;
                    _repo.Crear(model);
                }
                return RedirectToAction("Create","Compra");
            }
            catch
            {
                /// MENSAJE ERROR
                return RedirectToAction("Create");
            }
        }


        // GET: LineasCompra/Edit/5
        public ActionResult Edit(int? id)
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
            var db = new ApplicationDbContext();
            ViewBag.categorias = new SelectList(db.Categorias, "id", "categoria");
            ViewBag.marcas = new SelectList(db.Marcas, "id", "marca");
            ViewBag.talles = new SelectList(db.Talles, "id", "talle");
            return View(model);
        }

        // POST: LineasCompra/Edit/5
        [HttpPost]
        public ActionResult Edit(LineasCompra model)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    _repo.Actualizar(model);
                }
                var db = new ApplicationDbContext();
                /// DATOS LINEASCOMPRA
                return RedirectToAction("Index", "Compra");
            }
            catch
            {
                return RedirectToAction("Index", "Compra");
            }
        }

        // GET: LineasCompra/Delete/5
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

        // POST: LineasCompra/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                _repo.Eliminar(id);
                return RedirectToAction("Index", "Compra");
            }

            catch
            {
                return RedirectToAction("Index", "Compra");
            }
        }
    }
}

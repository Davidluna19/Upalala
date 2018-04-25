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
    public class ProveedorController : Controller
    {
        private ProveedorRepository _repo;

        public ProveedorController()
        {
            _repo = new ProveedorRepository();
        }

        // GET: Proveedor
        public ActionResult Index()
        {
            var model = _repo.ObetnerTodos();
            return View(model);
        }

        // GET: Proveedor/Details/5
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

        // GET: Proveedor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proveedor/Create
        [HttpPost]
        public ActionResult Create(Proveedor model)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    _repo.Crear(model);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                /// MENSAJE ERROR
                return RedirectToAction("Create");
            }
        }

        // GET: Proveedor/Edit/5
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
            return View(model);
        }

        // POST: Proveedor/Edit/5
        [HttpPost]
        public ActionResult Edit(Proveedor model)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    _repo.Actualizar(model);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Proveedor/Delete/5
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

        // POST: Proveedor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                _repo.Eliminar(id);
                return RedirectToAction("Index");
            }

            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}

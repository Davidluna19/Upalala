using PañaleraUpalala.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PañaleraUpalala.Views
{
    public class MarcaController : Controller
    {
        private MarcaRepository _repo;

        public MarcaController()
        {
            _repo = new MarcaRepository();
        }

        // GET: Marca
        public ActionResult Index()
        {
            var model = _repo.ObetnerTodos();
            return View(model);
        }

        // GET: Marca/Details/5
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

        // GET: Marca/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Marca/Create
        [HttpPost]
        public ActionResult Create(Marca model)
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

        // GET: Marca/Edit/5
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

        // POST: Marca/Edit/5
        [HttpPost]
        public ActionResult Edit(Marca model)
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

        // GET: Marca/Delete/5
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

        // POST: Marca/Delete/5
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

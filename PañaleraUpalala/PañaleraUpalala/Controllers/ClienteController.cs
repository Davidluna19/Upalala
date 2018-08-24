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
    public class ClienteController : Controller
    {
        private ClienteRepository _repo;
        private ApplicationDbContext db = new ApplicationDbContext();

        public ClienteController()
        {
            _repo = new ClienteRepository();

        }

        // GET: Cliente
        public ActionResult Index()
        {
            var model = _repo.ObetnerTodos();
            return View(model);
        }

        // GET: Cliente/Details/5
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

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Cliente model)
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

        // GET: Cliente/Edit/5
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

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(Cliente model)
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

        // GET: Cliente/Delete/5
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
            string qery = "SELECT * FROM dbo.Ventas WHERE clienteId = " + model.id.ToString();
            var ventas = db.Ventas.SqlQuery(qery).ToList();
            ViewBag.ventas = ventas;
            return View(model);
        }

        // POST: Cliente/Delete/5
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

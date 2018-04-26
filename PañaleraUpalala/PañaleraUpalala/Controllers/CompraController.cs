using PañaleraUpalala.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PañaleraUpalala.Controllers
{
    public class CompraController : Controller
    {
        // GET: Compra
        public ActionResult Index()
        {
            return View();
        }

        // GET: Compra/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Compra/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Compra/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Compra/Create
        public ActionResult Create()
        {
            CompraCreateView model = new CompraCreateView();
            var db = new ApplicationDbContext();
            ViewBag.proveedores = db.Proveedores.ToList();
            model.proveedores  = db.Proveedores.ToList();
            return View(model);
        }

        // POST: Compra/Create
        [HttpPost]
        public ActionResult Create(CompraCreateView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var db = new ApplicationDbContext();
                    //Insertar en db
                    Compra compra = new Compra();
                    compra.fecha = model.fecha;
                    compra.proveedorId = model.proveedorId;
                    db.Compras.Add(compra);
                    foreach (LineasCompra linea in model.lineas) {
                        linea.compraId = compra.id;
                        db.LineasComrpas.Add(linea);
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                /// MENSAJE ERROR
                return RedirectToAction("Create");
            }
        }
    }
}

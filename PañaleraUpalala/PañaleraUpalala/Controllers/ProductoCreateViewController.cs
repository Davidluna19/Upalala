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
    public class ProductoCreateViewController : Controller
    {
        private ProductoRepository _repo;

        public ProductoCreateViewController()
        {
            _repo = new ProductoRepository();
        }

        // GET: ProductoCreateView/Create
        public ActionResult Create()
        {
            var db = new ApplicationDbContext();
            var model = new ProductoCreateView();
            model.categorias = db.Categorias.ToList();
            model.talles = db.Talles.ToList();
            model.marcas = db.Marcas.ToList();
            return View(model);
        }

        // POST: ProductoCreateView/Create
        [HttpPost]
        public ActionResult Create(ProductoCreateView model)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var db = new ApplicationDbContext();
                    Producto prod = new Producto
                    {
                        nombre = model.nombre,
                        categoriaId = model.categoriaId,
                        marcaId = model.marcaId,
                        talleId = model.talleId,
                        costo = model.costo,
                        recargo = model.recargo
                    };
                    _repo.Crear(prod);
                }
                return RedirectToAction("Index","Producto");
            }
            catch
            {
                /// MENSAJE ERROR
                return RedirectToAction("Create");
            }
        }

        // GET: ProductoCreateView/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var producto = _repo.Buscar(id);            
            if (producto == null)
            {
                return HttpNotFound();

            }
            var db = new ApplicationDbContext();
            var model = new ProductoCreateView
            {
                id = producto.id,
                nombre = producto.nombre,
                categorias = db.Categorias.ToList(),
                marcas = db.Marcas.ToList(),
                talles =db.Talles.ToList(),
                costo = producto.costo,
                recargo = producto.recargo
            };
            return View(model);
        }

        // POST: ProductoCreateView/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductoCreateView model)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    var db = new ApplicationDbContext();
                    Producto prod = new Producto
                    {
                        id = model.id,
                        nombre = model.nombre,
                        categoriaId = model.categoriaId,
                        marcaId = model.marcaId,
                        talleId = model.talleId,
                        costo = model.costo,
                        recargo = model.recargo
                    };
                    _repo.Actualizar(prod);
                }
                return RedirectToAction("Index","Producto");
            }
            catch
            {
                return RedirectToAction("Index","Producto");
            }
        }
    }
}

using PañaleraUpalala.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PañaleraUpalala.Controllers
{
    public class CompraCreateViewController : Controller
    {
        // GET: CompraCreateView
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Compra");
        }

        // GET: CompraCreateView/Create
        public ActionResult Create()
        {
            var db = new ApplicationDbContext();
            CompraCreateView model = new CompraCreateView();
            model.proveedores = db.Proveedores.ToList();
            if (model.productos == null)
            {
                model.productos = new List<LineasCompra>();
            }
            Session["CargaCompra"] = model;
            return View(model);
        }

        // POST: CompraCreateView/Create
        [HttpPost]
        public ActionResult Create(CompraCreateView model)
        {
            var db = new ApplicationDbContext();
            //var CargaCompra = Session["CargaCompra"] as CompraCreateView;
            Compra compra = new Compra();
            compra.fecha = model.fecha;
            compra.proveedorId = model.proveedorId;
            compra.proveedor = model.proveedor;
            compra.productos = model.productos;
            db.Compras.Add(compra);
            compra.ActualizarStock();
            foreach (LineasCompra linea in model.productos)
            {
                linea.compra = compra;
                linea.compraId = compra.id;
                db.LineasComrpas.Add(linea);
            }
            return View("Index", "Compra");
        }

        // GET: LineasCompra/AgregarLinea
        [HttpGet]
        public ActionResult AgregarLinea()
        {
            var db = new ApplicationDbContext();
            LineasCompraCreateView model = new LineasCompraCreateView();
            model.productos = db.Productos.ToList();
            return View(model);
        }

        // POST: LineasCompra/AgregarLinea
        [HttpPost]
        public ActionResult AgregarLinea(LineasCompraCreateView model)
        {
            var db = new ApplicationDbContext();
            var CargaCompra = Session["CargaCompra"] as CompraCreateView;
            var producto = db.Productos.Find(model.productoId);
            LineasCompra linea = new LineasCompra();
            linea.productoId = model.productoId;
            linea.producto = producto;
            linea.costo = producto.costo;
            linea.cantidad = model.cantidad;
            linea.compraId = model.compraId;
            CargaCompra.productos.Add(linea);
            CargaCompra.proveedores = db.Proveedores.ToList();
            return RedirectToAction("Create", "CompraCreateView", CargaCompra);
        }

        // GET: LineasCompra/Create VOLVER        
        public ActionResult Cancelar()
        {
            var db = new ApplicationDbContext();
            var cargaCompra = Session["CargaCompra"] as CompraCreateView;
            cargaCompra.proveedores = db.Proveedores.ToList();
            return RedirectToAction("Create", "Compra", cargaCompra);
        }
    }
}
using PañaleraUpalala.Models;
using PañaleraUpalala.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PañaleraUpalala.Controllers
{
    public class CompraController : Controller
    {
        private CompraRepository _repo;
        private ProductoRepository _repoProd;
        private ApplicationDbContext db = new ApplicationDbContext();

        public CompraController()
        {
            _repo = new CompraRepository();
            _repoProd = new ProductoRepository();
        }

        // GET: Compra
        public ActionResult Index()
        {
            var model = _repo.ObetnerTodos();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CompraCreateView compraView = new CompraCreateView();
            compraView.proveedor = new Proveedor();
            compraView.productos = new List<LineasCompra>();
            compraView.fecha = System.DateTime.Now;
            compraView.proveedores = db.Proveedores.ToList();
            Session["CompraView"] = compraView;
            if (compraView.productos == null)
            {
                compraView.productos = new List<LineasCompra>();
            }
            return View(compraView);
        }

        [HttpGet]
        public ActionResult NoLinea()
        {
            var compraView = Session["CompraView"] as CompraCreateView;
            compraView.proveedores = db.Proveedores.ToList();
            return View("Create", compraView);
        }

        [HttpPost]
        public ActionResult Create(CompraCreateView compra)
        {
            compra = Session["CompraView"] as CompraCreateView;
            int idPorveedor = int.Parse(Request["proveedorId"]);
            DateTime fechaCompra = Convert.ToDateTime(Request["fecha"]);
            Compra nuevaCompra = new Compra()
            {
                proveedorId = idPorveedor,
                fecha = fechaCompra
            };
            db.Compras.Add(nuevaCompra);
            db.SaveChanges();
            int ultimoIdCompra = db.Compras.ToList().Select(o => o.id).Max();
            foreach (LineasCompra linea in compra.productos)
            {
                var detalle = new LineasCompra()
                {
                    compraId = ultimoIdCompra,
                    productoId = linea.productoId,
                    cantidad = linea.cantidad,
                    costo = linea.costo
                };
                Producto prod = db.Productos.Find(linea.productoId);
                prod.Compra(linea.cantidad);
                _repoProd.Actualizar(prod);
                db.LineasCompras.Add(detalle);
            }
            Caja caja = new Caja()
            {
                fecha = compra.fecha,
                compra = true,
                descripcion = "Compra",
                movimientoId = nuevaCompra.id,
                monto = compra.Total
            };
            db.Caja.Add(caja);
            db.SaveChanges();
            var compraView = Session["CompraView"] as CompraCreateView;
            compraView.proveedores = db.Proveedores.ToList();
            return RedirectToAction("Index","Compra");
        }


        [HttpGet]
        public ActionResult AgregarLinea()
        {
            LineasCompraCreateView model = new LineasCompraCreateView();
            model.productos = db.Productos.ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult AgregarLinea(LineasCompra linea)
        {
            var compraView = Session["CompraView"] as CompraCreateView;
            var idProducto = int.Parse(Request["productoId"]);
            var producto = db.Productos.Find(idProducto);
            linea = new LineasCompra()
            {
                productoId = producto.id,
                costo = producto.costo,
                cantidad = int.Parse(Request["cantidad"])
            };
            compraView.productos.Add(linea);
            compraView.proveedores = db.Proveedores.ToList();
            return View("Create", compraView);
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
    }
}

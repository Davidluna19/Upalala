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
    public class VentaController : Controller
    {
        private VentaRepository _repo;
        private ProductoRepository _repoProd;
        private ClienteRepository _repoCli;
        private ApplicationDbContext db = new ApplicationDbContext();

        public VentaController()
        {
            _repo = new VentaRepository();
            _repoProd = new ProductoRepository();
            _repoCli = new ClienteRepository();
        }

        // GET: Venta
        public ActionResult Index()
        {
            var model = _repo.ObetnerTodos();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            VentaCreateView VentaView = new VentaCreateView();
            VentaView.cliente= new Cliente();
            VentaView.productos = new List<LineasVenta>();
            VentaView.fecha = System.DateTime.Now.Date;
            VentaView.clientes = db.Clientes.ToList();
            Session["VentaView"] = VentaView;
            if (VentaView.productos == null)
            {
                VentaView.productos = new List<LineasVenta>();
            }
            return View(VentaView);
        }

        [HttpPost]
        public ActionResult Create(VentaCreateView venta)
        {
            venta = Session["VentaView"] as VentaCreateView;
            int idCliente = int.Parse(Request["clienteId"]);
            DateTime fechaVenta = Convert.ToDateTime(Request["fecha"]);
            double pago = double.Parse(Request["pago"]);
            Venta nuevaVenta = new Venta()
            {
                clienteId= idCliente,
                fecha = fechaVenta,
                pago = pago
            };
            db.Ventas.Add(nuevaVenta);
            db.SaveChanges();
            int ultimoIdVenta = db.Ventas.ToList().Select(o => o.id).Max();
            foreach (LineasVenta linea in venta.productos)
            {
                var detalle = new LineasVenta()
                {
                    ventaId = ultimoIdVenta,
                    productoId = linea.productoId,
                    cantidad = linea.cantidad,
                    precio = linea.precio
                };
                Producto prod = db.Productos.Find(linea.productoId);
                prod.Venta(linea.cantidad);
                _repoProd.Actualizar(prod);
                db.LineasVentas.Add(detalle);
            }
            Caja caja = new Caja()
            {
                fecha = venta.fecha,
                compra = false,
                descripcion = "Venta",
                movimientoId = nuevaVenta.id,
                monto = venta.pago
            };
            db.Caja.Add(caja);
            db.SaveChanges();
            double debe = nuevaVenta.Total - nuevaVenta.pago;
            if (debe > 0 )
            {
                var cliente = db.Clientes.Find(nuevaVenta.clienteId);
                cliente.Debe(debe);
                _repoCli.Actualizar(cliente);
            }
            db.SaveChanges();
            var ventaView = Session["VentaView"] as VentaCreateView;
            ventaView.clientes = db.Clientes.ToList();
            return RedirectToAction("Index", "Venta");
        }


        [HttpGet]
        public ActionResult AgregarLinea()
        {
            LineasVentaCreateView model = new LineasVentaCreateView();
            model.productos = db.Productos.ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult AgregarLinea(LineasVenta linea)
        {
            var ventaView = Session["VentaView"] as VentaCreateView;
            var idProducto = int.Parse(Request["productoId"]);
            var producto = db.Productos.Find(idProducto);
            linea = new LineasVenta()
            {
                productoId = producto.id,
                precio = producto.Precio,
                cantidad = int.Parse(Request["cantidad"])
            };
            ventaView.productos.Add(linea);
            ventaView.clientes = db.Clientes.ToList();
            return View("Create", ventaView);
        }

        [HttpGet]
        public ActionResult NoLinea()
        {
            var ventaView = Session["VentaView"] as VentaCreateView;
            ventaView.clientes = db.Clientes.ToList();
            return View("Create", ventaView);
        }

        // GET: Compra/Details/5
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
            VentaCreateView VentaView = new VentaCreateView();
            VentaView.cliente = db.Clientes.Find(model.clienteId);
            string qery = "SELECT * FROM dbo.LineasVentas WHERE ventaId = " + model.id.ToString();
            VentaView.productos = db.LineasVentas.SqlQuery(qery).ToList();
            VentaView.fecha = model.fecha;
            return View(VentaView);
        }

        // GET: Compra/Delete/5
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
            VentaCreateView VentaView = new VentaCreateView();
            VentaView.cliente = db.Clientes.Find(model.clienteId);
            string qery = "SELECT * FROM dbo.LineasVentas WHERE ventaId = " + model.id.ToString();
            VentaView.productos = db.LineasVentas.SqlQuery(qery).ToList();
            VentaView.fecha = model.fecha;
            return View(VentaView);
        }

        // POST: Compra/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var venta = _repo.Buscar(id);
                string qery = "SELECT * FROM dbo.LineasVentas WHERE ventaId = " + venta.id.ToString();
                var productos = db.LineasVentas.SqlQuery(qery).ToList();
                foreach (LineasVenta linea in productos)
                {
                    var prod = _repoProd.Buscar(linea.productoId);
                    prod.Compra(linea.cantidad);
                    _repoProd.Actualizar(prod);
                    db.LineasVentas.Remove(linea);        
                }
                db.SaveChanges();
                _repo.Eliminar(id);
                return RedirectToAction("Index", "Venta");
            }
            catch
            {
                return RedirectToAction("Index", "Venta");
            }
        }
    }
}

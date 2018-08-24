using PañaleraUpalala.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PañaleraUpalala.Services
{
    public class ClienteRepository
    {
        public List<Cliente> ObetnerTodos()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Clientes.ToList();
            }
        }

        public Cliente Buscar(int? id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Clientes.Find(id);
            }
        }

        internal void Crear(Cliente model)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Clientes.Add(model);
                db.SaveChanges();
            }
        }

        internal void Actualizar(Cliente model)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        internal void Eliminar(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var model = db.Clientes.Find(id);
                string qery = "SELECT * FROM dbo.Ventas WHERE clienteId = " + model.id.ToString();
                var ventas = db.Ventas.SqlQuery(qery).ToList();            
                foreach (Venta venta in ventas)
                {
                    string qry = "SELECT * FROM dbo.LineasVentas WHERE ventaId = " + venta.id.ToString();
                    var productos = db.LineasVentas.SqlQuery(qry).ToList();
                    foreach (LineasVenta linea in productos)
                    {                     
                        db.LineasVentas.Remove(linea);
                    }
                    db.Ventas.Remove(venta);
                }
                db.Clientes.Remove(model);
                db.SaveChanges();
            }
        }
    }
}
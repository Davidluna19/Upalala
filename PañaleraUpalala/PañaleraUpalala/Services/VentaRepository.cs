using PañaleraUpalala.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PañaleraUpalala.Services
{
    public class VentaRepository
    {
        public List<Venta> ObetnerTodos()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Ventas.ToList();
            }
        }

        public Venta Buscar(int? id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Ventas.Find(id);
            }
        }

        internal void Crear(Venta model)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Ventas.Add(model);
                db.SaveChanges();
            }
        }

        internal void Actualizar(Venta model)
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
                var model = db.Ventas.Find(id);
                db.Ventas.Remove(model);
                db.SaveChanges();
            }
        }
    }
}
using PañaleraUpalala.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PañaleraUpalala.Services
{
    public class ProductoRepository
    {
        public List<Producto> ObetnerTodos()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Productos.ToList();
            }
        }

        public Producto Buscar(int? id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Productos.Find(id);
            }
        }

        internal void Crear(Producto model)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Productos.Add(model);
                db.SaveChanges();
            }
        }

        internal void Actualizar(Producto model)
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
                var model = db.Productos.Find(id);
                db.Productos.Remove(model);
                db.SaveChanges();
            }
        }
    }
}
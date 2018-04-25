using PañaleraUpalala.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PañaleraUpalala.Services
{
    public class ProveedorRepository
    {
        public List<Proveedor> ObetnerTodos()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Proveedores.ToList();
            }
        }

        public Proveedor Buscar(int? id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Proveedores.Find(id);
            }
        }

        internal void Crear(Proveedor model)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Proveedores.Add(model);
                db.SaveChanges();
            }
        }

        internal void Actualizar(Proveedor model)
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
                var model = db.Proveedores.Find(id);
                db.Proveedores.Remove(model);
                db.SaveChanges();
            }
        }
    }
}
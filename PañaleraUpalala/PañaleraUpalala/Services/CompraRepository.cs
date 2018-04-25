using PañaleraUpalala.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PañaleraUpalala.Services
{
    public class CompraRepository
    {
        public List<Compra> ObetnerTodos()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Compras.ToList();
            }
        }

        public Compra Buscar(int? id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Compras.Find(id);
            }
        }

        internal void Crear(Compra model)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Compras.Add(model);
                db.SaveChanges();
            }
        }

        internal void Actualizar(Compra model)
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
                var model = db.Compras.Find(id);
                db.Compras.Remove(model);
                db.SaveChanges();
            }
        }
    }
}
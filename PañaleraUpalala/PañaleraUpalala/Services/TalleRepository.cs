using PañaleraUpalala.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PañaleraUpalala.Services
{
    public class TalleRepository
    {
        public List<Talle> ObetnerTodos()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Talles.ToList();
            }
        }

        public Talle Buscar(int? id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Talles.Find(id);
            }
        }

        internal void Crear(Talle model)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Talles.Add(model);
                db.SaveChanges();
            }
        }

        internal void Actualizar(Talle model)
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
                var model = db.Talles.Find(id);
                db.Talles.Remove(model);
                db.SaveChanges();
            }
        }
    }
}
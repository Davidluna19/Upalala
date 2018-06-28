using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PañaleraUpalala.Models
{
    public class CajaReposiroty
    {
        public List<Caja> ObetnerTodos()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Caja.ToList();
            }
        }

        public Caja Buscar(int? id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Caja.Find(id);
            }
        }

        internal void Crear(Caja model)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Caja.Add(model);
                db.SaveChanges();
            }
        }

        internal void Actualizar(Caja model)
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
                var model = db.Caja.Find(id);
                db.Caja.Remove(model);
                db.SaveChanges();
            }
        }
    }
}
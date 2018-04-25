using PañaleraUpalala.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PañaleraUpalala
{
    public class MarcaRepository
    {
        public List<Marca> ObetnerTodos()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Marcas.ToList();
            }
        }

        public Marca Buscar(int? id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Marcas.Find(id);
            }
        }

        internal void Crear(Marca model)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Marcas.Add(model);
                db.SaveChanges();
            }
        }

        internal void Actualizar(Marca model)
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
                var model = db.Marcas.Find(id);
                db.Marcas.Remove(model);
                db.SaveChanges();
            }
        }

    }
}
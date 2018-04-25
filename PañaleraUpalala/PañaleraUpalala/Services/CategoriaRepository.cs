using PañaleraUpalala.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PañaleraUpalala.Services
{
    public class CategoriaRepository
    {
        public List<Categoria> ObetnerTodos()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Categorias.ToList();
            }
        }

        public Categoria Buscar(int? id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Categorias.Find(id);
            }
        }

        internal void Crear(Categoria model)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Categorias.Add(model);
                db.SaveChanges();
            }
        }

        internal void Actualizar(Categoria model)
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
                var model = db.Categorias.Find(id);
                db.Categorias.Remove(model);
                db.SaveChanges();
            }
        }
    }
}
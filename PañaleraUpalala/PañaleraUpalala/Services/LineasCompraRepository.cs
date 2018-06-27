using PañaleraUpalala.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PañaleraUpalala.Services
{
    public class LineasCompraRepository
    {
        public List<LineasCompra> ObetnerTodos()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.LineasCompras.ToList();
            }
        }

        public List<LineasCompra> Buscar(int? id)
        {
            using (var db = new ApplicationDbContext())
            {
                var consulta = (from linea in db.LineasCompras
                             where linea.compraId == id
                             orderby linea.id
                             select linea).ToList();
                return consulta;
            }
        }

        internal void Crear(LineasCompra model)
        {
            using (var db = new ApplicationDbContext())
            {
                db.LineasCompras.Add(model);
                db.SaveChanges();
            }
        }

        internal void Actualizar(LineasCompra model)
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
                var model = db.LineasCompras.Find(id);
                db.LineasCompras.Remove(model);
                db.SaveChanges();
            }
        }
    }
}
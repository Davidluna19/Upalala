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
                return db.LineasComrpas.ToList();
            }
        }

        public List<LineasCompra> Buscar(int? id)
        {
            using (var db = new ApplicationDbContext())
            {
                var consulta = (from linea in db.LineasComrpas
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
                db.LineasComrpas.Add(model);
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
                var model = db.LineasComrpas.Find(id);
                db.LineasComrpas.Remove(model);
                db.SaveChanges();
            }
        }
    }
}
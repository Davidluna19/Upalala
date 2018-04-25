using PañaleraUpalala.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PañaleraUpalala.Services
{
    public class ClienteRepository
    {
        public List<Cliente> ObetnerTodos()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Clientes.ToList();
            }
        }

        public Cliente Buscar(int? id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Clientes.Find(id);
            }
        }

        internal void Crear(Cliente model)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Clientes.Add(model);
                db.SaveChanges();
            }
        }

        internal void Actualizar(Cliente model)
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
                var model = db.Clientes.Find(id);
                db.Clientes.Remove(model);
                db.SaveChanges();
            }
        }
    }
}
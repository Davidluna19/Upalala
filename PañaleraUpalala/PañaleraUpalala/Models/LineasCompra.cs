using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PañaleraUpalala.Models
{
    public class LineasCompra
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public int id { get; set; }
        public int compraId { get; set; }
        [ForeignKey("compraId")]
        [Display(Name = "Compra")]
        public Compra compra { get; set; }
        public int productoId { get; set; }
        [ForeignKey("productoId")]
        public Producto producto { get; set; }
        [Display(Name = "Cantidad")]
        public int cantidad { get; set; }
        [Display(Name = "costo")]
        public Double costo { get; set; }

        public double Total
        { get
            {
                 return (this.costo * this.cantidad);
            }
        }

        [Display(Name ="Producto")]
        public string ProductoDesc
        {
            get
            {
                Producto prod = db.Productos.Find(productoId);
                return (prod.Descripcion);
            }
        }
    }
}
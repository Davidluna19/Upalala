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
        public int id { get; set; }
        public int compraId { get; set; }
        [ForeignKey("compraId")]
        [Display(Name = "Compra")]
        public Compra compra { get; set; }
        public int productoId { get; set; }
        [ForeignKey("productoId")]
        [Display(Name = "Producto")]
        public Producto producto { get; set; }
        [Display(Name = "Cantidad")]
        public int cantidad { get; set; }

        public double Total
        { get
            {
                var db = new ApplicationDbContext();
                var producto_query = from a in db.Productos
                                  where a.id == this.productoId
                                  select a;
                if (producto_query.Any())
                {
                    Producto prod = producto_query.First();
                    return (prod.costo * this.cantidad);
                }else
                {
                    return 0.0;
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PañaleraUpalala.Models
{
    public class LineasVenta
    {
        public int id { get; set; }
        public int ventaId { get; set; }
        [ForeignKey("ventaId")]
        [Display(Name = "Venta")]
        public Venta venta { get; set; }
        public int productoId { get; set; }
        [ForeignKey("productoId")]
        [Display(Name = "Producto")]
        public Producto producto { get; set; }
        [Display(Name = "Cantidad")]
        public int cantidad { get; set; }

        public double Total { get { return (this.producto.Precio() * this.cantidad); } }
    }
}
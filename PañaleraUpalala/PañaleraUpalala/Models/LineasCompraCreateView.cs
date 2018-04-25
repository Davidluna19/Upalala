using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PañaleraUpalala.Models
{
    public class LineasCompraCreateView
    {
        public int id { get; set; }
        public IEnumerable<Producto> productos { get; set; }
        [Display(Name ="Compra")]
        public int compraId { get; set; }
        [Display(Name = "Cantidad")]
        public int cantidad { get; set; }
        [Display(Name = "Producto")]
        public int productoId { get; set; }
    }
}
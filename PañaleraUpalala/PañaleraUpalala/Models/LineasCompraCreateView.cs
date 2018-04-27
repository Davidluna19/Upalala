using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PañaleraUpalala.Models
{
    public class LineasCompraCreateView: LineasCompra
    {
        public IEnumerable<Producto> productos { get; set; }
    }
}
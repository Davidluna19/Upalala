using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PañaleraUpalala.Models
{
    public class LineasVentaCreateView: LineasVenta
    {
        public IEnumerable<Producto> productos { get; set; }
    }
}
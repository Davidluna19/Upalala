using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PañaleraUpalala.Models
{
    public class CompraCreateView: Compra
    {
        public IEnumerable<Proveedor> proveedores { get; set; }

    }
}
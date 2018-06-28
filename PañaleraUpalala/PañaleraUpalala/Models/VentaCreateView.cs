using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PañaleraUpalala.Models
{
    public class VentaCreateView: Venta
    {
        public IEnumerable<Cliente> clientes { get; set; }
    }
}
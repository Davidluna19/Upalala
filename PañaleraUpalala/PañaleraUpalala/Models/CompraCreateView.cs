using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PañaleraUpalala.Models
{
    public class CompraCreateView
    {
        public int id { get; set; }
        [Required(ErrorMessage = "El campo es requerido.")]
        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        public DateTime fecha { get; set; }
        public IEnumerable<Proveedor> proveedores { get; set; }
        [Required(ErrorMessage = "El campo es requerido.")]
        [Display(Name = "Proveedor")]
        public int proveedorId { get; set; }
        public IEnumerable<LineasCompra> lineas { get; set; }
    }
}
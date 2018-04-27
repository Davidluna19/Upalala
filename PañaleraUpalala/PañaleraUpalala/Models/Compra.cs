using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PañaleraUpalala.Models
{
    public class Compra
    {
        public int id { get; set; }
        [Required(ErrorMessage ="El campo es requerido.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha")]
        public DateTime fecha { get; set; }
        public int proveedorId { get; set; }
        [ForeignKey("proveedorId")]
        [Display(Name = "Proveedor")]
        public Proveedor proveedor { get; set; }
        [Display(Name = "Productos")]
        public List<LineasCompra> productos { get; set; }

        public double Total
        {
            get
            {
                double total = 0.0;
                foreach (LineasCompra linea in productos)
                {
                    total += linea.Total;
                }
                return total;
            }
        }
        public void ActualizarStock()
        {
            foreach (LineasCompra linea in productos)
            {
                linea.producto.Compra(linea.cantidad);
            }
        }
    }
}
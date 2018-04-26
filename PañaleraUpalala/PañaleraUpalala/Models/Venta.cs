using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PañaleraUpalala.Models
{
    public class Venta
    {
        public int id { get; set; }
        [Required(ErrorMessage = "El campo es requerido.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha")]
        public DateTime fecha { get; set; }
        public int clienteId { get; set; }
        [ForeignKey("clienteId")]
        [Display(Name = "Cliente")]
        public Cliente cliente { get; set; }
        [Display(Name = "Productos")]
        public List<LineasVenta> productos { get; set; }
        [Display(Name = "Pago")]
        public double pago { get; set; }

        public double Total()
        {
            double total = 0.0;
            foreach (LineasVenta linea in productos)
            {
                total += linea.Total;
            }
            return total;
        }

        public bool ControlStock()
        {
            bool aux = true;
            foreach (LineasVenta linea in productos)
            {
                if (linea.producto.ControlarStock(linea.cantidad) == false)
                {
                    aux = false;
                    break;
                }
            }
            return aux;
        }

        public void ActualizarStock()
        {
            foreach (LineasVenta linea in productos)
            {
                linea.producto.stock -= linea.cantidad;
            }
        }
    }
}
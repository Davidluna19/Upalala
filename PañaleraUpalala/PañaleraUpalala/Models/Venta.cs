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
        private ApplicationDbContext db = new ApplicationDbContext();
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

        [Display(Name = "Total")]
        public double Total
        {
            get
            {
                double total = 0.0;
                var lineas = db.LineasVentas.ToList();
                if (lineas != null)
                {
                    foreach (LineasVenta linea in lineas)
                    {
                        if (linea.ventaId == this.id)
                        {
                            total += linea.Total;
                        }
                    }
                }
                return total;
            }
        }

        [Display(Name = "Cliente")]
        public string ClienteDesc
        {
            get
            {
                Cliente cli = db.Clientes.Find(clienteId);
                return cli.nombre;
            }
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
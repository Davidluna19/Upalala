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
        private ApplicationDbContext db = new ApplicationDbContext();
        public int id { get; set; }
        [Required(ErrorMessage ="El campo es requerido.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha")]
        public DateTime fecha { get; set; }
        [Display(Name = "ProveedorID")]
        public int proveedorId { get; set; }
        [ForeignKey("proveedorId")]
        public Proveedor proveedor { get; set; }
        [Display(Name = "Productos")]
        public List<LineasCompra> productos { get; set; }

        [Display(Name = "Total")]
        public double Total
        {
            get
            {
                double total = 0.0;
                var lineas = db.LineasCompras.ToList();
                if (lineas != null)
                {
                    foreach (LineasCompra linea in lineas)
                    {
                        if (linea.compraId == this.id)
                        {
                            total += linea.Total;
                        }
                    }
                }
                return total;
            }
        }

        [Display(Name = "Proveedor")]
        public string ProveedorDesc
        {
            get
            {
                Proveedor prov = db.Proveedores.Find(proveedorId);
                return prov.nombre;                
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
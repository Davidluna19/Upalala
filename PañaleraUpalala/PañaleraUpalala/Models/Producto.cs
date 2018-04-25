using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PañaleraUpalala.Models
{
    public class Producto
    {
        public int id { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        public int categoriaId { get; set; }
        [ForeignKey("categoriaId")]
        [Display(Name = "Categoria")]
        public Categoria categoria { get; set; }
        public int marcaId { get; set; }
        [ForeignKey("marcaId")]
        [Display(Name = "Marca")]
        public Marca marca { get; set; }
        public int talleId { get; set; }
        [ForeignKey("talleId")]
        [Display(Name = "Talle")]
        public Talle talle { get; set; }
        [Display(Name = "Stock")]
        public int stock = 0;
        [Required]
        [Display(Name = "Costo")]
        public double costo { get; set; }
        [Required]
        [Display(Name = "Recargo")]
        public double recargo { get;  set; }
        [Display(Name = "Compras")]
        List<LineasCompra> compras { get; set; }
        [Display(Name = "Ventas")]
        List<LineasVenta> ventas { get; set; }

        public int Stock()
        {
            return this.stock;
        }

        public string Descripcion() => (this.marca.marca + " " + this.nombre + " " + this.talle.talle);

        public void Compra(int cantidad)
        {
            this.stock += cantidad;
        }

        public void Venta(int cantidad)
        {
            this.stock -= cantidad;
        }

        public double Precio()
        {
            return (this.costo * this.recargo);
        }

        public bool ControlarStock(int cant)
        {
            bool aux = false;
            if (this.stock >= cant)
            {
                aux = true;
            }
            return aux;
        }
    }
}
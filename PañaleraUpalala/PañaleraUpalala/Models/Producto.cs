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
        [Required(ErrorMessage = "El campo es requerido.")]
        [StringLength(20,ErrorMessage ="No más de 20 caracteres.")]
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
        [Required(ErrorMessage = "El campo es requerido.")]
        [Display(Name = "Costo")]
        public double costo { get; set; }
        [Required(ErrorMessage = "El campo es requerido.")]
        [Display(Name = "Recargo")]
        public double recargo { get;  set; }
        [Display(Name = "Compras")]
        List<LineasCompra> compras { get; set; }
        [Display(Name = "Ventas")]
        List<LineasVenta> ventas { get; set; }

        [Display(Name = "En Stock")]
        public int Stock { get { return this.stock; } }

        [Display(Name = "Producto")]
        public string Descripcion
        {
            get
            {
                string desc = "";
                var db = new ApplicationDbContext();
                var marca_query = from a in db.Marcas
                            where a.id == this.marcaId
                            select a;
                var categoria_query = from a in db.Categorias
                            where a.id == this.categoriaId
                            select a;
                var talle_query = from a in db.Talles
                            where a.id == this.talleId
                            select a;
                Marca marca = marca_query.First();
                Categoria categoria = categoria_query.First();
                Talle talle = talle_query.First();
                desc = categoria.categoria + " " + marca.Descripcion + " " + talle.Descripcion;
                return desc;
            }
        }

        public void Compra(int cantidad)
        {
            this.stock += cantidad;
        }

        public void Venta(int cantidad)
        {
            this.stock -= cantidad;
        }

        public double Precio { get { return (this.costo * this.recargo); } }

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
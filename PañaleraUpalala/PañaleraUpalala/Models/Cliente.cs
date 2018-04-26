using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PañaleraUpalala.Models
{
    public class Cliente
    {
        public int id { get; set; }
        [Required(ErrorMessage ="El campo es requerido.")]
        [Display(Name = "Nombre")]
        [StringLength(100,ErrorMessage ="No más de 100 caracteres.")]
        public string nombre { get; set; }
        [Display(Name = "Domicilio")]
        [StringLength(300,ErrorMessage ="No más de 300 Caracteres.")]
        public string domicilio { get; set; }
        [Display(Name = "Teléfono")]
        [StringLength(20, ErrorMessage ="No más de 20 caracteres.")]
        public string telefono { get; set; }
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        [StringLength(100, ErrorMessage ="No más de 100 caracteres")]
        public string email { get; set; }
        [Display(Name = "Cuenta")]
        public double cuenta = 0.0;
        [Display(Name = "Ventas")]
        public List<Venta> ventas { get; set; }
        
        public void Debe(double cantidad)
        {
            this.cuenta += cantidad;
        }

        public void Paga(double cantidad)
        {
            this.cuenta -= cantidad;
        }
    }
}
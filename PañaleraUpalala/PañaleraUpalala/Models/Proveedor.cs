using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PañaleraUpalala.Models
{
    public class Proveedor
    {
        public int id { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [StringLength(300)]
        [Display(Name = "Domicilio")]
        public string domicilio { get; set; }
        [StringLength(20)]
        [Display(Name = "Telefono")]
        public string telefono { get; set; }
        [EmailAddress]
        [StringLength(100)]
        [Display(Name = "Correo electrónico")]
        public string email { get; set; }
        [StringLength(80)]
        [Display(Name = "Banco")]
        public string banco { get; set; }
        [StringLength(22)]
        [Display(Name = "CBU")]
        public string cbu { get; set; }
        [Display(Name = "Compras")]
        List<Compra> compras { get; set; }
    }
}
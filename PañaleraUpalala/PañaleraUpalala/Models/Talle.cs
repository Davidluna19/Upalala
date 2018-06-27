using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PañaleraUpalala.Models
{
    public class Talle
    {
        public int id { get; set; }
        [Required(ErrorMessage = "El campo es requerido.")]
        [StringLength(10,ErrorMessage ="No más de 10 caracteres.")]
        [Display(Name = "Talle")]
        public string talle { get; set; }
        [StringLength(150,ErrorMessage ="No más de 150 caracteres.")]
        [Display(Name = "Descripcion")]
        public string descripcion { get; set; }

        //public string Descripcion { get { return this.talle; } }
    }
}
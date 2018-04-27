using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PañaleraUpalala.Models
{
    public class Marca
    {
        public int id { get; set; }
        [Required(ErrorMessage = "El campo es requerido.")]
        [StringLength(50,ErrorMessage ="No más de 50 caracteres.")]
        [Display(Name = "Marca")]
        public string marca { get; set; }
        [StringLength(300,ErrorMessage ="No más de 300 caracteres.")]
        [Display(Name = "Descripcion")]
        public string descripion { get; set; }
        [Display(Name = "Productos")]
        public List<Producto> productos { get; set; }

        public string Descripcion { get { return this.marca; } }
    }
}
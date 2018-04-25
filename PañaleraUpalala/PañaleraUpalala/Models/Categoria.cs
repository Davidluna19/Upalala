using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PañaleraUpalala.Models
{
    public class Categoria
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Categoría")]
        [StringLength(20)]
        public string categoria { get; set; }
        [Display(Name = "Descripción")]
        [StringLength(300)]
        public string descripcion { get; set; }
        [Display(Name = "Productos")]
        public List<Producto> productos { get; set; }
        [Display(Name = "Talles")]
        public List<Talle> talles { get; set; }
    }
}
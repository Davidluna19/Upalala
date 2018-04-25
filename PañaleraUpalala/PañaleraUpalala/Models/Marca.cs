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
        [Required]
        [StringLength(50)]
        [Display(Name = "Marca")]
        public string marca { get; set; }
        [StringLength(300)]
        [Display(Name = "Descripcion")]
        public string descripion { get; set; }
        [Display(Name = "Productos")]
        public List<Producto> productos { get; set; }
    }
}
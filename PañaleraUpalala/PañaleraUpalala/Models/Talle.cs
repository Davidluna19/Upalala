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
        [Required]
        [StringLength(10)]
        [Display(Name = "Talle")]
        public string talle { get; set; }
        [StringLength(150)]
        [Display(Name = "Descripcion")]
        public string descripcion { get; set; }
    }
}
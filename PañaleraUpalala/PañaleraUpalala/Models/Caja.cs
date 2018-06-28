using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PañaleraUpalala.Models
{
    public class Caja
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public int id { get; set; }
        public string descripcion { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha")]
        public DateTime fecha { get; set; }
        public Boolean compra { get; set; }
        [Display(Name = "movimientoID")]
        public int movimientoId { get; set; }
        public double monto { get; set; }
    }
}
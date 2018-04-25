﻿using PañaleraUpalala.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PañaleraUpalala.Models
{
    public class ProductoCreateView
    {
        public int id { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        public IEnumerable<Categoria> categorias { get; set; }
        public IEnumerable<Marca> marcas { get; set; }
        public IEnumerable<Talle> talles { get; set; }
        [Required]
        [Display(Name = "Categoria")]
        public int categoriaId { get; set; }
        [Required]
        [Display(Name = "Marca")]
        public int marcaId { get; set; }
        [Required]
        [Display(Name = "Talle")]
        public int talleId { get; set; }
        [Required]
        [Display(Name = "Costo")]
        public double costo { get; set; }
        [Required]
        [Display(Name = "Recargo")]
        public double recargo { get; set; }
    }
}
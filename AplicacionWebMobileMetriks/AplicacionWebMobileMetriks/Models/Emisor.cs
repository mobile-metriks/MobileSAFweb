﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionWebMobileMetriks.Models
{
    public class Emisor
    {
        public Guid Id { get; set; }
        [Required]
        public string Curp { get; set; }
        [Required]
        public string Calle { get; set; }
        [Required]
        public int NumExterior { get; set; }
        [Required]
        public int NumInterior { get; set; }
        [Required]
        public string Colonia { get; set; }
        [Required]
        public string Localidad { get; set; }
        [Required]
        public string Referencia { get; set; }
        [Required]
        public string Municipio { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        public string Pais { get; set; }
        [Required]
        public int CodigoPostal { get; set; }

        public string Imagen { get; set; }
        //Relacion hacia empresa
        [Display(Name ="Empresa")]
        public Guid EmpresaId { get; set; }
        [ForeignKey("EmpresaId")]
        public virtual Empresa Empresa { get; set; }


    }
}
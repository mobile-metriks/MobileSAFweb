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
        public string RFC { get; set; }
        [Display(Name ="Nombre/Razón Social")]
        [Required]
        public string Nombre { get; set; }
        public string Curp { get; set; }
        public string Calle { get; set; }
        public int NumExterior { get; set; }    
        public int NumInterior { get; set; }       
        public string Colonia { get; set; }
        public string Localidad { get; set; }
        public string Referencia { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        [Required]
        public string Pais { get; set; }
        [Required]
        [Display(Name ="Codigo Postal")]
        public int CodigoPostal { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Correo invalido")]
        public string Correo { get; set; }
        [Required]
        [Phone]
        public string Telefono { get; set; }
        public string Imagen { get; set; }

        //Relacion hacia empresa
        //[Display(Name ="Empresa")]
        //public Guid EmpresaId { get; set; }
        //[ForeignKey("EmpresaId")]
        //public virtual Empresa Empresa { get; set; }


    }
}

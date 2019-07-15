using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionWebMobileMetriks.Models
{
    public class Conceptos
    {
        [Key]
        public int IdConceptos { get; set; }
        [Required]
        public string Identificador { get; set; }
        [Required]
        public string ClaveProdServ { get; set; }
        [Required]
        public string ClaveUnidad { get; set; }
        [Required]
        public double ValorUnitario { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public string Unidad { get; set; }
        public string CuentaPredial { get; set; }

    }
}

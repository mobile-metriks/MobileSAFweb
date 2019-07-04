using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionWebMobileMetriks.Models
{
    public class Receptores
    {
        [Key]
        public int IdReceptor { get; set; }
        [Required]
        public string Identificador { get; set; }
        [Required]
        public string RFC { get; set; }
        [Required]
        public string Cliente { get; set; }
        [Required]
        public string Calle { get; set; }
        public string NumExt { get; set; }
        public string NumInt { get; set; }
        public string Colonia { get; set; }
        public string Localidad { get; set; }
        public string Referencia { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        [Required]
        public long IdPais { get; set; }
        public int CodigoPostal { get; set; }
        [Required]
        public string C_Moneda { get; set; }
        [Required]
        public long IdFormaPago { get; set; }
        [Required]
        public long IdUsoCfdi { get; set; }
        [Display(Name ="Tax ID")]
        public string NumIdRegTrib  { get; set; }
    }
}

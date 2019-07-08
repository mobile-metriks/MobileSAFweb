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
        [Display(Name ="Domicilio")]
        public string Calle { get; set; }
        [Required]
        public long IdPais { get; set; }
        [Required]
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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionWebMobileMetriks.Models
{
    public class Empresa
    {
        [Key]
        public Guid Id { get; set; }
        [Display(Name ="Nombre de empresa")]
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string RFC { get; set; }
        

        //Agrego la llave foranea a mi tabla usuarios

        //Utilizo string para que sea el mismo tipo de variable que identity

        public string UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual UsuarioDeLaAplicacion Usuario { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionWebMobileMetriks.Models
{
    public class Contacto
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [EmailAddress(ErrorMessage = "Correo invalido")]
        public string Correo { get; set; }
        [Phone]
        public string Telefono { get; set; }
        public string Extension { get; set; }
        public string Ubicacion { get; set; }
        //Utilizo int para que sea el mismo tipo de variable que Receptores
        public int ReceptorId { get; set; }
        //Agrego la llave foranea a mi tabla Receptores
        [ForeignKey("ReceptorId")]
        public virtual Receptores Receptores { get; set; }
    }
}

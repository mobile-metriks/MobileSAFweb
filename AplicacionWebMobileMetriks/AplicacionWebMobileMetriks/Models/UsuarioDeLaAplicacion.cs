using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//Creo un modelo que sera una extension de la tabla identity para obtener sus propiedades
namespace AplicacionWebMobileMetriks.Models
{
    public class UsuarioDeLaAplicacion: IdentityUser
    {
        //Agrego las propiedades que quiero anexar a la tabla IdentityUser
        public string Empresa { get; set; }
        public string Nombre { get; set; }
        public string IdAdministrador { get; set; }
    }
}

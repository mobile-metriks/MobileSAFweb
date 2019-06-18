using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionWebMobileMetriks.Utilidad
{
    //Esta clase sirve para que no agregues los strings de manera directa y te evites errores
    public static class SD
    {
        public const string ImagenEmpresaDefault = "default.jpg";
        //Agrego los strings que seran los roles a agregar en mi modelo Register de identity
        public const string UsuarioAdministrador = "Administrador";
        public const string UsuarioRegular = "Usuario";
        public const string ClienteInicial = "Cliente";
    }
}

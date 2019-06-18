using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionWebMobileMetriks.MetodosExtendibles
{
    public static class RefleccionExtension
    {
        //Este metodo obtiene el valor de cualquier propiedad que le pasemos
        public static string ObtenerValorDePropiedad <T> (this T item, string nombrePropiedad)
        {
            return item.GetType().GetProperty(nombrePropiedad).GetValue(item, null).ToString();
        }
    }
}

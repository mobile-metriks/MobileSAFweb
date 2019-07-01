using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionWebMobileMetriks.MetodosExtendibles
{
    //Todos los metodos de extension son static
    public static class IEnumerableExtension
    {
        public static IEnumerable<SelectListItem> ListItemParaSeleccionar<T>(this IEnumerable<T> items, long ValorSeleccionado)
        {
            return from i in items
                   select new SelectListItem
                   {
                       Text = i.ObtenerValorDePropiedad("Nombre"),
                       Value = i.ObtenerValorDePropiedad("Id"),
                       Selected = i.ObtenerValorDePropiedad("Id").Equals(ValorSeleccionado.ToString())
                   };
        }

        
    }
}

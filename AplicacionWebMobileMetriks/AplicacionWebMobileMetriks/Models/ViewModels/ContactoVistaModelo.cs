using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionWebMobileMetriks.Models.ViewModels
{
    public class ContactoVistaModelo
    {
        public IEnumerable<Contacto> ContactoLista { get; set; }
        public Contacto Contacto { get; set; }
        public Receptores Receptores { get; set; }
    }
}

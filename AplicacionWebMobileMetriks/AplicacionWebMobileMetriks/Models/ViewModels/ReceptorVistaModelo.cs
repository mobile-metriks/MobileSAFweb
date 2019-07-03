using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionWebMobileMetriks.Models.ViewModels
{
    public class ReceptorVistaModelo
    {
        public Receptores Receptores { get; set; }
        public IEnumerable<Pais> ListaPais { get; set; }
        public IEnumerable<Moneda> ListaMoneda { get; set; }
        public IEnumerable<FormaPago> ListaFormaPago { get; set; }
        public IEnumerable<UsoCfdi> ListaUsoCfdi { get; set; }
    }
}

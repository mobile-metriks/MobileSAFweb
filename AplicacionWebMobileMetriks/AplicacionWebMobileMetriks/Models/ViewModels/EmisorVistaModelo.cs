using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionWebMobileMetriks.Models.ViewModels
{
    public class EmisorVistaModelo
    {
        public Emisor Emisor { get; set; }
        public IEnumerable<RegimenFiscal> ListaRegimen { get; set; }
        public RegimenEmisor RegimenEmisor { get; set; }
        //Esto es de la lista desplegable
        //public IEnumerable<Empresa> ListaEmpresa { get; set; }
    }
}

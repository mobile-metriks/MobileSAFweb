using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionWebMobileMetriks.Models.ViewModels
{
    public class EmisorVistaModelo
    {
        public Emisor Emisor { get; set; }
        public IEnumerable<Empresa> ListaEmpresa { get; set; }
    }
}

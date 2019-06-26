using System;
using System.Collections.Generic;

namespace AplicacionWebMobileMetriks.Models
{
    public partial class TipoDeComprobante
    {
        public long IdTipoDeComprobante { get; set; }
        public string CTipoDeComprobante { get; set; }
        public string Descripcion { get; set; }
        public bool? EnUso { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace AplicacionWebMobileMetriks.Models
{
    public partial class Impuesto
    {
        public long IdImpuesto { get; set; }
        public string CImpuesto { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public bool? EnUso { get; set; }
    }
}

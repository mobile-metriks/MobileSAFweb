using System;
using System.Collections.Generic;

namespace AplicacionWebMobileMetriks.Models
{
    public partial class MetodoPago
    {
        public long IdMetodoPago { get; set; }
        public string CMetodoPago { get; set; }
        public string Descripcion { get; set; }
        public bool? EnUso { get; set; }
    }
}

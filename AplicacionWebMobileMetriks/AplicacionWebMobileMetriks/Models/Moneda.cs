using System;
using System.Collections.Generic;

namespace AplicacionWebMobileMetriks.Models
{
    public partial class Moneda
    {
        public long IdMoneda { get; set; }
        public string CMoneda { get; set; }
        public string Descripcion { get; set; }
        public int? Decimales { get; set; }
        public string PorcentajeVariacion { get; set; }
        public bool? EnUso { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace AplicacionWebMobileMetriks.Models
{
    public partial class Pais
    {
        public long IdPais { get; set; }
        public string CPais { get; set; }
        public string Descripcion { get; set; }
        public bool? EnUso { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace AplicacionWebMobileMetriks.Models
{
    public partial class UsoCfdi
    {
        public long IdUsoCfdi { get; set; }
        public string CUsoCfdi { get; set; }
        public string Descripcion { get; set; }
        public bool PerFisica { get; set; }
        public bool PerMoral { get; set; }
        public bool? EnUso { get; set; }
    }
}

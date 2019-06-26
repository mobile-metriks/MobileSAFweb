using System;
using System.Collections.Generic;

namespace AplicacionWebMobileMetriks.Models
{
    public partial class CodigoPostal
    {
        public long IdCodigoPostal { get; set; }
        public string CCodigoPostal { get; set; }
        public string CEstado { get; set; }
        public string CMunicipio { get; set; }
        public string CLocalidad { get; set; }
        public bool? EnUso { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace AplicacionWebMobileMetriks.Models
{
    public partial class RegimenFiscal
    {
        public long IdRegimenFiscal { get; set; }
        public string CRegimenFiscal { get; set; }
        public string Descripcion { get; set; }
        public bool PerFisica { get; set; }
        public bool PerMoral { get; set; }
        public bool? EnUso { get; set; }
    }
}

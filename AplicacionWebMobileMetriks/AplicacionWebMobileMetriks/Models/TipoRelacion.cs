using System;
using System.Collections.Generic;

namespace AplicacionWebMobileMetriks.Models
{
    public partial class TipoRelacion
    {
        public long IdTipoRelacion { get; set; }
        public string CTipoRelacion { get; set; }
        public string Descripcion { get; set; }
        public bool? EnUso { get; set; }
    }
}

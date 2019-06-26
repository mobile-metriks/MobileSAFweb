using System;
using System.Collections.Generic;

namespace AplicacionWebMobileMetriks.Models
{
    public partial class FormaPago
    {
        public long IdFormaPago { get; set; }
        public string CFormaPago { get; set; }
        public string Descripcion { get; set; }
        public bool? EnUso { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionWebMobileMetriks.Models
{
    public class RegimenEmisor
    {
        
        public int Id { get; set; }
        [Display(Name = "Regimen Fiscal")]
        public int RegimenFiscalId { get; set; }
    }
}

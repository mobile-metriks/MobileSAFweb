using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplicacionWebMobileMetriks.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AplicacionWebMobileMetriks.Areas.Usuario.Controllers
{
    [Authorize]
    [Area("Usuario")]
    public class ConceptoController : Controller
    {
        private readonly BaseDB _dbBaseDB;
        private readonly CatalogosContext _dbCatalogos;

        public ConceptoController(BaseDB dbBaseDB, CatalogosContext dbCatalogos)
        {
            _dbBaseDB = dbBaseDB;
            _dbCatalogos = dbCatalogos;
        }
        public async Task<IActionResult> Index()
        {
            var Conceptos = await _dbBaseDB.Conceptos.ToListAsync();
            return View(Conceptos);
        }
    }
}
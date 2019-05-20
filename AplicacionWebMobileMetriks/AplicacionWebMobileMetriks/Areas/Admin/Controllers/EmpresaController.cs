using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplicacionWebMobileMetriks.Data;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWebMobileMetriks.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmpresaController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EmpresaController(ApplicationDbContext db)
        {
            this._db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Empresas.ToList());
        }
    }
}
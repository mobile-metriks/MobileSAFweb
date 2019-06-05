using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplicacionWebMobileMetriks.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AplicacionWebMobileMetriks.Areas.Usuario.Controllers
{
    [Authorize]
    [Area("Usuario")]
    public class EmisorController : Controller
    {

        private readonly ApplicationDbContext _db;
        //necesitamos un hosting para guardar la imagen
        private readonly IHostingEnvironment _hosting;

        public EmisorController(ApplicationDbContext db, IHostingEnvironment hosting)
        {
            _db = db;
            _hosting = hosting;
        }
        public async Task<IActionResult> Index()
        {
            var emisorItems = await _db.Emisor.Include(x => x.Empresa).ToListAsync();
            return View(emisorItems);
        }
    }
}
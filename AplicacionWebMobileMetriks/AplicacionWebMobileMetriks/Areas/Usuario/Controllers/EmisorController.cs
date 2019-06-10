using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AplicacionWebMobileMetriks.Data;
using AplicacionWebMobileMetriks.Models.ViewModels;
using AplicacionWebMobileMetriks.Utilidad;
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
        //Get-Crear
        public async Task<IActionResult>  Crear()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (User.IsInRole(SD.UsuarioAdministrador))
            {
                EmisorVistaModelo emisorVistaModeloAdmin = new EmisorVistaModelo()
                {
                    Emisor = new Models.Emisor(),
                    ListaEmpresa = await _db.Empresas.Where(x => x.UsuarioId == userId).ToListAsync(),
                };
                return View(emisorVistaModeloAdmin);
            }
            var Idadmin = await _db.UsuarioDeLaAplicacion.Where(x => x.IdAdministrador != null).Where(x => x.Id == userId).Select(x => x.IdAdministrador).FirstOrDefaultAsync();
            EmisorVistaModelo emisorVistaModeloUsuario = new EmisorVistaModelo()
            {
                Emisor = new Models.Emisor(),
                ListaEmpresa = await _db.Empresas.Where(x => x.UsuarioId == Idadmin).ToListAsync(),
            };

            return View(emisorVistaModeloUsuario);
        } 
    }
}
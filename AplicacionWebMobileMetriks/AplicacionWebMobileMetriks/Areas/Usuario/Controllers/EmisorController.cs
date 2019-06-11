using System;
using System.Collections.Generic;
using System.IO;
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
        
        //Post-Crear
        [HttpPost, ActionName("Crear")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearPost(EmisorVistaModelo emisorVistaModelo)
        {
            if (!ModelState.IsValid)
            {
                return View(emisorVistaModelo);
            }
            _db.Emisor.Add(emisorVistaModelo.Emisor);
            await _db.SaveChangesAsync();
            //Trabajar en la seccion de guardar la imagen
            string webRootPath = _hosting.WebRootPath;
            var archivos = HttpContext.Request.Form.Files;

            var emisorDesdeDb = await _db.Emisor.FindAsync(emisorVistaModelo.Emisor.Id);
            if (archivos.Count() > 0)
            {
                //Los archivos fueron subidos
                var subidos = Path.Combine(webRootPath, "Imagenes");
                var extension = Path.GetExtension(archivos[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(subidos, emisorVistaModelo.Emisor.Id + extension), FileMode.Create))
                {
                    archivos[0].CopyTo(fileStream);
                }

                emisorDesdeDb.Imagen = @"\Imagenes\" + emisorVistaModelo.Emisor.Id + extension;
            }
            else
            {
                //Ningun archivo fue cargado, entonces uso la imagen default
                var subidos = Path.Combine(webRootPath, @"Imagenes\" + SD.ImagenEmpresaDefault);
                System.IO.File.Copy(subidos, webRootPath + @"\Imagenes\" + emisorVistaModelo.Emisor.Id + ".jpg");
                emisorDesdeDb.Imagen = @"\Imagenes\" + emisorVistaModelo.Emisor.Id + ".jpg";
            }
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
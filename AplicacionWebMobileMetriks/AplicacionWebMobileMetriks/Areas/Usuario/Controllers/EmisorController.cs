using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AplicacionWebMobileMetriks.Data;
using AplicacionWebMobileMetriks.Models;
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
        private readonly BaseDB _dbBaseDB;

        public EmisorController(ApplicationDbContext db, IHostingEnvironment hosting, BaseDB dbBaseDB)
        {
            _db = db;
            _hosting = hosting;
            _dbBaseDB = dbBaseDB;
        }
        public async Task<IActionResult> Index()
        {
            var emisorItems = await _dbBaseDB.emisor.ToListAsync();
            return View(emisorItems);
        }
        //Get-Crear
        public IActionResult Crear()
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}
            //var empresa = await _db.Empresas.FindAsync(id);
            
            //if (empresa == null)
            //{
            //    return NotFound();
            //}
            //if (User.IsInRole(SD.UsuarioAdministrador))
            //{
            //EmisorVistaModelo emisorVistaModeloAdmin = new EmisorVistaModelo()
            //{
            //    Emisor = new Models.Emisor(),
                //Empresa = empresa
                //ListaEmpresa = await _db.Empresas.Where(x => x.UsuarioId == userId).ToListAsync(),
            //};
            return View(/*emisorVistaModeloAdmin*/);
            //}
            //var Idadmin = await _db.UsuarioDeLaAplicacion.Where(x => x.IdAdministrador != null).Where(x => x.Id == userId).Select(x => x.IdAdministrador).FirstOrDefaultAsync();
            //EmisorVistaModelo emisorVistaModeloUsuario = new EmisorVistaModelo()
            //{
            //    Emisor = new Models.Emisor(),
            //    //ListaEmpresa = await _db.Empresas.Where(x => x.UsuarioId == Idadmin).ToListAsync(),
            //};

            //return View(emisorVistaModeloUsuario);
        }

        //Post-Crear
        [HttpPost, ActionName("Crear")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearPost(Emisor emisor)
        {
            //Esto lo uso para asignar el valor a la tabla IdEmpresa
            //var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var Idempresa = await _db.Empresas.Where(x => x.Id != null).Where(x => x.UsuarioId == userId).Select(x => x.Id).FirstOrDefaultAsync();
            //emisorVistaModelo.Emisor.IdEmpresa = Idempresa;
            if (!ModelState.IsValid)
            {
                return View(emisor);
            }
            _dbBaseDB.emisor.Add(emisor);
            await _dbBaseDB.SaveChangesAsync();
            //Trabajar en la seccion de guardar la imagen
            string webRootPath = _hosting.WebRootPath;
            var archivos = HttpContext.Request.Form.Files;

            var emisorDesdeDb = await _dbBaseDB.emisor.FindAsync(emisor.Id);
            if (archivos.Count() > 0)
            {
                //Los archivos fueron subidos
                var subidos = Path.Combine(webRootPath, "Imagenes");
                var extension = Path.GetExtension(archivos[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(subidos, emisor.Id + extension), FileMode.Create))
                {
                    archivos[0].CopyTo(fileStream);
                }

                emisorDesdeDb.Imagen = @"\Imagenes\" + emisor.Id + extension;
            }
            else
            {
                //Ningun archivo fue cargado, entonces uso la imagen default
                var subidos = Path.Combine(webRootPath, @"Imagenes\" + SD.ImagenEmpresaDefault);
                System.IO.File.Copy(subidos, webRootPath + @"\Imagenes\" + emisor.Id + ".jpg");
                emisorDesdeDb.Imagen = @"\Imagenes\" + emisor.Id + ".jpg";
            }
            await _dbBaseDB.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
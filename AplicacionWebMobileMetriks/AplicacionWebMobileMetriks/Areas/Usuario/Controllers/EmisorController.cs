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
            var emisorItems = await _dbBaseDB.emisor.FirstOrDefaultAsync();
            return View(emisorItems);
        }
        //Get-Crear
        public IActionResult Crear()
        {
            return View();
        }

        //Post-Crear
        [HttpPost, ActionName("Crear")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearPost(Emisor emisor)
        {
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

        //GET- Editar
        //Tomare el id del elemento seleccionado
        public async Task<IActionResult> Editar(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //Con el id seleccionado ahora la busco en la BD
            var emisor = await _dbBaseDB.emisor.FindAsync(id);
            if (emisor == null)
            {
                return NotFound();
            }
            //Ya que lo encuentra regreso una vista de la empresa seleccionada
            return View(emisor);
        }
        //Post-Crear
        [HttpPost, ActionName("Editar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarPost(Emisor emisor)
        {
            if (!ModelState.IsValid)
            {
                return View(emisor);
            }
            //_dbBaseDB.emisor.Add(emisor);
            //await _dbBaseDB.SaveChangesAsync();
            //Trabajar en la seccion de guardar la nueva imagen
            string webRootPath = _hosting.WebRootPath;
            var archivos = HttpContext.Request.Form.Files;

            var emisorDesdeDb = await _dbBaseDB.emisor.FindAsync(emisor.Id);
            if (archivos.Count() > 0)
            {
                //Una nueva imagen fue cargada
                var subidos = Path.Combine(webRootPath, "Imagenes");
                var nueva_extension = Path.GetExtension(archivos[0].FileName);

                //Borro la imagen anterior
                var imagenPath = Path.Combine(webRootPath, emisorDesdeDb.Imagen.TrimStart('\\'));

                if (System.IO.File.Exists(imagenPath))
                {
                    System.IO.File.Delete(imagenPath);
                }

                using (var fileStream = new FileStream(Path.Combine(subidos, emisor.Id + nueva_extension), FileMode.Create))
                {
                    archivos[0].CopyTo(fileStream);
                }

                emisorDesdeDb.Imagen = @"\Imagenes\" + emisor.Id + nueva_extension;
            }
            //Guardo lo demas que falta
            emisorDesdeDb.RFC = emisor.RFC;
            emisorDesdeDb.Nombre = emisor.Nombre;
            emisorDesdeDb.Calle = emisor.Calle;
            emisorDesdeDb.Colonia = emisor.Colonia;
            emisorDesdeDb.CodigoPostal = emisor.CodigoPostal;
            emisorDesdeDb.Correo = emisor.Correo;
            emisorDesdeDb.Curp = emisor.Curp;
            emisorDesdeDb.Estado = emisor.Estado;
            emisorDesdeDb.Localidad = emisor.Localidad;
            emisorDesdeDb.Municipio = emisor.Municipio;
            emisorDesdeDb.NumExterior = emisor.NumExterior;
            emisorDesdeDb.NumInterior = emisor.NumInterior;
            emisorDesdeDb.Pais = emisor.Pais;
            emisorDesdeDb.Referencia = emisor.Referencia;
            emisorDesdeDb.Telefono = emisor.Telefono;

            await _dbBaseDB.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Post-Editar
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Editar(Emisor emisor)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _dbBaseDB.emisor.Update(emisor);
        //        await _dbBaseDB.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(emisor);
        //}
    }
}
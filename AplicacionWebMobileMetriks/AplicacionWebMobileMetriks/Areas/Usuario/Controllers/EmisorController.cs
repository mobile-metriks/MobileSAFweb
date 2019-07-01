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
        private readonly CatalogosContext _dbCatalogos;

        public EmisorController(ApplicationDbContext db, IHostingEnvironment hosting, BaseDB dbBaseDB, CatalogosContext dbCatalogos)
        {
            _hosting = hosting;
            _db = db;
            _dbBaseDB = dbBaseDB;
            _dbCatalogos = dbCatalogos;
        }
        public async Task<IActionResult> Index()
        {
            var emisorItems = await _dbBaseDB.emisor.FirstOrDefaultAsync();
            return View(emisorItems);
        }
        //Get-Crear
        public async Task<IActionResult> Crear()
        {
            EmisorVistaModelo modelo = new EmisorVistaModelo()
            {
                ListaRegimen = await _dbCatalogos.RegimenFiscal.ToListAsync(),
                RegimenEmisor = new Models.RegimenEmisor(),
                Emisor = new Models.Emisor(),               
            };
            ViewBag.listofitems = modelo.ListaRegimen;
            return View(modelo);
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
            _dbBaseDB.RegimenEmisores.Add(emisorVistaModelo.RegimenEmisor);
            _dbBaseDB.emisor.Add(emisorVistaModelo.Emisor);
            await _dbBaseDB.SaveChangesAsync();
            //Trabajar en la seccion de guardar la imagen
            string webRootPath = _hosting.WebRootPath;
            var archivos = HttpContext.Request.Form.Files;

            var emisorDesdeDb = await _dbBaseDB.emisor.FindAsync(emisorVistaModelo.Emisor.Id);
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
            var emisor = await _dbBaseDB.emisor.SingleOrDefaultAsync(m=>m.Id==id);
            if (emisor == null)
            {
                return NotFound();
            }
            //Ya que lo encuentra regreso una vista de la empresa seleccionada
            EmisorVistaModelo modelo = new EmisorVistaModelo()
            {
                ListaRegimen = await _dbCatalogos.RegimenFiscal.ToListAsync(),
                RegimenEmisor = new Models.RegimenEmisor(),
                Emisor = emisor,
            };
            ViewBag.listofitems = modelo.ListaRegimen;
            return View(modelo);
        }
        //Post-Crear
        [HttpPost, ActionName("Editar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarPost(Guid? id, EmisorVistaModelo emisorVistaModelo)
        {
            if (!ModelState.IsValid)
            {
                EmisorVistaModelo modelo = new EmisorVistaModelo()
                {
                    ListaRegimen = await _dbCatalogos.RegimenFiscal.ToListAsync(),
                    RegimenEmisor = new Models.RegimenEmisor(),
                    Emisor = new Models.Emisor(),
                };
                return View(modelo);
            }
            //_dbBaseDB.emisor.Add(emisor);
            //await _dbBaseDB.SaveChangesAsync();
            //Trabajar en la seccion de guardar la nueva imagen
            string webRootPath = _hosting.WebRootPath;
            var archivos = HttpContext.Request.Form.Files;

            var emisorDesdeDb = await _dbBaseDB.emisor.FindAsync(id);
            var regimenDesdeDb = await _dbBaseDB.RegimenEmisores.FirstOrDefaultAsync();
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

                using (var fileStream = new FileStream(Path.Combine(subidos, emisorVistaModelo.Emisor.Id + nueva_extension), FileMode.Create))
                {
                    archivos[0].CopyTo(fileStream);
                }

                emisorDesdeDb.Imagen = @"\Imagenes\" + emisorVistaModelo.Emisor.Id + nueva_extension;
            }
            //Guardo lo demas que falta
            regimenDesdeDb.RegimenFiscalId = emisorVistaModelo.RegimenEmisor.RegimenFiscalId;
            emisorDesdeDb.RFC = emisorVistaModelo.Emisor.RFC;
            emisorDesdeDb.Nombre = emisorVistaModelo.Emisor.Nombre;
            emisorDesdeDb.Calle = emisorVistaModelo.Emisor.Calle;
            emisorDesdeDb.Colonia = emisorVistaModelo.Emisor.Colonia;
            emisorDesdeDb.CodigoPostal = emisorVistaModelo.Emisor.CodigoPostal;
            emisorDesdeDb.Correo = emisorVistaModelo.Emisor.Correo;
            emisorDesdeDb.Curp = emisorVistaModelo.Emisor.Curp;
            emisorDesdeDb.Estado = emisorVistaModelo.Emisor.Estado;
            emisorDesdeDb.Localidad = emisorVistaModelo.Emisor.Localidad;
            emisorDesdeDb.Municipio = emisorVistaModelo.Emisor.Municipio;
            emisorDesdeDb.NumExterior = emisorVistaModelo.Emisor.NumExterior;
            emisorDesdeDb.NumInterior = emisorVistaModelo.Emisor.NumInterior;
            emisorDesdeDb.Pais = emisorVistaModelo.Emisor.Pais;
            emisorDesdeDb.Referencia = emisorVistaModelo.Emisor.Referencia;
            emisorDesdeDb.Telefono = emisorVistaModelo.Emisor.Telefono;

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
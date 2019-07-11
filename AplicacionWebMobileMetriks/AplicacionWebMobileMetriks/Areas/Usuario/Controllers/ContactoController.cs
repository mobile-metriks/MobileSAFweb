using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplicacionWebMobileMetriks.Data;
using AplicacionWebMobileMetriks.Models;
using AplicacionWebMobileMetriks.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AplicacionWebMobileMetriks.Areas.Usuario.Controllers
{
    [Authorize]
    [Area("Usuario")]
    public class ContactoController : Controller
    {
        private readonly BaseDB _dbBase;

        public ContactoController(BaseDB dbBase)
        {
            _dbBase = dbBase;
        }

        public async Task<IActionResult>  Index(int id)
        {
            var receptorActual = _dbBase.Receptores.Where(x => x.IdReceptor == id).Select(x => x.IdReceptor).FirstOrDefault();
            //contactoVistaModelo.Contacto.ReceptorId = receptorId;
            ContactoVistaModelo modelo = new ContactoVistaModelo()
            {
                ContactoLista = await _dbBase.Contactos.Where(x=>x.ReceptorId==id).ToListAsync(),
                Receptores = new Receptores()
        };
            modelo.Receptores.IdReceptor = receptorActual;
            return View(modelo);

        }
        //Get -Crear Contacto
        public IActionResult Crear(int id)
        {
            var receptorActual = _dbBase.Receptores.Where(x => x.IdReceptor == id).Select(x => x.IdReceptor).FirstOrDefault();
            ContactoVistaModelo modelo = new ContactoVistaModelo()
            {
                Contacto = new Contacto(),
                Receptores = new Receptores()
            };
            modelo.Receptores.IdReceptor = receptorActual;
            return View(modelo);
        }
        //Post - Crear Contacto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(int id,ContactoVistaModelo contactoVistaModelo)
        {
            var receptorId = _dbBase.Receptores.Where(x => x.IdReceptor == id).Select(x=>x.IdReceptor).FirstOrDefault();
            contactoVistaModelo.Contacto.ReceptorId = receptorId;
            if (ModelState.IsValid)
            {
                _dbBase.Add(contactoVistaModelo.Contacto);
                await _dbBase.SaveChangesAsync();
                return RedirectToAction("Index", new {id=receptorId });
            }
            ContactoVistaModelo modelo = new ContactoVistaModelo()
            {
                Contacto = new Contacto(),
                Receptores = new Receptores()
            };
            return View(modelo);
        }
    }
}
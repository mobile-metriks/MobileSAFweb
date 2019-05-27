using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AplicacionWebMobileMetriks.Data;
using AplicacionWebMobileMetriks.Models;
using AplicacionWebMobileMetriks.Utilidad;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AplicacionWebMobileMetriks.Areas.Admin.Controllers
{
    //Defino que roles tendran autorizacion a esta area
    [Authorize]
    [Area("Admin")]

    public class EmpresaController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EmpresaController(ApplicationDbContext db)
        {
            this._db = db;
        }
        //GET-Index
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (User.IsInRole(SD.UsuarioAdministrador))
            {
                //Hago que regrese la lista de empresas donde el UsuarioId sea igual al Id del usuario actual
                return View(await _db.Empresas.Where(x => x.UsuarioId == userId).ToListAsync());
            }
            return View(await _db.Empresas.ToListAsync());
               
        }
        [Authorize(Roles =SD.UsuarioAdministrador)]
        //GET - Crear
        public IActionResult Crear()
        {
            return View();
        }
        //POST - Crear
        //Declaro que utiliza el metodo post
        [HttpPost]
        //Declaro para cuestiones de seguridad
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Empresa empresa)
        {
            //Aqui asigne que al crear lo primero que haga sea asignar el valor del id de usuarios al id de UsuariosId de empresas
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            empresa.UsuarioId = userId;
            //Checo si mi modelo es valido-correcto
            if (ModelState.IsValid)
            {
                _db.Empresas.Add(empresa);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //Si no es valido lo regreso a la misma vista
            return View(empresa);
        }
        //Metodo para obtener e

        //GET- Editar
        //Tomare el id del elemento seleccionado
        public async Task<IActionResult> Editar(Guid? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            //Con el id seleccionado ahora la busco en la BD
            var empresa = await _db.Empresas.FindAsync(id);
            if (empresa==null)
            {
                return NotFound();
            }
            //Ya que lo encuentra regreso una vista de la empresa seleccionada
            return View(empresa);
        }

        //Post-Editar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar( Empresa empresa)
        {
            //Aqui asigne que al crear lo primero que haga sea asignar el valor del id de usuarios al id de UsuariosId de empresas
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            empresa.UsuarioId = userId;
            if (ModelState.IsValid)
            {
                _db.Empresas.Update(empresa);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empresa);
        }

        //Get-Borrar
        public async Task<IActionResult> Borrar(Guid? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var empresa = await _db.Empresas.FindAsync(id);
            if (empresa==null)
            {
                return NotFound();
            }
            return View(empresa);
        }
        //Post-Borrar
        //El metodo no se debe llamar exactamente igual que el metodo get-borrar por lo que mejor se pone aparte
        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>BorrarConfirmar(Guid? id)
        {
            var empresa = await _db.Empresas.FindAsync(id);
            if (empresa==null)
            {
                return View(nameof(Index));
            }
            //Ya que encuentro la empresa que seleccione en la BD la remuevo
            _db.Empresas.Remove(empresa);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //Get-Detalles
        public async Task<IActionResult> Detalles(Guid id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var empresa = await _db.Empresas.FindAsync(id);
            if (empresa==null)
            {
                return NotFound();
            }
            return View(empresa);
        }


    }
}
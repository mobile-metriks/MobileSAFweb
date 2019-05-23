using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AplicacionWebMobileMetriks.Data;
using AplicacionWebMobileMetriks.Utilidad;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AplicacionWebMobileMetriks.Areas.Admin.Controllers
{
    //Defino que roles tendran autorizacion a esta area
    [Authorize(Roles = SD.UsuarioAdministrador)]
    //Primero defino el area
    [Area("Admin")]
    public class UsuarioController : Controller
    {
        private readonly ApplicationDbContext _db;

        //Le agrego inyeccion de dependecias para usar los elementos de la BD
        public UsuarioController(ApplicationDbContext db)
        {
            _db = db;
        }
        //Cambio mi metodo(accion) a que sea asincrono
        public async Task <IActionResult> Index()
        {
            //Quiero retornar una lista de todos los usuarios excepto el usuario actual que esta conectado, 
            //para eso necesito el Id del usuario actual en ASP.NET core lo puedo obtener usando la libreria "Claims"= pedir,reclamar,etc.
            var pedirIdentidad= (ClaimsIdentity)this.User.Identity;
            var pedir = pedirIdentidad.FindFirst(ClaimTypes.NameIdentifier);
            //Ya que obtuve mi usuario actual ahora lo comparo que el Id de usuario no debe ser igual
            //a el Id usuario actual que guarde en mi variable "pedir" y lo muestro en forma de lista
            return View(await _db.UsuarioDeLaAplicacion.Where(u=>u.Id != pedir.Value).ToListAsync());
            
            //return View(await _db.UsuarioDeLaAplicacion.Where(u => u.Id != pedir.Value).Where(x => x.UsuarioId == pedir.Value).ToListAsync());
        }
        //Metodo (accion) para bloquear a un usuario siendo administrador
        public async Task <IActionResult> Bloquear(string id)
        {
            //Si no encuentra el id retorna error
            if (id==null)
            {
                return NotFound();
            }
            //guardo en mi variable el usuario que selecciono en base al id de mi BD
            var usuarioDeLaAplicacion = await _db.UsuarioDeLaAplicacion.FirstOrDefaultAsync(m => m.Id == id);
            //Si no lo encuentra en la BD retorna error
            if (usuarioDeLaAplicacion==null)
            {
                return NotFound();
            }
            //Si lo encuentra aplico la propiedad Lockout y lo bloqueo por "n" años poniendolo como valor
            usuarioDeLaAplicacion.LockoutEnd = DateTime.Now.AddYears(1000);

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
        //Metodo (accion) para desbloquear a un usuario siendo administrador
        public async Task<IActionResult> Desbloquear(string id)
        {
            //Si no encuentra el id retorna error
            if (id == null)
            {
                return NotFound();
            }
            //guardo en mi variable el usuario que selecciono en base al id de mi BD
            var usuarioDeLaAplicacion = await _db.UsuarioDeLaAplicacion.FirstOrDefaultAsync(m => m.Id == id);
            //Si no lo encuentra en la BD retorna error
            if (usuarioDeLaAplicacion == null)
            {
                return NotFound();
            }
            //Si lo encuentra aplico la propiedad Lockout lo regreso a la fecha actual.
            usuarioDeLaAplicacion.LockoutEnd = DateTime.Now;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AplicacionWebMobileMetriks.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AplicacionWebMobileMetriks.Areas.Admin.Controllers
{
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
        //Cambio mi metodo a que sea asincrono
        public async Task <IActionResult> Index()
        {
            //Quiero retornar una lista de todos los usuarios excepto el usuario actual que esta conectado, 
            //para eso necesito el Id del usuario actual en ASP.NET core lo puedo obtener usando la libreria "Claims"= pedir,reclamar,etc.
            var pedirIdentidad= (ClaimsIdentity)this.User.Identity;
            var pedir = pedirIdentidad.FindFirst(ClaimTypes.NameIdentifier);
            //Ya que obtuve mi usuario actual ahora lo comparo que el Id de usuario no debe ser igual
            //a el Id usuario actual que guarde en mi variable "pedir" y lo muestro en forma de lista
            return View(await _db.UsuarioDeLaAplicacion.Where(u=>u.Id != pedir.Value).ToListAsync());
        }
    }
}
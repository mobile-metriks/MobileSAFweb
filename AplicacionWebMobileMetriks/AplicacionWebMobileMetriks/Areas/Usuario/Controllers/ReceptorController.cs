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
    public class ReceptorController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly BaseDB _dbBaseDB;
        private readonly CatalogosContext _dbCatalogos;
        public ReceptorController(ApplicationDbContext db, BaseDB dbBaseDB, CatalogosContext dbCatalogos)
        {         
            _db = db;
            _dbBaseDB = dbBaseDB;
            _dbCatalogos = dbCatalogos;
        }
        public async Task<IActionResult>  Index()
        {
            var receptores = await _dbBaseDB.Receptores.ToListAsync();
            return View(receptores);
        }
        //Get-Crear Receptor
        public async Task<IActionResult> CrearReceptor()
        {
            ReceptorVistaModelo modelo = new ReceptorVistaModelo()
            {
                Receptores = new Receptores(),
                ListaFormaPago = await _dbCatalogos.FormaPago.ToListAsync(),
                ListaMoneda = await _dbCatalogos.Moneda.OrderBy(x => x.Descripcion).ToListAsync(),
                ListaPais = await _dbCatalogos.Pais.ToListAsync(),
                ListaUsoCfdi = await _dbCatalogos.UsoCfdi.ToListAsync()
            };
            ViewBag.listofitemsMoneda = modelo.ListaMoneda;
            ViewBag.listofitemsFormaPago = modelo.ListaFormaPago;
            ViewBag.listofitemsPais = modelo.ListaPais;
            ViewBag.listofitemsUsoCfdi = modelo.ListaUsoCfdi;
            return View(modelo);
        }

        //Post- Crear Receptor
        [HttpPost, ActionName("CrearReceptor")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearReceptor(ReceptorVistaModelo receptorVistaModelo)
        {
            if (!ModelState.IsValid)
            {
                ReceptorVistaModelo modelo = new ReceptorVistaModelo()
                {
                    Receptores = new Receptores(),
                    ListaFormaPago = await _dbCatalogos.FormaPago.ToListAsync(),
                    ListaMoneda = await _dbCatalogos.Moneda.OrderBy(x => x.Descripcion).ToListAsync(),
                    ListaPais = await _dbCatalogos.Pais.ToListAsync(),
                    ListaUsoCfdi = await _dbCatalogos.UsoCfdi.ToListAsync()
                };
                ViewBag.listofitemsMoneda = modelo.ListaMoneda;
                ViewBag.listofitemsFormaPago = modelo.ListaFormaPago;
                ViewBag.listofitemsPais = modelo.ListaPais;
                ViewBag.listofitemsUsoCfdi = modelo.ListaUsoCfdi;
                return View(modelo);
            }
            _dbBaseDB.Receptores.Add(receptorVistaModelo.Receptores);
            await _dbBaseDB.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //Get-Editar Receptor
        public async Task<IActionResult> Editar(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var receptor = await _dbBaseDB.Receptores.SingleOrDefaultAsync(m=>m.IdReceptor==id);
            if (receptor==null)
            {
                return NotFound();
            }
            ReceptorVistaModelo modelo = new ReceptorVistaModelo()
            {
                Receptores = receptor,
                ListaFormaPago = await _dbCatalogos.FormaPago.ToListAsync(),
                ListaMoneda = await _dbCatalogos.Moneda.OrderBy(x => x.Descripcion).ToListAsync(),
                ListaPais = await _dbCatalogos.Pais.ToListAsync(),
                ListaUsoCfdi = await _dbCatalogos.UsoCfdi.ToListAsync()
            };
            ViewBag.listofitemsMoneda = modelo.ListaMoneda;
            ViewBag.listofitemsFormaPago = modelo.ListaFormaPago;
            ViewBag.listofitemsPais = modelo.ListaPais;
            ViewBag.listofitemsUsoCfdi = modelo.ListaUsoCfdi;
            return View(modelo);
        }
        //Post-Editar Receptor
        [HttpPost, ActionName("Editar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarReceptor(int? id, ReceptorVistaModelo receptorVistaModelo)
        {
            if (id==null)
            {
                return NotFound();
            }
            var receptorDesdeBD = await _dbBaseDB.Receptores.FindAsync(id);
            if (receptorDesdeBD==null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                ReceptorVistaModelo modelo = new ReceptorVistaModelo()
                {
                    Receptores = receptorDesdeBD,
                    ListaFormaPago = await _dbCatalogos.FormaPago.ToListAsync(),
                    ListaMoneda = await _dbCatalogos.Moneda.OrderBy(x => x.Descripcion).ToListAsync(),
                    ListaPais = await _dbCatalogos.Pais.ToListAsync(),
                    ListaUsoCfdi = await _dbCatalogos.UsoCfdi.ToListAsync()
                };
                ViewBag.listofitemsMoneda = modelo.ListaMoneda;
                ViewBag.listofitemsFormaPago = modelo.ListaFormaPago;
                ViewBag.listofitemsPais = modelo.ListaPais;
                ViewBag.listofitemsUsoCfdi = modelo.ListaUsoCfdi;
                return View(modelo);
            }
            receptorDesdeBD.Identificador = receptorVistaModelo.Receptores.Identificador;
            receptorDesdeBD.RFC = receptorVistaModelo.Receptores.RFC;
            receptorDesdeBD.Cliente = receptorVistaModelo.Receptores.Cliente;
            receptorDesdeBD.Calle = receptorVistaModelo.Receptores.Calle;
            receptorDesdeBD.CodigoPostal = receptorVistaModelo.Receptores.CodigoPostal;
            receptorDesdeBD.C_Moneda = receptorVistaModelo.Receptores.C_Moneda;
            receptorDesdeBD.IdFormaPago = receptorVistaModelo.Receptores.IdFormaPago;
            receptorDesdeBD.IdPais = receptorVistaModelo.Receptores.IdPais;
            receptorDesdeBD.IdUsoCfdi = receptorVistaModelo.Receptores.IdUsoCfdi;
            receptorDesdeBD.NumIdRegTrib = receptorVistaModelo.Receptores.NumIdRegTrib;
            await _dbBaseDB.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Get-Detalles Receptore
        public async Task<IActionResult> Detalles(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var receptor = await _dbBaseDB.Receptores.FindAsync(id);
            if (receptor==null)
            {
                return NotFound();
            }
            ReceptorVistaModelo modelo = new ReceptorVistaModelo()
            {
                Receptores = receptor,
                ListaFormaPago = await _dbCatalogos.FormaPago.ToListAsync(),
                ListaMoneda = await _dbCatalogos.Moneda.OrderBy(x => x.Descripcion).ToListAsync(),
                ListaPais = await _dbCatalogos.Pais.ToListAsync(),
                ListaUsoCfdi = await _dbCatalogos.UsoCfdi.ToListAsync()
            };
            ViewBag.listofitemsMoneda = modelo.ListaMoneda;
            ViewBag.listofitemsFormaPago = modelo.ListaFormaPago;
            ViewBag.listofitemsPais = modelo.ListaPais;
            ViewBag.listofitemsUsoCfdi = modelo.ListaUsoCfdi;
            return View(modelo);
        }
        //public async Task<List<ReceptorVistaModelo>>  DetallesAjax(int id)
        //{
        //    List<ReceptorVistaModelo> modelo = new List<ReceptorVistaModelo>();        
        //    return modelo.Where(x=>x.Receptores.IdReceptor==id).ToList();
        //}

    }
}
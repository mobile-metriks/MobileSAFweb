﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplicacionWebMobileMetriks.Data;
using AplicacionWebMobileMetriks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AplicacionWebMobileMetriks.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmpresaController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EmpresaController(ApplicationDbContext db)
        {
            this._db = db;
        }
        //GET
        public async Task <IActionResult> Index()
        {
            return View(await _db.Empresas.ToListAsync());
        }
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
    }
}
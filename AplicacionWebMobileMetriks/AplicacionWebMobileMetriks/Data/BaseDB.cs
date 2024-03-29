﻿using AplicacionWebMobileMetriks.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionWebMobileMetriks.Data
{
    public class BaseDB:DbContext
    {
        public BaseDB(DbContextOptions<BaseDB> opciones)
            :base(opciones)
        {   
        }
        public DbSet<Emisor> emisor { get; set; }
        public DbSet <RegimenEmisor> RegimenEmisores { get; set; }
        public DbSet<Receptores> Receptores { get; set; }
        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<Conceptos> Conceptos { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using AplicacionWebMobileMetriks.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AplicacionWebMobileMetriks.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //Agrego DbSet para que me cree la tabla en la BD

        //En esta propiedad los agregara a mi tabla AspNetUser puesto que el proposito de ese modelo es ser un anexo a esa tabla en la BD
        public DbSet<UsuarioDeLaAplicacion> UsuarioDeLaAplicacion { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
    }
}

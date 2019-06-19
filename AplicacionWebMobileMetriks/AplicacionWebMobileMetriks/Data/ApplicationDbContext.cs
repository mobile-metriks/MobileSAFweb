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
        //public DbSet<UsuariosEmpresas> usuariosEmpresas { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {

            
            base.OnModelCreating(builder);
            //Esta es el fluent API de mi relacion de MtoM
            //builder.Entity<UsuariosEmpresas>()
            //    .HasKey(e => new { e.usuarioId, e.empresaId });
            //builder.Entity<UsuariosEmpresas>()
            //    .HasOne(e => e.usuario).WithMany(e => e.UsuariosEmpresas).HasForeignKey(e => e.usuarioId)
            //    .OnDelete(DeleteBehavior.Restrict);
            //builder.Entity<UsuariosEmpresas>()
            //  .HasOne(e => e.empresa).WithMany(e => e.UsuariosEmpresas).HasForeignKey(e => e.empresaId)
            //  .OnDelete(DeleteBehavior.Restrict);

            //Esta es el fluent API de mi relacion self join
            builder.Entity<UsuarioDeLaAplicacion>().HasOne(u => u.Administrador).WithMany().HasForeignKey(u => u.IdAdministrador);


        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AplicacionWebMobileMetriks.Models
{
    public partial class CatalogosContext : DbContext
    {
        public CatalogosContext()
        {
        }

        public CatalogosContext(DbContextOptions<CatalogosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClaveProdServ> ClaveProdServ { get; set; }
        public virtual DbSet<ClaveUnidad> ClaveUnidad { get; set; }
        public virtual DbSet<CodigoPostal> CodigoPostal { get; set; }
        public virtual DbSet<FormaPago> FormaPago { get; set; }
        public virtual DbSet<Impuesto> Impuesto { get; set; }
        public virtual DbSet<MetodoPago> MetodoPago { get; set; }
        public virtual DbSet<Moneda> Moneda { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<RegimenFiscal> RegimenFiscal { get; set; }
        public virtual DbSet<TipoDeComprobante> TipoDeComprobante { get; set; }
        public virtual DbSet<TipoFactor> TipoFactor { get; set; }
        public virtual DbSet<TipoRelacion> TipoRelacion { get; set; }
        public virtual DbSet<UsoCfdi> UsoCfdi { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Catalogos;Trusted_Connection=True;MultipleActiveResultSets=true");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<ClaveProdServ>(entity =>
            {
                entity.HasKey(e => e.CClaveProdServ);

                entity.Property(e => e.CClaveProdServ)
                    .HasColumnName("c_ClaveProdServ")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EnUso)
                    .IsRequired()
                    .HasDefaultValueSql("('FALSE')");
            });

            modelBuilder.Entity<ClaveUnidad>(entity =>
            {
                entity.HasKey(e => e.CClaveUnidad);

                entity.Property(e => e.CClaveUnidad)
                    .HasColumnName("c_ClaveUnidad")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.EnUso)
                    .IsRequired()
                    .HasDefaultValueSql("('FALSE')");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CodigoPostal>(entity =>
            {
                entity.HasKey(e => e.IdCodigoPostal);

                entity.Property(e => e.IdCodigoPostal).HasColumnName("idCodigoPostal");

                entity.Property(e => e.CCodigoPostal)
                    .IsRequired()
                    .HasColumnName("c_CodigoPostal")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CEstado)
                    .IsRequired()
                    .HasColumnName("c_Estado")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CLocalidad)
                    .HasColumnName("c_Localidad")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CMunicipio)
                    .HasColumnName("c_Municipio")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EnUso)
                    .IsRequired()
                    .HasDefaultValueSql("('FALSE')");
            });

            modelBuilder.Entity<FormaPago>(entity =>
            {
                entity.HasKey(e => e.IdFormaPago);

                entity.Property(e => e.IdFormaPago).HasColumnName("idFormaPago");

                entity.Property(e => e.CFormaPago)
                    .IsRequired()
                    .HasColumnName("c_FormaPago")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.EnUso)
                    .IsRequired()
                    .HasDefaultValueSql("('FALSE')");
            });

            modelBuilder.Entity<Impuesto>(entity =>
            {
                entity.HasKey(e => e.IdImpuesto);

                entity.Property(e => e.IdImpuesto).HasColumnName("idImpuesto");

                entity.Property(e => e.CImpuesto)
                    .IsRequired()
                    .HasColumnName("c_Impuesto")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EnUso)
                    .IsRequired()
                    .HasDefaultValueSql("('FALSE')");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MetodoPago>(entity =>
            {
                entity.HasKey(e => e.IdMetodoPago);

                entity.Property(e => e.IdMetodoPago).HasColumnName("idMetodoPago");

                entity.Property(e => e.CMetodoPago)
                    .IsRequired()
                    .HasColumnName("c_MetodoPago")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.EnUso)
                    .IsRequired()
                    .HasDefaultValueSql("('FALSE')");
            });

            modelBuilder.Entity<Moneda>(entity =>
            {
                entity.HasKey(e => e.IdMoneda)
                    .HasName("PK_Moneda_1");

                entity.Property(e => e.IdMoneda).HasColumnName("idMoneda");

                entity.Property(e => e.CMoneda)
                    .IsRequired()
                    .HasColumnName("c_Moneda")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.EnUso)
                    .IsRequired()
                    .HasDefaultValueSql("('FALSE')");

                entity.Property(e => e.PorcentajeVariacion).HasMaxLength(20);
            });

            modelBuilder.Entity<Pais>(entity =>
            {
                entity.HasKey(e => e.IdPais);

                entity.Property(e => e.IdPais).HasColumnName("idPais");

                entity.Property(e => e.CPais)
                    .IsRequired()
                    .HasColumnName("c_Pais")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.EnUso)
                    .IsRequired()
                    .HasDefaultValueSql("('FALSE')");
            });

            modelBuilder.Entity<RegimenFiscal>(entity =>
            {
                entity.HasKey(e => e.IdRegimenFiscal);

                entity.Property(e => e.IdRegimenFiscal).HasColumnName("idRegimenFiscal");

                entity.Property(e => e.CRegimenFiscal)
                    .IsRequired()
                    .HasColumnName("c_RegimenFiscal")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EnUso)
                    .IsRequired()
                    .HasDefaultValueSql("('FALSE')");
            });

            modelBuilder.Entity<TipoDeComprobante>(entity =>
            {
                entity.HasKey(e => e.IdTipoDeComprobante);

                entity.Property(e => e.IdTipoDeComprobante).HasColumnName("idTipoDeComprobante");

                entity.Property(e => e.CTipoDeComprobante)
                    .IsRequired()
                    .HasColumnName("c_TipoDeComprobante")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EnUso)
                    .IsRequired()
                    .HasDefaultValueSql("('FALSE')");
            });

            modelBuilder.Entity<TipoFactor>(entity =>
            {
                entity.HasKey(e => e.IdTipoFactor);

                entity.Property(e => e.IdTipoFactor).HasColumnName("idTipoFactor");

                entity.Property(e => e.CTipoFactor)
                    .IsRequired()
                    .HasColumnName("c_TipoFactor")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EnUso)
                    .IsRequired()
                    .HasDefaultValueSql("('FALSE')");
            });

            modelBuilder.Entity<TipoRelacion>(entity =>
            {
                entity.HasKey(e => e.IdTipoRelacion);

                entity.Property(e => e.IdTipoRelacion).HasColumnName("idTipoRelacion");

                entity.Property(e => e.CTipoRelacion)
                    .IsRequired()
                    .HasColumnName("c_TipoRelacion")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.EnUso)
                    .IsRequired()
                    .HasDefaultValueSql("('FALSE')");
            });

            modelBuilder.Entity<UsoCfdi>(entity =>
            {
                entity.HasKey(e => e.IdUsoCfdi);

                entity.ToTable("UsoCFDI");

                entity.Property(e => e.IdUsoCfdi).HasColumnName("idUsoCFDI");

                entity.Property(e => e.CUsoCfdi)
                    .IsRequired()
                    .HasColumnName("c_UsoCFDI")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.EnUso)
                    .IsRequired()
                    .HasDefaultValueSql("('FALSE')");
            });
        }
    }
}

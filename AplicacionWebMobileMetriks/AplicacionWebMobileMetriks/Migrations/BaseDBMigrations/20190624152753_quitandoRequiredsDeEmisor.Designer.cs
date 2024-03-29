﻿// <auto-generated />
using System;
using AplicacionWebMobileMetriks.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AplicacionWebMobileMetriks.Migrations.BaseDBMigrations
{
    [DbContext(typeof(BaseDB))]
    [Migration("20190624152753_quitandoRequiredsDeEmisor")]
    partial class quitandoRequiredsDeEmisor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AplicacionWebMobileMetriks.Models.Emisor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Calle")
                        .IsRequired();

                    b.Property<int>("CodigoPostal");

                    b.Property<string>("Colonia")
                        .IsRequired();

                    b.Property<string>("Correo")
                        .IsRequired();

                    b.Property<string>("Curp")
                        .IsRequired();

                    b.Property<string>("Estado")
                        .IsRequired();

                    b.Property<string>("Imagen");

                    b.Property<string>("Localidad");

                    b.Property<string>("Municipio")
                        .IsRequired();

                    b.Property<string>("Nombre");

                    b.Property<int>("NumExterior");

                    b.Property<int>("NumInterior");

                    b.Property<string>("Pais")
                        .IsRequired();

                    b.Property<string>("RFC");

                    b.Property<string>("Referencia");

                    b.Property<string>("Telefono")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("emisor");
                });
#pragma warning restore 612, 618
        }
    }
}

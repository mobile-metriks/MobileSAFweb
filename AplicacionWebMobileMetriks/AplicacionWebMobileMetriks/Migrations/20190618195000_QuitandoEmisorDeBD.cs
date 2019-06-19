using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AplicacionWebMobileMetriks.Migrations
{
    public partial class QuitandoEmisorDeBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emisor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emisor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Calle = table.Column<string>(nullable: false),
                    CodigoPostal = table.Column<int>(nullable: false),
                    Colonia = table.Column<string>(nullable: false),
                    Correo = table.Column<string>(nullable: false),
                    Curp = table.Column<string>(nullable: false),
                    EmpresaId = table.Column<Guid>(nullable: false),
                    Estado = table.Column<string>(nullable: false),
                    Imagen = table.Column<string>(nullable: true),
                    Localidad = table.Column<string>(nullable: true),
                    Municipio = table.Column<string>(nullable: false),
                    NumExterior = table.Column<int>(nullable: false),
                    NumInterior = table.Column<int>(nullable: false),
                    Pais = table.Column<string>(nullable: false),
                    Referencia = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emisor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emisor_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emisor_EmpresaId",
                table: "Emisor",
                column: "EmpresaId");
        }
    }
}

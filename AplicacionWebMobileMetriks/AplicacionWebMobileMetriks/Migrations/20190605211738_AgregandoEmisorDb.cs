using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AplicacionWebMobileMetriks.Migrations
{
    public partial class AgregandoEmisorDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emisor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Curp = table.Column<string>(nullable: false),
                    Calle = table.Column<string>(nullable: false),
                    NumExterior = table.Column<int>(nullable: false),
                    NumInterior = table.Column<int>(nullable: false),
                    Colonia = table.Column<string>(nullable: false),
                    Localidad = table.Column<string>(nullable: false),
                    Referencia = table.Column<string>(nullable: false),
                    Municipio = table.Column<string>(nullable: false),
                    Estado = table.Column<string>(nullable: false),
                    Pais = table.Column<string>(nullable: false),
                    CodigoPostal = table.Column<int>(nullable: false),
                    Imagen = table.Column<string>(nullable: true),
                    EmpresaId = table.Column<Guid>(nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emisor");
        }
    }
}

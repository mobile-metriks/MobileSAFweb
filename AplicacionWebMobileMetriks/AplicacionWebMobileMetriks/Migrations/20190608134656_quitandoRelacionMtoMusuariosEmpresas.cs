using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AplicacionWebMobileMetriks.Migrations
{
    public partial class quitandoRelacionMtoMusuariosEmpresas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usuariosEmpresas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuariosEmpresas",
                columns: table => new
                {
                    usuarioId = table.Column<string>(nullable: false),
                    empresaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuariosEmpresas", x => new { x.usuarioId, x.empresaId });
                    table.ForeignKey(
                        name: "FK_usuariosEmpresas_Empresas_empresaId",
                        column: x => x.empresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_usuariosEmpresas_AspNetUsers_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_usuariosEmpresas_empresaId",
                table: "usuariosEmpresas",
                column: "empresaId");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace AplicacionWebMobileMetriks.Migrations
{
    public partial class Cambiooo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosEmpresas_Empresas_empresaId",
                table: "UsuariosEmpresas");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosEmpresas_AspNetUsers_usuarioId",
                table: "UsuariosEmpresas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuariosEmpresas",
                table: "UsuariosEmpresas");

            migrationBuilder.RenameTable(
                name: "UsuariosEmpresas",
                newName: "usuariosEmpresas");

            migrationBuilder.RenameIndex(
                name: "IX_UsuariosEmpresas_empresaId",
                table: "usuariosEmpresas",
                newName: "IX_usuariosEmpresas_empresaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuariosEmpresas",
                table: "usuariosEmpresas",
                columns: new[] { "usuarioId", "empresaId" });

            migrationBuilder.AddForeignKey(
                name: "FK_usuariosEmpresas_Empresas_empresaId",
                table: "usuariosEmpresas",
                column: "empresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_usuariosEmpresas_AspNetUsers_usuarioId",
                table: "usuariosEmpresas",
                column: "usuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuariosEmpresas_Empresas_empresaId",
                table: "usuariosEmpresas");

            migrationBuilder.DropForeignKey(
                name: "FK_usuariosEmpresas_AspNetUsers_usuarioId",
                table: "usuariosEmpresas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuariosEmpresas",
                table: "usuariosEmpresas");

            migrationBuilder.RenameTable(
                name: "usuariosEmpresas",
                newName: "UsuariosEmpresas");

            migrationBuilder.RenameIndex(
                name: "IX_usuariosEmpresas_empresaId",
                table: "UsuariosEmpresas",
                newName: "IX_UsuariosEmpresas_empresaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuariosEmpresas",
                table: "UsuariosEmpresas",
                columns: new[] { "usuarioId", "empresaId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosEmpresas_Empresas_empresaId",
                table: "UsuariosEmpresas",
                column: "empresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosEmpresas_AspNetUsers_usuarioId",
                table: "UsuariosEmpresas",
                column: "usuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

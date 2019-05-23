using Microsoft.EntityFrameworkCore.Migrations;

namespace AplicacionWebMobileMetriks.Data.Migrations
{
    public partial class AgregandoFKdeUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Empresas",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_UsuarioId",
                table: "Empresas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_AspNetUsers_UsuarioId",
                table: "Empresas",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_AspNetUsers_UsuarioId",
                table: "Empresas");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_UsuarioId",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Empresas");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace AplicacionWebMobileMetriks.Data.Migrations
{
    public partial class QuitandoRequiredDeUsuarioId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_AspNetUsers_UsuarioId",
                table: "Empresas");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Empresas",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_AspNetUsers_UsuarioId",
                table: "Empresas",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_AspNetUsers_UsuarioId",
                table: "Empresas");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Empresas",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_AspNetUsers_UsuarioId",
                table: "Empresas",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

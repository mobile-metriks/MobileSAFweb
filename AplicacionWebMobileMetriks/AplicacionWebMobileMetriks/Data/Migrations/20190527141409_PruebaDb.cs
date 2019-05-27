using Microsoft.EntityFrameworkCore.Migrations;

namespace AplicacionWebMobileMetriks.Data.Migrations
{
    public partial class PruebaDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdUsuarioRegular",
                table: "AspNetUsers",
                newName: "IdAdministrador");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdAdministrador",
                table: "AspNetUsers",
                newName: "IdUsuarioRegular");
        }
    }
}

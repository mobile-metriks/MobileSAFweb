using Microsoft.EntityFrameworkCore.Migrations;

namespace AplicacionWebMobileMetriks.Data.Migrations
{
    public partial class AgregandoAdminId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdAdmin",
                table: "AspNetUsers",
                newName: "AdminId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdminId",
                table: "AspNetUsers",
                newName: "IdAdmin");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace AplicacionWebMobileMetriks.Migrations.BaseDBMigrations
{
    public partial class quitandoRequiredsDeEmisor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RFC",
                table: "emisor",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "emisor",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RFC",
                table: "emisor",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "emisor",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

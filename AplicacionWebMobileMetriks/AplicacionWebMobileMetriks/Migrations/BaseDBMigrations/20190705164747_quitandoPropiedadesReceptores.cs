using Microsoft.EntityFrameworkCore.Migrations;

namespace AplicacionWebMobileMetriks.Migrations.BaseDBMigrations
{
    public partial class quitandoPropiedadesReceptores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Colonia",
                table: "Receptores");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Receptores");

            migrationBuilder.DropColumn(
                name: "Localidad",
                table: "Receptores");

            migrationBuilder.DropColumn(
                name: "Municipio",
                table: "Receptores");

            migrationBuilder.DropColumn(
                name: "NumExt",
                table: "Receptores");

            migrationBuilder.DropColumn(
                name: "NumInt",
                table: "Receptores");

            migrationBuilder.DropColumn(
                name: "Referencia",
                table: "Receptores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Colonia",
                table: "Receptores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Receptores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Localidad",
                table: "Receptores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Municipio",
                table: "Receptores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumExt",
                table: "Receptores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumInt",
                table: "Receptores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Referencia",
                table: "Receptores",
                nullable: true);
        }
    }
}

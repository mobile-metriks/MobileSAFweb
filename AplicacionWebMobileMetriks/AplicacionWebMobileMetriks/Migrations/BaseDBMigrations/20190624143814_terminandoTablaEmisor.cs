using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AplicacionWebMobileMetriks.Migrations.BaseDBMigrations
{
    public partial class terminandoTablaEmisor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdEmpresa",
                table: "emisor");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "emisor",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RFC",
                table: "emisor",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "emisor");

            migrationBuilder.DropColumn(
                name: "RFC",
                table: "emisor");

            migrationBuilder.AddColumn<Guid>(
                name: "IdEmpresa",
                table: "emisor",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}

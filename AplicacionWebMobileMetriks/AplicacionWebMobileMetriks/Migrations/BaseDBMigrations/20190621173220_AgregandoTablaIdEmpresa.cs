using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AplicacionWebMobileMetriks.Migrations.BaseDBMigrations
{
    public partial class AgregandoTablaIdEmpresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdEmpresa",
                table: "emisor",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdEmpresa",
                table: "emisor");
        }
    }
}

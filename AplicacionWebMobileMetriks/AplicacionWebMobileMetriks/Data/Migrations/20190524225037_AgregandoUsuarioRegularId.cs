using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AplicacionWebMobileMetriks.Data.Migrations
{
    public partial class AgregandoUsuarioRegularId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IdUsuarioRegular",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "IdUsuarioRegular",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

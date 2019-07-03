using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AplicacionWebMobileMetriks.Migrations.BaseDBMigrations
{
    public partial class agregandoReceptores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Receptores",
                columns: table => new
                {
                    IdReceptor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Identificador = table.Column<string>(nullable: false),
                    RFC = table.Column<string>(nullable: false),
                    Cliente = table.Column<string>(nullable: false),
                    Calle = table.Column<string>(nullable: false),
                    NumExt = table.Column<string>(nullable: true),
                    NumInt = table.Column<string>(nullable: true),
                    Colonia = table.Column<string>(nullable: true),
                    Localidad = table.Column<string>(nullable: true),
                    Referencia = table.Column<string>(nullable: true),
                    Municipio = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    IdPais = table.Column<long>(nullable: false),
                    CodigoPostal = table.Column<int>(nullable: false),
                    C_Moneda = table.Column<string>(nullable: false),
                    IdFormaPago = table.Column<long>(nullable: false),
                    IdUsoCfdi = table.Column<long>(nullable: false),
                    NumIdRegTrib = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receptores", x => x.IdReceptor);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Receptores");
        }
    }
}

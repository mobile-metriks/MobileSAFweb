using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AplicacionWebMobileMetriks.Migrations.Catalogos
{
    public partial class primeraMigracionCatalogos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "ClaveProdServ",
            //    columns: table => new
            //    {
            //        c_ClaveProdServ = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
            //        Descripcion = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
            //        EnUso = table.Column<bool>(nullable: false, defaultValueSql: "('FALSE')")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ClaveProdServ", x => x.c_ClaveProdServ);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ClaveUnidad",
            //    columns: table => new
            //    {
            //        c_ClaveUnidad = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
            //        Nombre = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
            //        EnUso = table.Column<bool>(nullable: false, defaultValueSql: "('FALSE')")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ClaveUnidad", x => x.c_ClaveUnidad);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CodigoPostal",
            //    columns: table => new
            //    {
            //        idCodigoPostal = table.Column<long>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        c_CodigoPostal = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
            //        c_Estado = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
            //        c_Municipio = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
            //        c_Localidad = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
            //        EnUso = table.Column<bool>(nullable: false, defaultValueSql: "('FALSE')")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CodigoPostal", x => x.idCodigoPostal);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "FormaPago",
            //    columns: table => new
            //    {
            //        idFormaPago = table.Column<long>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        c_FormaPago = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
            //        Descripcion = table.Column<string>(unicode: false, maxLength: 40, nullable: false),
            //        EnUso = table.Column<bool>(nullable: false, defaultValueSql: "('FALSE')")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_FormaPago", x => x.idFormaPago);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Impuesto",
            //    columns: table => new
            //    {
            //        idImpuesto = table.Column<long>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        c_Impuesto = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
            //        Descripcion = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
            //        Tipo = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
            //        EnUso = table.Column<bool>(nullable: false, defaultValueSql: "('FALSE')")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Impuesto", x => x.idImpuesto);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "MetodoPago",
            //    columns: table => new
            //    {
            //        idMetodoPago = table.Column<long>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        c_MetodoPago = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
            //        Descripcion = table.Column<string>(unicode: false, maxLength: 40, nullable: false),
            //        EnUso = table.Column<bool>(nullable: false, defaultValueSql: "('FALSE')")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_MetodoPago", x => x.idMetodoPago);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Moneda",
            //    columns: table => new
            //    {
            //        idMoneda = table.Column<long>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        c_Moneda = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
            //        Descripcion = table.Column<string>(unicode: false, maxLength: 40, nullable: false),
            //        Decimales = table.Column<int>(nullable: true),
            //        PorcentajeVariacion = table.Column<string>(maxLength: 20, nullable: true),
            //        EnUso = table.Column<bool>(nullable: false, defaultValueSql: "('FALSE')")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Moneda_1", x => x.idMoneda);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Pais",
            //    columns: table => new
            //    {
            //        idPais = table.Column<long>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        c_Pais = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
            //        Descripcion = table.Column<string>(unicode: false, maxLength: 60, nullable: false),
            //        EnUso = table.Column<bool>(nullable: false, defaultValueSql: "('FALSE')")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Pais", x => x.idPais);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "RegimenFiscal",
            //    columns: table => new
            //    {
            //        idRegimenFiscal = table.Column<long>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        c_RegimenFiscal = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
            //        Descripcion = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
            //        PerFisica = table.Column<bool>(nullable: false),
            //        PerMoral = table.Column<bool>(nullable: false),
            //        EnUso = table.Column<bool>(nullable: false, defaultValueSql: "('FALSE')")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RegimenFiscal", x => x.idRegimenFiscal);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TipoDeComprobante",
            //    columns: table => new
            //    {
            //        idTipoDeComprobante = table.Column<long>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        c_TipoDeComprobante = table.Column<string>(unicode: false, maxLength: 5, nullable: false),
            //        Descripcion = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
            //        EnUso = table.Column<bool>(nullable: false, defaultValueSql: "('FALSE')")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TipoDeComprobante", x => x.idTipoDeComprobante);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TipoFactor",
            //    columns: table => new
            //    {
            //        idTipoFactor = table.Column<long>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        c_TipoFactor = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
            //        EnUso = table.Column<bool>(nullable: false, defaultValueSql: "('FALSE')")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TipoFactor", x => x.idTipoFactor);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TipoRelacion",
            //    columns: table => new
            //    {
            //        idTipoRelacion = table.Column<long>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        c_TipoRelacion = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
            //        Descripcion = table.Column<string>(unicode: false, maxLength: 70, nullable: false),
            //        EnUso = table.Column<bool>(nullable: false, defaultValueSql: "('FALSE')")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TipoRelacion", x => x.idTipoRelacion);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UsoCFDI",
            //    columns: table => new
            //    {
            //        idUsoCFDI = table.Column<long>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        c_UsoCFDI = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
            //        Descripcion = table.Column<string>(unicode: false, maxLength: 70, nullable: false),
            //        PerFisica = table.Column<bool>(nullable: false),
            //        PerMoral = table.Column<bool>(nullable: false),
            //        EnUso = table.Column<bool>(nullable: false, defaultValueSql: "('FALSE')")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UsoCFDI", x => x.idUsoCFDI);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClaveProdServ");

            migrationBuilder.DropTable(
                name: "ClaveUnidad");

            migrationBuilder.DropTable(
                name: "CodigoPostal");

            migrationBuilder.DropTable(
                name: "FormaPago");

            migrationBuilder.DropTable(
                name: "Impuesto");

            migrationBuilder.DropTable(
                name: "MetodoPago");

            migrationBuilder.DropTable(
                name: "Moneda");

            migrationBuilder.DropTable(
                name: "Pais");

            migrationBuilder.DropTable(
                name: "RegimenFiscal");

            migrationBuilder.DropTable(
                name: "TipoDeComprobante");

            migrationBuilder.DropTable(
                name: "TipoFactor");

            migrationBuilder.DropTable(
                name: "TipoRelacion");

            migrationBuilder.DropTable(
                name: "UsoCFDI");
        }
    }
}

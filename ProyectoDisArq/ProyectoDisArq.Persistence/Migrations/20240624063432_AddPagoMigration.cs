using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoDisArq.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddPagoMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medios",
                columns: table => new
                {
                    MedioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Moneda = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Num_tarjeta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Monto = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medios", x => x.MedioId);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    PagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monto_Pendiente = table.Column<float>(type: "real", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.PagoId);
                });

            migrationBuilder.CreateTable(
                name: "MedioPagos",
                columns: table => new
                {
                    MedioPagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedioId = table.Column<int>(type: "int", nullable: false),
                    PagoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedioPagos", x => x.MedioPagoId);
                    table.ForeignKey(
                        name: "FK_MedioPagos_Medios_MedioId",
                        column: x => x.MedioId,
                        principalTable: "Medios",
                        principalColumn: "MedioId");
                    table.ForeignKey(
                        name: "FK_MedioPagos_Pagos_PagoId",
                        column: x => x.PagoId,
                        principalTable: "Pagos",
                        principalColumn: "PagoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedioPagos_MedioId",
                table: "MedioPagos",
                column: "MedioId");

            migrationBuilder.CreateIndex(
                name: "IX_MedioPagos_PagoId",
                table: "MedioPagos",
                column: "PagoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedioPagos");

            migrationBuilder.DropTable(
                name: "Medios");

            migrationBuilder.DropTable(
                name: "Pagos");
        }
    }
}

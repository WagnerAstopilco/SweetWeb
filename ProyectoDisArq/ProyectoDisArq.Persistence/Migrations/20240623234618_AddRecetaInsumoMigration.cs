using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoDisArq.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddRecetaInsumoMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recetas",
                columns: table => new
                {
                    RecetaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: true),
                    Preparacion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recetas", x => x.RecetaId);
                });

            migrationBuilder.CreateTable(
                name: "InsumoRecetas",
                columns: table => new
                {
                    InsumoRecetaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecetaId = table.Column<int>(type: "int", nullable: false),
                    InsumoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad_uso = table.Column<float>(type: "real", nullable: false),
                    Medida_uso = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsumoRecetas", x => x.InsumoRecetaId);
                    table.ForeignKey(
                        name: "FK_InsumoRecetas_Insumos_InsumoId",
                        column: x => x.InsumoId,
                        principalTable: "Insumos",
                        principalColumn: "InsumoId");
                    table.ForeignKey(
                        name: "FK_InsumoRecetas_Recetas_RecetaId",
                        column: x => x.RecetaId,
                        principalTable: "Recetas",
                        principalColumn: "RecetaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsumoRecetas_InsumoId",
                table: "InsumoRecetas",
                column: "InsumoId");

            migrationBuilder.CreateIndex(
                name: "IX_InsumoRecetas_RecetaId",
                table: "InsumoRecetas",
                column: "RecetaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsumoRecetas");

            migrationBuilder.DropTable(
                name: "Recetas");
        }
    }
}

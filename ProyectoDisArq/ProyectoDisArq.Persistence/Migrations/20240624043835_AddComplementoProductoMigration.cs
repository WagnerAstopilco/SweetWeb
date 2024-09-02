using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoDisArq.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddComplementoProductoMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComplementoProductos",
                columns: table => new
                {
                    ComplementoProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplementoId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplementoProducto", x => x.ComplementoProductoId);
                    table.ForeignKey(
                        name: "FK_ComplementoProducto_Complementos_ComplementoId",
                        column: x => x.ComplementoId,
                        principalTable: "Complementos",
                        principalColumn: "ComplementoId");
                    table.ForeignKey(
                        name: "FK_ComplementoProducto_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComplementoProducto_ComplementoId",
                table: "ComplementoProductos",
                column: "ComplementoId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplementoProducto_ProductoId",
                table: "ComplementoProductos",
                column: "ProductoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComplementoProducto");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoDisArq.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddPedidoMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_entrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tipo_Venta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Autorizado_Nombres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Authorizado_Dni = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Autorizado_Apellidos = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PagoId = table.Column<int>(type: "int", nullable: false),
                    DireccionId = table.Column<int>(type: "int", nullable: false),
                    Dni_titular=table.Column<string>(type: "nvarchar(8)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.PedidoId);
                    table.ForeignKey(
                        name: "FK_Pedidos_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pedidos_Direcciones_DireccionId",
                        column: x => x.DireccionId,
                        principalTable: "Direcciones",
                        principalColumn: "DireccionID");
                    table.ForeignKey(
                        name: "FK_Pedidos_Pagos_PagoId",
                        column: x => x.PagoId,
                        principalTable: "Pagos",
                        principalColumn: "PagoId");
                });

            migrationBuilder.CreateTable(
                name: "PedidoProductos",
                columns: table => new
                {
                    PedidoProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoProductos", x => x.PedidoProductoId);
                    table.ForeignKey(
                        name: "FK_PedidoProductos_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "PedidoId");
                    table.ForeignKey(
                        name: "FK_PedidoProductos_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidoProductos_PedidoId",
                table: "PedidoProductos",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoProductos_ProductoId",
                table: "PedidoProductos",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_AppUserId",
                table: "Pedidos",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_DireccionId",
                table: "Pedidos",
                column: "DireccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_PagoId",
                table: "Pedidos",
                column: "PagoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoProductos");

            migrationBuilder.DropTable(
                name: "Pedidos");
        }
    }
}

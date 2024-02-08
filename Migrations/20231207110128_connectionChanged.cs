using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace coffeehouse_api.Migrations
{
    /// <inheritdoc />
    public partial class connectionChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInCarts_Carts_Cartid",
                table: "ProductInCarts");

            migrationBuilder.DropIndex(
                name: "IX_ProductInCarts_Cartid",
                table: "ProductInCarts");

            migrationBuilder.DropColumn(
                name: "Cartid",
                table: "ProductInCarts");

            migrationBuilder.CreateTable(
                name: "CartProductInCart",
                columns: table => new
                {
                    cartsid = table.Column<int>(type: "int", nullable: false),
                    productInCartsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProductInCart", x => new { x.cartsid, x.productInCartsid });
                    table.ForeignKey(
                        name: "FK_CartProductInCart_Carts_cartsid",
                        column: x => x.cartsid,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProductInCart_ProductInCarts_productInCartsid",
                        column: x => x.productInCartsid,
                        principalTable: "ProductInCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartProductInCart_productInCartsid",
                table: "CartProductInCart",
                column: "productInCartsid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartProductInCart");

            migrationBuilder.AddColumn<int>(
                name: "Cartid",
                table: "ProductInCarts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductInCarts_Cartid",
                table: "ProductInCarts",
                column: "Cartid");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInCarts_Carts_Cartid",
                table: "ProductInCarts",
                column: "Cartid",
                principalTable: "Carts",
                principalColumn: "Id");
        }
    }
}

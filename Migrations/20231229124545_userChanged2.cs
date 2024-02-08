using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace coffeehouse_api.Migrations
{
    /// <inheritdoc />
    public partial class userChanged2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartProductInCart_Carts_cartsid",
                table: "CartProductInCart");

            migrationBuilder.DropForeignKey(
                name: "FK_CartProductInCart_ProductInCarts_productInCartsid",
                table: "CartProductInCart");

            migrationBuilder.DropForeignKey(
                name: "FK_CompoundGrammProducts_Compounds_Compoundid",
                table: "CompoundGrammProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_CompoundGrammProducts_Products_Productid",
                table: "CompoundGrammProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInCarts_Products_Productid",
                table: "ProductInCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Types_Typeid",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Carts_Cartid",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_DeliveryDatas_deliveryDataid",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_Roleid",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "deliveryDataid",
                table: "Users",
                newName: "DeliveryDataId");

            migrationBuilder.RenameColumn(
                name: "Roleid",
                table: "Users",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "Cartid",
                table: "Users",
                newName: "CartId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Roleid",
                table: "Users",
                newName: "IX_Users_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_deliveryDataid",
                table: "Users",
                newName: "IX_Users_DeliveryDataId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Cartid",
                table: "Users",
                newName: "IX_Users_CartId");

            migrationBuilder.RenameColumn(
                name: "Typeid",
                table: "Products",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Typeid",
                table: "Products",
                newName: "IX_Products_TypeId");

            migrationBuilder.RenameColumn(
                name: "Productid",
                table: "ProductInCarts",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductInCarts_Productid",
                table: "ProductInCarts",
                newName: "IX_ProductInCarts_ProductId");

            migrationBuilder.RenameColumn(
                name: "Productid",
                table: "CompoundGrammProducts",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "Compoundid",
                table: "CompoundGrammProducts",
                newName: "CompoundId");

            migrationBuilder.RenameIndex(
                name: "IX_CompoundGrammProducts_Productid",
                table: "CompoundGrammProducts",
                newName: "IX_CompoundGrammProducts_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CompoundGrammProducts_Compoundid",
                table: "CompoundGrammProducts",
                newName: "IX_CompoundGrammProducts_CompoundId");

            migrationBuilder.RenameColumn(
                name: "productInCartsid",
                table: "CartProductInCart",
                newName: "ProductInCartsId");

            migrationBuilder.RenameColumn(
                name: "cartsid",
                table: "CartProductInCart",
                newName: "CartsId");

            migrationBuilder.RenameIndex(
                name: "IX_CartProductInCart_productInCartsid",
                table: "CartProductInCart",
                newName: "IX_CartProductInCart_ProductInCartsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartProductInCart_Carts_CartsId",
                table: "CartProductInCart",
                column: "CartsId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartProductInCart_ProductInCarts_ProductInCartsId",
                table: "CartProductInCart",
                column: "ProductInCartsId",
                principalTable: "ProductInCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompoundGrammProducts_Compounds_CompoundId",
                table: "CompoundGrammProducts",
                column: "CompoundId",
                principalTable: "Compounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompoundGrammProducts_Products_ProductId",
                table: "CompoundGrammProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInCarts_Products_ProductId",
                table: "ProductInCarts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Types_TypeId",
                table: "Products",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Carts_CartId",
                table: "Users",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_DeliveryDatas_DeliveryDataId",
                table: "Users",
                column: "DeliveryDataId",
                principalTable: "DeliveryDatas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartProductInCart_Carts_CartsId",
                table: "CartProductInCart");

            migrationBuilder.DropForeignKey(
                name: "FK_CartProductInCart_ProductInCarts_ProductInCartsId",
                table: "CartProductInCart");

            migrationBuilder.DropForeignKey(
                name: "FK_CompoundGrammProducts_Compounds_CompoundId",
                table: "CompoundGrammProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_CompoundGrammProducts_Products_ProductId",
                table: "CompoundGrammProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInCarts_Products_ProductId",
                table: "ProductInCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Types_TypeId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Carts_CartId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_DeliveryDatas_DeliveryDataId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Users",
                newName: "Roleid");

            migrationBuilder.RenameColumn(
                name: "DeliveryDataId",
                table: "Users",
                newName: "deliveryDataid");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "Users",
                newName: "Cartid");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                newName: "IX_Users_Roleid");

            migrationBuilder.RenameIndex(
                name: "IX_Users_DeliveryDataId",
                table: "Users",
                newName: "IX_Users_deliveryDataid");

            migrationBuilder.RenameIndex(
                name: "IX_Users_CartId",
                table: "Users",
                newName: "IX_Users_Cartid");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Products",
                newName: "Typeid");

            migrationBuilder.RenameIndex(
                name: "IX_Products_TypeId",
                table: "Products",
                newName: "IX_Products_Typeid");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductInCarts",
                newName: "Productid");

            migrationBuilder.RenameIndex(
                name: "IX_ProductInCarts_ProductId",
                table: "ProductInCarts",
                newName: "IX_ProductInCarts_Productid");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "CompoundGrammProducts",
                newName: "Productid");

            migrationBuilder.RenameColumn(
                name: "CompoundId",
                table: "CompoundGrammProducts",
                newName: "Compoundid");

            migrationBuilder.RenameIndex(
                name: "IX_CompoundGrammProducts_ProductId",
                table: "CompoundGrammProducts",
                newName: "IX_CompoundGrammProducts_Productid");

            migrationBuilder.RenameIndex(
                name: "IX_CompoundGrammProducts_CompoundId",
                table: "CompoundGrammProducts",
                newName: "IX_CompoundGrammProducts_Compoundid");

            migrationBuilder.RenameColumn(
                name: "ProductInCartsId",
                table: "CartProductInCart",
                newName: "productInCartsid");

            migrationBuilder.RenameColumn(
                name: "CartsId",
                table: "CartProductInCart",
                newName: "cartsid");

            migrationBuilder.RenameIndex(
                name: "IX_CartProductInCart_ProductInCartsId",
                table: "CartProductInCart",
                newName: "IX_CartProductInCart_productInCartsid");

            migrationBuilder.AddForeignKey(
                name: "FK_CartProductInCart_Carts_cartsid",
                table: "CartProductInCart",
                column: "cartsid",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartProductInCart_ProductInCarts_productInCartsid",
                table: "CartProductInCart",
                column: "productInCartsid",
                principalTable: "ProductInCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompoundGrammProducts_Compounds_Compoundid",
                table: "CompoundGrammProducts",
                column: "Compoundid",
                principalTable: "Compounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompoundGrammProducts_Products_Productid",
                table: "CompoundGrammProducts",
                column: "Productid",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInCarts_Products_Productid",
                table: "ProductInCarts",
                column: "Productid",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Types_Typeid",
                table: "Products",
                column: "Typeid",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Carts_Cartid",
                table: "Users",
                column: "Cartid",
                principalTable: "Carts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_DeliveryDatas_deliveryDataid",
                table: "Users",
                column: "deliveryDataid",
                principalTable: "DeliveryDatas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_Roleid",
                table: "Users",
                column: "Roleid",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

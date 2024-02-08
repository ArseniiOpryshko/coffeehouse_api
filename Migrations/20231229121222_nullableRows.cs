using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace coffeehouse_api.Migrations
{
    /// <inheritdoc />
    public partial class nullableRows : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Carts_Cartid",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_DeliveryDatas_deliveryDataid",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "totalPrice",
                table: "ProductInCarts");

            migrationBuilder.AlterColumn<int>(
                name: "deliveryDataid",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Cartid",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Carts_Cartid",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_DeliveryDatas_deliveryDataid",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "deliveryDataid",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Cartid",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "totalPrice",
                table: "ProductInCarts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Carts_Cartid",
                table: "Users",
                column: "Cartid",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_DeliveryDatas_deliveryDataid",
                table: "Users",
                column: "deliveryDataid",
                principalTable: "DeliveryDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

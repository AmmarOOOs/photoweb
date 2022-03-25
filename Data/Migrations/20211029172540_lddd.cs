using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowerShop.Data.Migrations
{
    public partial class lddd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "brunch",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "BrunshId",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_BrunshId",
                table: "Order",
                column: "BrunshId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Brunsh_BrunshId",
                table: "Order",
                column: "BrunshId",
                principalTable: "Brunsh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Brunsh_BrunshId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_BrunshId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "BrunshId",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "brunch",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roya_DDL.Migrations
{
    public partial class v89 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FavoritLists_ProductId",
                table: "FavoritLists",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoritLists_Products_ProductId",
                table: "FavoritLists",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoritLists_Products_ProductId",
                table: "FavoritLists");

            migrationBuilder.DropIndex(
                name: "IX_FavoritLists_ProductId",
                table: "FavoritLists");
        }
    }
}

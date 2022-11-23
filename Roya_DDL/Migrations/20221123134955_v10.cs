using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roya_DDL.Migrations
{
    public partial class v10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bookings_ProductId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Images");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ProductId",
                table: "Bookings",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bookings_ProductId",
                table: "Bookings");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ProductId",
                table: "Bookings",
                column: "ProductId",
                unique: true);
        }
    }
}

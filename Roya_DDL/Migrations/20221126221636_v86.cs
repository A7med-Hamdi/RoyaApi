using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roya_DDL.Migrations
{
    public partial class v86 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Addreses_AddresesId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "AddresesId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Addreses_AddresesId",
                table: "AspNetUsers",
                column: "AddresesId",
                principalTable: "Addreses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Addreses_AddresesId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddresesId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Addreses_AddresesId",
                table: "AspNetUsers",
                column: "AddresesId",
                principalTable: "Addreses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

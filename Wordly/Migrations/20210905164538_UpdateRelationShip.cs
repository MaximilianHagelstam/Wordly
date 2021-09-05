using Microsoft.EntityFrameworkCore.Migrations;

namespace Wordly.Migrations
{
    public partial class UpdateRelationShip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Words_AspNetUsers_ApplicationUserId",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Words");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Words",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Words_AspNetUsers_ApplicationUserId",
                table: "Words",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Words_AspNetUsers_ApplicationUserId",
                table: "Words");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Words",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Words",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Words_AspNetUsers_ApplicationUserId",
                table: "Words",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

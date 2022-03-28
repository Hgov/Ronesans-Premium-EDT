using Microsoft.EntityFrameworkCore.Migrations;

namespace Ronesans.Domain.Access.Migrations
{
    public partial class change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "url",
                table: "Shops");

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "Shops",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shops_user_id",
                table: "Shops",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shops_Users_user_id",
                table: "Shops",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shops_Users_user_id",
                table: "Shops");

            migrationBuilder.DropIndex(
                name: "IX_Shops_user_id",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "Shops");

            migrationBuilder.AddColumn<string>(
                name: "url",
                table: "Shops",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

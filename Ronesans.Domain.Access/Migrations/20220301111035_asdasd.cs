using Microsoft.EntityFrameworkCore.Migrations;

namespace Ronesans.Domain.Access.Migrations
{
    public partial class asdasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "banner_image_name",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "icon_name",
                table: "Shops");

            migrationBuilder.AlterColumn<string>(
                name: "currency_code",
                table: "Shops",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "TRY",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "currency_code",
                table: "Shops",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "TRY");

            migrationBuilder.AddColumn<string>(
                name: "banner_image_name",
                table: "Shops",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "icon_name",
                table: "Shops",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Ronesans.Domain.Access.Migrations
{
    public partial class creas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShopFiles",
                columns: table => new
                {
                    shop_id = table.Column<int>(type: "int", nullable: false),
                    file_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopFiles", x => new { x.shop_id, x.file_id });
                    table.ForeignKey(
                        name: "FK_ShopFiles_Files_file_id",
                        column: x => x.file_id,
                        principalTable: "Files",
                        principalColumn: "file_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopFiles_Shops_shop_id",
                        column: x => x.shop_id,
                        principalTable: "Shops",
                        principalColumn: "shop_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopFiles_file_id",
                table: "ShopFiles",
                column: "file_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopFiles");
        }
    }
}

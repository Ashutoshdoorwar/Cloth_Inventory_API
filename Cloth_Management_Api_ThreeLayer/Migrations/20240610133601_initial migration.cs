using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cloth_Management_Api_ThreeLayer.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BrandTable",
                columns: table => new
                {
                    Brand_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandTable", x => x.Brand_id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryTable",
                columns: table => new
                {
                    Category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTable", x => x.Category_id);
                });

            migrationBuilder.CreateTable(
                name: "ClothTable",
                columns: table => new
                {
                    Cloth_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cloth_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category_id = table.Column<int>(type: "int", nullable: false),
                    Category_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand_id = table.Column<int>(type: "int", nullable: false),
                    Brand_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothTable", x => x.Cloth_id);
                });

            migrationBuilder.CreateTable(
                name: "StockTable",
                columns: table => new
                {
                    Stock_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cloth_id = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Cloth_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTable", x => x.Stock_id);
                });

            migrationBuilder.CreateTable(
                name: "UsersTable",
                columns: table => new
                {
                    Users_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersTable", x => x.Users_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrandTable");

            migrationBuilder.DropTable(
                name: "CategoryTable");

            migrationBuilder.DropTable(
                name: "ClothTable");

            migrationBuilder.DropTable(
                name: "StockTable");

            migrationBuilder.DropTable(
                name: "UsersTable");
        }
    }
}

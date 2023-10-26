using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.DAL.Migrations
{
    public partial class supplierAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierPinCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suppliers", x => x.SupplierId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "suppliers");
        }
    }
}

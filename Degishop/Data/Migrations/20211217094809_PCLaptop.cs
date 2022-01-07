using Microsoft.EntityFrameworkCore.Migrations;

namespace Degishop.Data.Migrations
{
    public partial class PCLaptop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PC_AND_Laptop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    model_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RAM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Graphic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PC_AND_Laptop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PC_AND_Laptop_Brands_BrandsId",
                        column: x => x.BrandsId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PC_AND_Laptop_BrandsId",
                table: "PC_AND_Laptop",
                column: "BrandsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PC_AND_Laptop");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductManagement.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CATEGORY",
                columns: table => new
                {
                    CATEGORYID = table.Column<int>(name: "CATEGORY_ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CATEGORYNAME = table.Column<string>(name: "CATEGORY_NAME", type: "nvarchar(max)", nullable: false),
                    CATEGORYSITUATION = table.Column<bool>(name: "CATEGORY_SITUATION", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CATEGORY", x => x.CATEGORYID);
                });

            migrationBuilder.CreateTable(
                name: "TB_PRODUCT",
                columns: table => new
                {
                    PRODUCTID = table.Column<int>(name: "PRODUCT_ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRODUCTNAME = table.Column<string>(name: "PRODUCT_NAME", type: "nvarchar(max)", nullable: false),
                    PRODUCTDESCRIPTION = table.Column<string>(name: "PRODUCT_DESCRIPTION", type: "nvarchar(max)", nullable: false),
                    PRODUCTPRICE = table.Column<decimal>(name: "PRODUCT_PRICE", type: "decimal(18,4)", nullable: false),
                    PRODUCTSITUATION = table.Column<bool>(name: "PRODUCT_SITUATION", type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRODUCT", x => x.PRODUCTID);
                    table.ForeignKey(
                        name: "FK_TB_PRODUCT_TB_CATEGORY_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "TB_CATEGORY",
                        principalColumn: "CATEGORY_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PRODUCT_CategoryId",
                table: "TB_PRODUCT",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PRODUCT");

            migrationBuilder.DropTable(
                name: "TB_CATEGORY");
        }
    }
}

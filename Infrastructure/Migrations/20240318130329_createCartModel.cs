using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class createCartModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Qty = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconCSS = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Qty = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "IconCSS", "Name" },
                values: new object[,]
                {
                    { 1, "fas fa-spa", "Beauty" },
                    { 2, "fas fa-couch", "Furniture" },
                    { 3, "fas fa-headphones", "Electronics" },
                    { 4, "fas fa-shoe-prints", "Shoes" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageURL", "Name", "Price", "Qty" },
                values: new object[,]
                {
                    { 1, 1, "A kit provided by Glossier, containing skin care, hair care and makeup products", "/Images/img1.jpg", "Glossier - Beauty Kit", 100m, 100 },
                    { 2, 1, "A kit provided by Curology, containing skin care products", "/Images/img1.jpg", "Curology - Skin Care Kit", 50m, 45 },
                    { 3, 1, "A kit provided by Curology, containing skin care products", "/Images/img1.jpg", "Cocooil - Organic Coconut Oil", 20m, 30 },
                    { 4, 1, "A kit provided by Schwarzkopf, containing skin care and hair care products", "/Images/img1.jpg", "Schwarzkopf - Hair Care and Skin Care Kit", 50m, 60 },
                    { 5, 1, "Skin Care Kit, containing skin care and hair care products", "/Images/img1.jpg", "Skin Care Kit", 30m, 85 },
                    { 6, 3, "Air Pods - in-ear wireless headphones", "/Images/img2.jpg", "Air Pods", 100m, 120 },
                    { 7, 3, "On-ear Golden Headphones - these headphones are not wireless", "/Images/img2.jpg", "On-ear Golden Headphones", 40m, 200 },
                    { 8, 3, "On-ear Black Headphones - these headphones are not wireless", "/Images/img2.jpg", "On-ear Black Headphones", 40m, 300 },
                    { 9, 3, "Sennheiser Digital Camera - High quality digital camera provided by Sennheiser - includes tripod", "/Images/img2.jpg", "Sennheiser Digital Camera with Tripod", 600m, 20 },
                    { 10, 3, "Canon Digital Camera - High quality digital camera provided by Canon", "/Images/img2.jpg", "Canon Digital Camera", 500m, 15 },
                    { 11, 3, "Gameboy - Provided by Nintendo", "/Images/img3.jpg", "Nintendo Gameboy", 100m, 60 },
                    { 12, 2, "Very comfortable black leather office chair", "/Images/img3.jpg", "Black Leather Office Chair", 50m, 212 },
                    { 13, 2, "Very comfortable pink leather office chair", "/Images/img3.jpg", "Pink Leather Office Chair", 50m, 112 },
                    { 14, 2, "Very comfortable lounge chair", "/Images/img3.jpg", "Lounge Chair", 70m, 90 },
                    { 15, 2, "Very comfortable Silver lounge chair", "/Images/img4.jpg", "Silver Lounge Chair", 120m, 95 },
                    { 16, 2, "White and blue Porcelain Table Lamp", "/Images/img4.jpg", "Porcelain Table Lamp", 15m, 100 },
                    { 17, 2, "Office Table Lamp", "/Images/img4.jpg", "Office Table Lamp", 20m, 73 },
                    { 18, 4, "Comfortable Puma Sneakers in most sizes", "/Images/img5.jpg", "Puma Sneakers", 100m, 50 },
                    { 19, 4, "Colorful trainsers - available in most sizes", "/Images/img4.jpg", "Colorful Trainers", 150m, 60 },
                    { 20, 4, "Blue Nike Trainers - available in most sizes", "/Images/img9.jpg", "Blue Nike Trainers", 200m, 70 },
                    { 21, 4, "Colorful Hummel Trainers - available in most sizes", "/Images/img8.jpg", "Colorful Hummel Trainers", 120m, 120 },
                    { 22, 4, "Red Nike Trainers - available in most sizes", "/Images/img7.jpg", "Red Nike Trainers", 200m, 100 },
                    { 23, 4, "Birkenstock Sandles - available in most sizes", "/Images/img6.jpg", "Birkenstock Sandles", 50m, 150 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductCategories");
        }
    }
}

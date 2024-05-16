using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Food_project.Migrations
{
    /// <inheritdoc />
    public partial class mygration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingrediants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingrediants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dishingrediants",
                columns: table => new
                {
                    DishId = table.Column<int>(type: "int", nullable: false),
                    IngregiantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishingrediants", x => new { x.DishId, x.IngregiantId });
                    table.ForeignKey(
                        name: "FK_Dishingrediants_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dishingrediants_Ingrediants_IngregiantId",
                        column: x => x.IngregiantId,
                        principalTable: "Ingrediants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "ImageUrl", "Name", "price" },
                values: new object[] { 1, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRbtv-UwXqSWD55s_nAdxP7Wofwn3by_lhhQoXPff7O9g&s", "Pizza", 1000.0 });

            migrationBuilder.InsertData(
                table: "Ingrediants",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mozeralla" },
                    { 2, "prawns" }
                });

            migrationBuilder.InsertData(
                table: "Dishingrediants",
                columns: new[] { "DishId", "IngregiantId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dishingrediants_IngregiantId",
                table: "Dishingrediants",
                column: "IngregiantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dishingrediants");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Ingrediants");
        }
    }
}

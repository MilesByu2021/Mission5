using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission4.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "AddNewMovies",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    Director = table.Column<string>(nullable: true),
                    Rating = table.Column<string>(nullable: true),
                    Edited = table.Column<bool>(nullable: false),
                    Lent = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddNewMovies", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_AddNewMovies_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 1, "Action/Adventure" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 2, "Comedy" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 3, "Drama" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 4, " Family" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 5, "Horror/Suspense" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 6, "Miscellaneous" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 7, "Television" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 8, "VHS" });

            migrationBuilder.InsertData(
                table: "AddNewMovies",
                columns: new[] { "MovieId", "CategoryId", "Director", "Edited", "Lent", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 1, 1, "Francis Ford Coppola", false, "Shaun", "Michael is the real boss", "R", "The Godfather", 1972 });

            migrationBuilder.InsertData(
                table: "AddNewMovies",
                columns: new[] { "MovieId", "CategoryId", "Director", "Edited", "Lent", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 2, 1, "Jon Watts", false, "Thor", "Peter Parker is Spiderman", "PG-13", "Spider-Man: No Way Home", 2022 });

            migrationBuilder.InsertData(
                table: "AddNewMovies",
                columns: new[] { "MovieId", "CategoryId", "Director", "Edited", "Lent", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 3, 1, "Robert Schwentke", true, "Caden", "Sanke Eyes can speak!", "PG-13", "Snake Eyes", 2021 });

            migrationBuilder.CreateIndex(
                name: "IX_AddNewMovies_CategoryId",
                table: "AddNewMovies",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddNewMovies");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

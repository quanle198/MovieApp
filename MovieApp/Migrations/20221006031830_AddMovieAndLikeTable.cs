using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApp.Migrations
{
    public partial class AddMovieAndLikeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovieId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Path", "Title" },
                values: new object[] { "78c8eb9d-8584-44d6-b332-ca7dd465bf19", "https://cdn-amz.woka.io/images/I/71lVAGaqBtL.jpg", "Iron Man" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Path", "Title" },
                values: new object[] { "b2f9f53c-79f9-45af-8a49-dfc3980077ea", "https://cdn11.bigcommerce.com/s-yzgoj/images/stencil/1280x1280/products/1519914/3835138/XPSMX5072__16213.1654734420.jpg?c=2", "Super Man" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Path", "Title" },
                values: new object[] { "f588aaf3-9c6c-49ba-a1ec-3313f95f292e", "https://m.media-amazon.com/images/I/51Ec5e2vz9L._AC_SY580_.jpg", "Spider Man" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}

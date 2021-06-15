using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcCoreOverview2.Migrations
{
    public partial class CreatedNewTabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Author_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Author_Id);
                });

            migrationBuilder.CreateTable(
                name: "details",
                columns: table => new
                {
                    BookDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Weight = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_details", x => x.BookDetailId);
                });

            migrationBuilder.CreateTable(
                name: "publishers",
                columns: table => new
                {
                    PubplisherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publishers", x => x.PubplisherId);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    Books_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Pages = table.Column<int>(type: "int", nullable: false),
                    YearPublished = table.Column<int>(type: "int", nullable: false),
                    Auther = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AutherFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AutherLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsBestSeller = table.Column<bool>(type: "bit", nullable: false),
                    BookDetailId = table.Column<int>(type: "int", nullable: false),
                    PubplisherId = table.Column<int>(type: "int", nullable: false),
                    PublisherPubplisherId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.Books_Id);
                    table.ForeignKey(
                        name: "FK_books_details_BookDetailId",
                        column: x => x.BookDetailId,
                        principalTable: "details",
                        principalColumn: "BookDetailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_books_publishers_PublisherPubplisherId",
                        column: x => x.PublisherPubplisherId,
                        principalTable: "publishers",
                        principalColumn: "PubplisherId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    Books_Id = table.Column<int>(type: "int", nullable: false),
                    Author_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => new { x.Books_Id, x.Author_Id });
                    table.ForeignKey(
                        name: "FK_BookAuthors_Authors_Author_Id",
                        column: x => x.Author_Id,
                        principalTable: "Authors",
                        principalColumn: "Author_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthors_books_Books_Id",
                        column: x => x.Books_Id,
                        principalTable: "books",
                        principalColumn: "Books_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_Author_Id",
                table: "BookAuthors",
                column: "Author_Id");

            migrationBuilder.CreateIndex(
                name: "IX_books_BookDetailId",
                table: "books",
                column: "BookDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_books_PublisherPubplisherId",
                table: "books",
                column: "PublisherPubplisherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "details");

            migrationBuilder.DropTable(
                name: "publishers");
        }
    }
}

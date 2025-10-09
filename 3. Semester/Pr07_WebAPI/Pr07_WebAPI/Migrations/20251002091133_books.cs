using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pr07_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class books : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Title", "Year" },
                values: new object[,]
                {
                    { 1, "Robert C. Martin", "Clean Code", 2008 },
                    { 2, "Andrew Hunt & David Thomas", "The Pragmatic Programmer", 1999 },
                    { 3, "Erich Gamma et al.", "Design Patterns: Elements of Reusable Object-Oriented Software", 1994 },
                    { 4, "Martin Fowler", "Refactoring: Improving the Design of Existing Code", 1999 },
                    { 5, "Eric Evans", "Domain-Driven Design: Tackling Complexity in the Heart of Software", 2003 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}

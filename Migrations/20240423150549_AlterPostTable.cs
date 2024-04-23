using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogPostApp.Migrations
{
    /// <inheritdoc />
    public partial class AlterPostTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Posts");

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Age", "Name" },
                values: new object[,]
                {
                    { 1, 0, "Test" },
                    { 2, 0, "Jeffery Achher" },
                    { 3, 0, "Chetan Bhagat" },
                    { 4, 0, "Jane Doe" },
                    { 5, 0, "John Smith" },
                    { 6, 0, "Emily Johnson" },
                    { 7, 0, "Michael Brown" },
                    { 8, 0, "Sophia Williams" },
                    { 9, 0, "William Jones" },
                    { 10, 0, "Olivia Garcia" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Test Category" },
                    { 2, "Drama" },
                    { 3, "Action" },
                    { 4, "Romance" },
                    { 5, "Science Fiction" },
                    { 6, "Mystery" },
                    { 7, "Thriller" },
                    { 8, "Fantasy" },
                    { 9, "Horror" },
                    { 10, "Comedy" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CreatedOn", "Description", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 4, 23, 20, 35, 48, 494, DateTimeKind.Local).AddTicks(5018), "This is an introduction.", "Introduction" },
                    { 2, 2, 1, new DateTime(2024, 4, 23, 20, 35, 48, 494, DateTimeKind.Local).AddTicks(5038), "This is an experiment.", "Experiment" },
                    { 3, 3, 2, new DateTime(2024, 4, 23, 20, 35, 48, 494, DateTimeKind.Local).AddTicks(5041), "This is an exploration.", "Exploration" },
                    { 4, 4, 3, new DateTime(2024, 4, 23, 20, 35, 48, 494, DateTimeKind.Local).AddTicks(5044), "This is an illustration.", "Illustration" },
                    { 5, 5, 4, new DateTime(2024, 4, 23, 20, 35, 48, 494, DateTimeKind.Local).AddTicks(5047), "This is a demonstration.", "Demonstration" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

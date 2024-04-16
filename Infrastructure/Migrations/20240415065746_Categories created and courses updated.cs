using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Categoriescreatedandcoursesupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "AspNetCourses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "AspNetCourses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "AspNetCourses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "AspNetCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetCourses_CategoryId",
                table: "AspNetCourses",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetCourses_AspNetCategories_CategoryId",
                table: "AspNetCourses",
                column: "CategoryId",
                principalTable: "AspNetCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetCourses_AspNetCategories_CategoryId",
                table: "AspNetCourses");

            migrationBuilder.DropTable(
                name: "AspNetCategories");

            migrationBuilder.DropIndex(
                name: "IX_AspNetCourses_CategoryId",
                table: "AspNetCourses");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "AspNetCourses");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "AspNetCourses");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "AspNetCourses");
        }
    }
}

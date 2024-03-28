using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class renamethetables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourseRegistrations_AspNetUsers_UserId",
                table: "UserCourseRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourseRegistrations_Courses_CourseId",
                table: "UserCourseRegistrations");

            migrationBuilder.DropTable(
                name: "UserNewsletterSubscriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCourseRegistrations",
                table: "UserCourseRegistrations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Newsletters",
                table: "Newsletters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "UserCourseRegistrations",
                newName: "AspNetUserCourseRegistrations");

            migrationBuilder.RenameTable(
                name: "Newsletters",
                newName: "AspNetNewsletters");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "AspNetCourses");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "AspNetAddresses");

            migrationBuilder.RenameIndex(
                name: "IX_UserCourseRegistrations_CourseId",
                table: "AspNetUserCourseRegistrations",
                newName: "IX_AspNetUserCourseRegistrations_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserCourseRegistrations",
                table: "AspNetUserCourseRegistrations",
                columns: new[] { "UserId", "CourseId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetNewsletters",
                table: "AspNetNewsletters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetCourses",
                table: "AspNetCourses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetAddresses",
                table: "AspNetAddresses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AspNetUserNewsletterSubscriptions",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NewsletterId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserNewsletterSubscriptions", x => new { x.UserId, x.NewsletterId });
                    table.ForeignKey(
                        name: "FK_AspNetUserNewsletterSubscriptions_AspNetNewsletters_NewsletterId",
                        column: x => x.NewsletterId,
                        principalTable: "AspNetNewsletters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserNewsletterSubscriptions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserNewsletterSubscriptions_NewsletterId",
                table: "AspNetUserNewsletterSubscriptions",
                column: "NewsletterId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserCourseRegistrations_AspNetCourses_CourseId",
                table: "AspNetUserCourseRegistrations",
                column: "CourseId",
                principalTable: "AspNetCourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserCourseRegistrations_AspNetUsers_UserId",
                table: "AspNetUserCourseRegistrations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetAddresses_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                principalTable: "AspNetAddresses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserCourseRegistrations_AspNetCourses_CourseId",
                table: "AspNetUserCourseRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserCourseRegistrations_AspNetUsers_UserId",
                table: "AspNetUserCourseRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetAddresses_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AspNetUserNewsletterSubscriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserCourseRegistrations",
                table: "AspNetUserCourseRegistrations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetNewsletters",
                table: "AspNetNewsletters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetCourses",
                table: "AspNetCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetAddresses",
                table: "AspNetAddresses");

            migrationBuilder.RenameTable(
                name: "AspNetUserCourseRegistrations",
                newName: "UserCourseRegistrations");

            migrationBuilder.RenameTable(
                name: "AspNetNewsletters",
                newName: "Newsletters");

            migrationBuilder.RenameTable(
                name: "AspNetCourses",
                newName: "Courses");

            migrationBuilder.RenameTable(
                name: "AspNetAddresses",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserCourseRegistrations_CourseId",
                table: "UserCourseRegistrations",
                newName: "IX_UserCourseRegistrations_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCourseRegistrations",
                table: "UserCourseRegistrations",
                columns: new[] { "UserId", "CourseId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Newsletters",
                table: "Newsletters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserNewsletterSubscriptions",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NewsletterId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNewsletterSubscriptions", x => new { x.UserId, x.NewsletterId });
                    table.ForeignKey(
                        name: "FK_UserNewsletterSubscriptions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserNewsletterSubscriptions_Newsletters_NewsletterId",
                        column: x => x.NewsletterId,
                        principalTable: "Newsletters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserNewsletterSubscriptions_NewsletterId",
                table: "UserNewsletterSubscriptions",
                column: "NewsletterId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourseRegistrations_AspNetUsers_UserId",
                table: "UserCourseRegistrations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourseRegistrations_Courses_CourseId",
                table: "UserCourseRegistrations",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

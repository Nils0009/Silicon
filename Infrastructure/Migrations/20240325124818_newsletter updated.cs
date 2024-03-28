using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newsletterupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdvertisingUpdates",
                table: "AspNetNewsletters");

            migrationBuilder.DropColumn(
                name: "DailyNewsletter",
                table: "AspNetNewsletters");

            migrationBuilder.DropColumn(
                name: "EventUpdates",
                table: "AspNetNewsletters");

            migrationBuilder.DropColumn(
                name: "Podcasts",
                table: "AspNetNewsletters");

            migrationBuilder.DropColumn(
                name: "StartupsWeekly",
                table: "AspNetNewsletters");

            migrationBuilder.DropColumn(
                name: "WeekInReview",
                table: "AspNetNewsletters");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AdvertisingUpdates",
                table: "AspNetNewsletters",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DailyNewsletter",
                table: "AspNetNewsletters",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EventUpdates",
                table: "AspNetNewsletters",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Podcasts",
                table: "AspNetNewsletters",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "StartupsWeekly",
                table: "AspNetNewsletters",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "WeekInReview",
                table: "AspNetNewsletters",
                type: "bit",
                nullable: true);
        }
    }
}

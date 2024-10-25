using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreSpeedTest.Storage.Migrations
{
    /// <inheritdoc />
    public partial class AddTimeZone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedAtTz",
                table: "UserAccount",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAtTz",
                table: "UserAccount");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreSpeedTest.Storage.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUniqueEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserAccount_Email",
                table: "UserAccount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_Email",
                table: "UserAccount",
                column: "Email",
                unique: true);
        }
    }
}

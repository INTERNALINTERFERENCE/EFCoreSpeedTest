using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;

#nullable disable

namespace EFCoreSpeedTest.Storage.Migrations
{
    /// <inheritdoc />
    public partial class UseLocalDateTimeInsteadOfZoned : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<LocalDateTime>(
                name: "CreatedAt",
                table: "UserAccount",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(ZonedDateTime),
                oldType: "timestamp with time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<ZonedDateTime>(
                name: "CreatedAt",
                table: "UserAccount",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(LocalDateTime),
                oldType: "timestamp without time zone");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XTICopiaDB.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class Initial06 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "TimeDeleted",
                table: "Couterparties",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeDeleted",
                table: "Couterparties");
        }
    }
}

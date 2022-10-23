using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XTI_CopiaDB.SqlServer.Migrations
{
    public partial class Initial02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "TimeAdded",
                table: "Portfolios",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeAdded",
                table: "Portfolios");
        }
    }
}

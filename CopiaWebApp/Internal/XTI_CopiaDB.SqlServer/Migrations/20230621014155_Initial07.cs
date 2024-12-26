using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XTICopiaDB.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class Initial07 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortfolioID = table.Column<int>(type: "int", nullable: false),
                    ActivityTemplateID = table.Column<int>(type: "int", nullable: false),
                    ActivityName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    TimeCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ActivityDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CounterpartyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Activities_ActivityTemplates_ActivityTemplateID",
                        column: x => x.ActivityTemplateID,
                        principalTable: "ActivityTemplates",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Activities_Couterparties_CounterpartyID",
                        column: x => x.CounterpartyID,
                        principalTable: "Couterparties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Activities_Portfolios_PortfolioID",
                        column: x => x.PortfolioID,
                        principalTable: "Portfolios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ActivityTemplateID",
                table: "Activities",
                column: "ActivityTemplateID");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CounterpartyID",
                table: "Activities",
                column: "CounterpartyID");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_PortfolioID",
                table: "Activities",
                column: "PortfolioID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");
        }
    }
}

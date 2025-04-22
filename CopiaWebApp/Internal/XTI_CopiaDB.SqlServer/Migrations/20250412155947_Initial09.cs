using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XTICopiaDB.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class Initial09 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_ActivityTemplates_ActivityTemplateID",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "ActivityTemplates");

            migrationBuilder.DropIndex(
                name: "IX_Activities_ActivityTemplateID",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ActivityTemplateID",
                table: "Activities");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActivityTemplateID",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ActivityTemplates",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, defaultValue: ""),
                    PortfolioID = table.Column<int>(type: "int", nullable: false),
                    TemplateName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityTemplates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ActivityTemplates_Portfolios_PortfolioID",
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
                name: "IX_ActivityTemplates_PortfolioID",
                table: "ActivityTemplates",
                column: "PortfolioID");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_ActivityTemplates_ActivityTemplateID",
                table: "Activities",
                column: "ActivityTemplateID",
                principalTable: "ActivityTemplates",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

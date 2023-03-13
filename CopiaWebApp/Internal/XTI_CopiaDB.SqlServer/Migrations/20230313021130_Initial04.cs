using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XTICopiaDB.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class Initial04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityTemplates",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortfolioID = table.Column<int>(type: "int", nullable: false),
                    TemplateName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ActivityNameTemplateStringID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityTemplates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ActivityTemplates_Portfolios_PortfolioID",
                        column: x => x.PortfolioID,
                        principalTable: "Portfolios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemplateStrings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortfolioID = table.Column<int>(type: "int", nullable: false),
                    DataType = table.Column<int>(type: "int", nullable: false),
                    CanEdit = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateStrings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TemplateStrings_Portfolios_PortfolioID",
                        column: x => x.PortfolioID,
                        principalTable: "Portfolios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityTemplateFields",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateID = table.Column<int>(type: "int", nullable: false),
                    FieldType = table.Column<int>(type: "int", nullable: false),
                    FieldCaption = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Accessibility = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityTemplateFields", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ActivityTemplateFields_ActivityTemplates_TemplateID",
                        column: x => x.TemplateID,
                        principalTable: "ActivityTemplates",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemplateStringParts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateStringID = table.Column<int>(type: "int", nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    PartType = table.Column<int>(type: "int", nullable: false),
                    ArrayType = table.Column<int>(type: "int", nullable: false),
                    ArrayIndex = table.Column<int>(type: "int", nullable: false),
                    FieldType = table.Column<int>(type: "int", nullable: false),
                    FixedText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateStringParts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TemplateStringParts_TemplateStrings_TemplateStringID",
                        column: x => x.TemplateStringID,
                        principalTable: "TemplateStrings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityTemplateFields_TemplateID",
                table: "ActivityTemplateFields",
                column: "TemplateID");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityTemplates_PortfolioID",
                table: "ActivityTemplates",
                column: "PortfolioID");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateStringParts_TemplateStringID_Sequence",
                table: "TemplateStringParts",
                columns: new[] { "TemplateStringID", "Sequence" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TemplateStrings_PortfolioID",
                table: "TemplateStrings",
                column: "PortfolioID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityTemplateFields");

            migrationBuilder.DropTable(
                name: "TemplateStringParts");

            migrationBuilder.DropTable(
                name: "ActivityTemplates");

            migrationBuilder.DropTable(
                name: "TemplateStrings");
        }
    }
}

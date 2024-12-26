using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XTICopiaDB.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class Initial08 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityTemplates_Portfolios_PortfolioID",
                table: "ActivityTemplates");

            migrationBuilder.DropTable(
                name: "ActivityTemplateFields");

            migrationBuilder.DropTable(
                name: "TemplateStringParts");

            migrationBuilder.DropTable(
                name: "TemplateStrings");

            migrationBuilder.DropColumn(
                name: "ActivityNameTemplateStringID",
                table: "ActivityTemplates");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "TimeAdded",
                table: "Portfolios",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<string>(
                name: "PortfolioName",
                table: "Portfolios",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Couterparties",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "DisplayText",
                table: "Couterparties",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "TemplateName",
                table: "ActivityTemplates",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "ActivityName",
                table: "ActivityTemplates",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "TimeCreated",
                table: "Activities",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Activities",
                type: "decimal(20,2)",
                precision: 20,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "ActivityName",
                table: "Activities",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ActivityDate",
                table: "Activities",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<int>(
                name: "AccountType",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AccountName",
                table: "Accounts",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityTemplates_Portfolios_PortfolioID",
                table: "ActivityTemplates",
                column: "PortfolioID",
                principalTable: "Portfolios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityTemplates_Portfolios_PortfolioID",
                table: "ActivityTemplates");

            migrationBuilder.DropColumn(
                name: "ActivityName",
                table: "ActivityTemplates");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "TimeAdded",
                table: "Portfolios",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<string>(
                name: "PortfolioName",
                table: "Portfolios",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Couterparties",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "DisplayText",
                table: "Couterparties",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "TemplateName",
                table: "ActivityTemplates",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ActivityNameTemplateStringID",
                table: "ActivityTemplates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "TimeCreated",
                table: "Activities",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Activities",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20,2)",
                oldPrecision: 20,
                oldScale: 2,
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "ActivityName",
                table: "Activities",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ActivityDate",
                table: "Activities",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<int>(
                name: "AccountType",
                table: "Accounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "AccountName",
                table: "Accounts",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldDefaultValue: "");

            migrationBuilder.CreateTable(
                name: "ActivityTemplateFields",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accessibility = table.Column<int>(type: "int", nullable: false),
                    FieldCaption = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FieldType = table.Column<int>(type: "int", nullable: false),
                    TemplateID = table.Column<int>(type: "int", nullable: false)
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
                name: "TemplateStrings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CanEdit = table.Column<bool>(type: "bit", nullable: false),
                    DataType = table.Column<int>(type: "int", nullable: false),
                    PortfolioID = table.Column<int>(type: "int", nullable: false)
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
                name: "TemplateStringParts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArrayIndex = table.Column<int>(type: "int", nullable: false),
                    ArrayType = table.Column<int>(type: "int", nullable: false),
                    FieldType = table.Column<int>(type: "int", nullable: false),
                    FixedText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PartType = table.Column<int>(type: "int", nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    TemplateStringID = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_TemplateStringParts_TemplateStringID_Sequence",
                table: "TemplateStringParts",
                columns: new[] { "TemplateStringID", "Sequence" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TemplateStrings_PortfolioID",
                table: "TemplateStrings",
                column: "PortfolioID");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityTemplates_Portfolios_PortfolioID",
                table: "ActivityTemplates",
                column: "PortfolioID",
                principalTable: "Portfolios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

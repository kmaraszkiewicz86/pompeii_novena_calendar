using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PompeiiNovenaCalendar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_new_table_with_rossary_localization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "RosaryTypes");

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "RosaryTypes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "RosaryTypeLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Key = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Language = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RosaryTypeLocalizations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "RosaryTypeLocalizations",
                columns: new[] { "Id", "Key", "Language", "Name" },
                values: new object[,]
                {
                    { 1, "JoyfulMysteries", "pl", "Tajemnice radosne" },
                    { 2, "SorrowfulMysteries", "pl", "Tajemnice bolesne" },
                    { 3, "GloriousMysteries", "pl", "Tajemnice chwalebne" },
                    { 4, "LuminousMysteries", "pl", "Tajemnice światła" },
                    { 5, "JoyfulMysteries", "en", "Joyful Mysteries" },
                    { 6, "SorrowfulMysteries", "en", "Sorrowful Mysteries" },
                    { 7, "GloriousMysteries", "en", "Glorious Mysteries" },
                    { 8, "LuminousMysteries", "en", "Luminous Mysteries" }
                });

            migrationBuilder.UpdateData(
                table: "RosaryTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Key",
                value: "JoyfulMysteries");

            migrationBuilder.UpdateData(
                table: "RosaryTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Key",
                value: "SorrowfulMysteries");

            migrationBuilder.UpdateData(
                table: "RosaryTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Key",
                value: "GloriousMysteries");

            migrationBuilder.UpdateData(
                table: "RosaryTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Key",
                value: "LuminousMysteries");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RosaryTypeLocalizations");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "RosaryTypes");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "RosaryTypes",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "RosaryTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Tajemnice radosne");

            migrationBuilder.UpdateData(
                table: "RosaryTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Tajemnice bolesne");

            migrationBuilder.UpdateData(
                table: "RosaryTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Tajemnice chwalebne");

            migrationBuilder.UpdateData(
                table: "RosaryTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Tajemnice światła");
        }
    }
}

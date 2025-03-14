using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PompeiiNovenaCalendar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DayRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsCompleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RosaryTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RosaryTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RosarySelections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RosaryTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    DayRecordId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsCompleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RosarySelections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RosarySelections_DayRecords_DayRecordId",
                        column: x => x.DayRecordId,
                        principalTable: "DayRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RosarySelections_RosaryTypes_RosaryTypeId",
                        column: x => x.RosaryTypeId,
                        principalTable: "RosaryTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RosaryTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Tajemnice radosne" },
                    { 2, "Tajemnice bolesne" },
                    { 3, "Tajemnice chwalebne" },
                    { 4, "Tajemnice światła" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RosarySelections_DayRecordId",
                table: "RosarySelections",
                column: "DayRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_RosarySelections_RosaryTypeId",
                table: "RosarySelections",
                column: "RosaryTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RosarySelections");

            migrationBuilder.DropTable(
                name: "DayRecords");

            migrationBuilder.DropTable(
                name: "RosaryTypes");
        }
    }
}

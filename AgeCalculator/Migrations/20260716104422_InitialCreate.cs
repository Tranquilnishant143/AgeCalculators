using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgeCalculator.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgeCalculations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    AgeAtDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Years = table.Column<int>(type: "int", nullable: false),
                    Months = table.Column<int>(type: "int", nullable: false),
                    Days = table.Column<int>(type: "int", nullable: false),
                    TotalDays = table.Column<int>(type: "int", nullable: false),
                    TotalWeeks = table.Column<int>(type: "int", nullable: false),
                    TotalHours = table.Column<long>(type: "bigint", nullable: false),
                    TotalMinutes = table.Column<long>(type: "bigint", nullable: false),
                    TotalSeconds = table.Column<long>(type: "bigint", nullable: false),
                    NextBirthday = table.Column<DateOnly>(type: "date", nullable: false),
                    DaysLeft = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgeCalculations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgeCalculations");
        }
    }
}

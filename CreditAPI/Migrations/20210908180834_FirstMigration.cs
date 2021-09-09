using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CreditAPI.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ScoringDate",
                table: "Applications",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ScoringStatus",
                table: "Applications",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScoringDate",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "ScoringStatus",
                table: "Applications");
        }
    }
}

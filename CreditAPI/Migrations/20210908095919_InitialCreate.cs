using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CreditAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    DateBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CityBirth = table.Column<string>(type: "text", nullable: true),
                    AddressBirth = table.Column<string>(type: "text", nullable: true),
                    AddressCurrent = table.Column<string>(type: "text", nullable: true),
                    INN = table.Column<string>(type: "text", nullable: true),
                    SNILS = table.Column<string>(type: "text", nullable: true),
                    PassportNum = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestedCredits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreditType = table.Column<int>(type: "integer", nullable: true),
                    RequestAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    RequestCurrency = table.Column<string>(type: "text", nullable: true),
                    AnnualSalary = table.Column<decimal>(type: "numeric", nullable: true),
                    MonthlySalary = table.Column<decimal>(type: "numeric", nullable: true),
                    CompanyName = table.Column<string>(type: "text", nullable: true),
                    Comment = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestedCredits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicationNum = table.Column<string>(type: "text", nullable: false),
                    ApplicationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    BranchBank = table.Column<string>(type: "text", nullable: true),
                    BranchBankAddr = table.Column<string>(type: "text", nullable: true),
                    CreditManagerId = table.Column<int>(type: "integer", nullable: true),
                    ApplicantId = table.Column<int>(type: "integer", nullable: false),
                    RequestedCreditId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applications_Persons_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Applications_RequestedCredits_RequestedCreditId",
                        column: x => x.RequestedCreditId,
                        principalTable: "RequestedCredits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ApplicantId",
                table: "Applications",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_RequestedCreditId",
                table: "Applications",
                column: "RequestedCreditId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "RequestedCredits");
        }
    }
}

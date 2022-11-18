using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientModuleService.Migrations
{
    public partial class PatientVitalsTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    VisitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.VisitId);
                });

            migrationBuilder.CreateTable(
                name: "PatientVitals",
                columns: table => new
                {
                    VisitVitalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitId = table.Column<int>(nullable: false),
                    Height = table.Column<string>(nullable: true),
                    Weight = table.Column<string>(nullable: true),
                    BloodPressure = table.Column<string>(nullable: true),
                    BodyTemperature = table.Column<string>(nullable: true),
                    RespirationRate = table.Column<string>(nullable: true),
                    createdby = table.Column<int>(nullable: false),
                    createdon = table.Column<DateTime>(nullable: false),
                    updatedby = table.Column<int>(nullable: false),
                    updatedon = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientVitals", x => x.VisitVitalId);
                    table.ForeignKey(
                        name: "FK_PatientVitals_Appointments_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Appointments",
                        principalColumn: "VisitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientVitals_VisitId",
                table: "PatientVitals",
                column: "VisitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientVitals");

            migrationBuilder.DropTable(
                name: "Appointments");
        }
    }
}

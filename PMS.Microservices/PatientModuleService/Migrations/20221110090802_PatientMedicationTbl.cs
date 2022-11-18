using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientModuleService.Migrations
{
    public partial class PatientMedicationTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatientMedication",
                columns: table => new
                {
                    PatientMedicationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitId = table.Column<int>(nullable: false),
                    DrugId = table.Column<int>(nullable: false),
                    Dosage = table.Column<string>(nullable: true),
                    Frequency = table.Column<string>(nullable: true),
                    createdby = table.Column<int>(nullable: false),
                    createdon = table.Column<DateTime>(nullable: false),
                    updatedby = table.Column<int>(nullable: false),
                    updatedon = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMedication", x => x.PatientMedicationId);
                    table.ForeignKey(
                        name: "FK_PatientMedication_DrugDataDetails_DrugId",
                        column: x => x.DrugId,
                        principalTable: "DrugDataDetails",
                        principalColumn: "DrugId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientMedication_Appointments_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Appointments",
                        principalColumn: "VisitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedication_DrugId",
                table: "PatientMedication",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedication_VisitId",
                table: "PatientMedication",
                column: "VisitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientMedication");
        }
    }
}

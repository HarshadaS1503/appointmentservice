using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientModuleService.Migrations
{
    public partial class PatientDiagnosisTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatientDiagnosis",
                columns: table => new
                {
                    PatientDiagnosisId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitId = table.Column<int>(nullable: false),
                    DiagnosisId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    createdby = table.Column<int>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    updated_by = table.Column<int>(nullable: false),
                    updated_on = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientDiagnosis", x => x.PatientDiagnosisId);
                    table.ForeignKey(
                        name: "FK_PatientDiagnosis_DiagnosisDetails_DiagnosisId",
                        column: x => x.DiagnosisId,
                        principalTable: "DiagnosisDetails",
                        principalColumn: "DiagnosisId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientDiagnosis_Appointments_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Appointments",
                        principalColumn: "VisitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientDiagnosis_DiagnosisId",
                table: "PatientDiagnosis",
                column: "DiagnosisId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDiagnosis_VisitId",
                table: "PatientDiagnosis",
                column: "VisitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientDiagnosis");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientModuleService.Migrations
{
    public partial class PatientAllergyDetailsTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatientAllergyDetails",
                columns: table => new
                {
                    PatientAllergyDetailsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(nullable: false),
                    Allergyid = table.Column<int>(nullable: false),
                    VisitId = table.Column<int>(nullable: false),
                    Is_Allergy_Fatal = table.Column<bool>(nullable: false),
                    Allergy_Clinical_Information = table.Column<string>(nullable: true),
                    created_by = table.Column<int>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    updated_by = table.Column<int>(nullable: false),
                    updated_on = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAllergyDetails", x => x.PatientAllergyDetailsId);
                    table.ForeignKey(
                        name: "FK_PatientAllergyDetails_AllergyDetails_Allergyid",
                        column: x => x.Allergyid,
                        principalTable: "AllergyDetails",
                        principalColumn: "AllergyDetailsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientAllergyDetails_ApplicationUser_PatientId",
                        column: x => x.PatientId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientAllergyDetails_Appointments_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Appointments",
                        principalColumn: "VisitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientAllergyDetails_Allergyid",
                table: "PatientAllergyDetails",
                column: "Allergyid");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAllergyDetails_PatientId",
                table: "PatientAllergyDetails",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAllergyDetails_VisitId",
                table: "PatientAllergyDetails",
                column: "VisitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientAllergyDetails");
        }
    }
}

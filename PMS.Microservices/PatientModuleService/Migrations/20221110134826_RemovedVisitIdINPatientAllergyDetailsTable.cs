using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientModuleService.Migrations
{
    public partial class RemovedVisitIdINPatientAllergyDetailsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientAllergyDetails_Appointments_VisitId",
                table: "PatientAllergyDetails");

            migrationBuilder.DropIndex(
                name: "IX_PatientAllergyDetails_VisitId",
                table: "PatientAllergyDetails");

            migrationBuilder.DropColumn(
                name: "VisitId",
                table: "PatientAllergyDetails");

            migrationBuilder.AlterColumn<long>(
                name: "Contact",
                table: "PatientEmergencyContacts",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Contact",
                table: "PatientEmergencyContacts",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<int>(
                name: "VisitId",
                table: "PatientAllergyDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PatientAllergyDetails_VisitId",
                table: "PatientAllergyDetails",
                column: "VisitId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientAllergyDetails_Appointments_VisitId",
                table: "PatientAllergyDetails",
                column: "VisitId",
                principalTable: "Appointments",
                principalColumn: "VisitId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

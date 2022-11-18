using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientModuleService.Migrations
{
    public partial class Addusertbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUser_Gender_GenderID",
                table: "ApplicationUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUser_Roles_RoleID",
                table: "ApplicationUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUser_Status_StatusID",
                table: "ApplicationUser");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientAllergyDetails_ApplicationUser_PatientId",
                table: "PatientAllergyDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientEmergencyContacts_ApplicationUser_PatientId",
                table: "PatientEmergencyContacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUser",
                table: "ApplicationUser");

            migrationBuilder.RenameTable(
                name: "ApplicationUser",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUser_StatusID",
                table: "Users",
                newName: "IX_Users_StatusID");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUser_RoleID",
                table: "Users",
                newName: "IX_Users_RoleID");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUser_GenderID",
                table: "Users",
                newName: "IX_Users_GenderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientAllergyDetails_Users_PatientId",
                table: "PatientAllergyDetails",
                column: "PatientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientEmergencyContacts_Users_PatientId",
                table: "PatientEmergencyContacts",
                column: "PatientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Gender_GenderID",
                table: "Users",
                column: "GenderID",
                principalTable: "Gender",
                principalColumn: "GenderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleID",
                table: "Users",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Status_StatusID",
                table: "Users",
                column: "StatusID",
                principalTable: "Status",
                principalColumn: "StatusID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientAllergyDetails_Users_PatientId",
                table: "PatientAllergyDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientEmergencyContacts_Users_PatientId",
                table: "PatientEmergencyContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Gender_GenderID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Status_StatusID",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "ApplicationUser");

            migrationBuilder.RenameIndex(
                name: "IX_Users_StatusID",
                table: "ApplicationUser",
                newName: "IX_ApplicationUser_StatusID");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoleID",
                table: "ApplicationUser",
                newName: "IX_ApplicationUser_RoleID");

            migrationBuilder.RenameIndex(
                name: "IX_Users_GenderID",
                table: "ApplicationUser",
                newName: "IX_ApplicationUser_GenderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUser",
                table: "ApplicationUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUser_Gender_GenderID",
                table: "ApplicationUser",
                column: "GenderID",
                principalTable: "Gender",
                principalColumn: "GenderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUser_Roles_RoleID",
                table: "ApplicationUser",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUser_Status_StatusID",
                table: "ApplicationUser",
                column: "StatusID",
                principalTable: "Status",
                principalColumn: "StatusID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientAllergyDetails_ApplicationUser_PatientId",
                table: "PatientAllergyDetails",
                column: "PatientId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientEmergencyContacts_ApplicationUser_PatientId",
                table: "PatientEmergencyContacts",
                column: "PatientId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

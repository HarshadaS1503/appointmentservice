using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientModuleService.Migrations
{
    public partial class patientModulev1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ethinicity",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguagesKnown",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Race",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ethinicity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LanguagesKnown",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Race",
                table: "Users");
        }
    }
}

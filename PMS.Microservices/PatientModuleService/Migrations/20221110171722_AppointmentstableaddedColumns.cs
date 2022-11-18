using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientModuleService.Migrations
{
    public partial class AppointmentstableaddedColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VisitDescription",
                table: "Appointments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VisitTitle",
                table: "Appointments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VisitDescription",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "VisitTitle",
                table: "Appointments");
        }
    }
}

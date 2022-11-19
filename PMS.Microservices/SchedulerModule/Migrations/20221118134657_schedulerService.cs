using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulerModule.Migrations
{
    public partial class schedulerService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "appointmentDetails",
                columns: table => new
                {
                    VisitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    doctorId = table.Column<int>(type: "int", nullable: false),
                    patientId = table.Column<int>(type: "int", nullable: false),
                    visitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    visitTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<int>(type: "int", nullable: false),
                    createdOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedBy = table.Column<int>(type: "int", nullable: false),
                    updatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    visitStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointmentDetails", x => x.VisitId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointmentDetails");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientModuleService.Migrations
{
    public partial class PatientProceduresTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatientProcedures",
                columns: table => new
                {
                    PatientProceduresId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitId = table.Column<int>(nullable: false),
                    ProcedureId = table.Column<int>(nullable: false),
                    createdby = table.Column<int>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    updated_by = table.Column<int>(nullable: false),
                    updated_on = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientProcedures", x => x.PatientProceduresId);
                    table.ForeignKey(
                        name: "FK_PatientProcedures_ProcedureDetails_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "ProcedureDetails",
                        principalColumn: "ProcedureId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientProcedures_Appointments_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Appointments",
                        principalColumn: "VisitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientProcedures_ProcedureId",
                table: "PatientProcedures",
                column: "ProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientProcedures_VisitId",
                table: "PatientProcedures",
                column: "VisitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientProcedures");
        }
    }
}

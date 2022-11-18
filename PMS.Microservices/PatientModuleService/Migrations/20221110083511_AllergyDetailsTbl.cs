using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientModuleService.Migrations
{
    public partial class AllergyDetailsTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AllergyDetails",
                columns: table => new
                {
                    AllergyDetailsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllergyId = table.Column<string>(nullable: true),
                    AllergyType = table.Column<string>(nullable: true),
                    AllergyName = table.Column<string>(nullable: true),
                    AllergyDescription = table.Column<string>(nullable: true),
                    AllergyClinicalInformation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergyDetails", x => x.AllergyDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "DiagnosisDetails",
                columns: table => new
                {
                    DiagnosisId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiagnosisCode = table.Column<string>(nullable: true),
                    DiagnosisDescription = table.Column<string>(nullable: true),
                    DiagnosisIsDepricated = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosisDetails", x => x.DiagnosisId);
                });

            migrationBuilder.CreateTable(
                name: "DrugDataDetails",
                columns: table => new
                {
                    DrugId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrugName = table.Column<string>(nullable: true),
                    DrugGenericName = table.Column<string>(nullable: true),
                    DrugManufactureName = table.Column<string>(nullable: true),
                    DrugForm = table.Column<string>(nullable: true),
                    DrugStrength = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugDataDetails", x => x.DrugId);
                });

            migrationBuilder.CreateTable(
                name: "ProcedureDetails",
                columns: table => new
                {
                    ProcedureId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcedureCode = table.Column<string>(nullable: true),
                    ProcedureDescription = table.Column<string>(nullable: true),
                    ProcedureIsDepricated = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedureDetails", x => x.ProcedureId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllergyDetails");

            migrationBuilder.DropTable(
                name: "DiagnosisDetails");

            migrationBuilder.DropTable(
                name: "DrugDataDetails");

            migrationBuilder.DropTable(
                name: "ProcedureDetails");
        }
    }
}

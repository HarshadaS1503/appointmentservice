using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulerModule.Migrations
{
    public partial class AptdetailsTbl1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointmentDetails_UserLogin_usersid",
                table: "appointmentDetails");

            migrationBuilder.DropColumn(
                name: "visitStatus",
                table: "appointmentDetails");

            migrationBuilder.RenameColumn(
                name: "usersid",
                table: "appointmentDetails",
                newName: "usersId");

            migrationBuilder.RenameIndex(
                name: "IX_appointmentDetails_usersid",
                table: "appointmentDetails",
                newName: "IX_appointmentDetails_usersId");

            migrationBuilder.AlterColumn<int>(
                name: "updatedBy",
                table: "appointmentDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "createdBy",
                table: "appointmentDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "visitStatusId",
                table: "appointmentDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_appointmentDetails_Users_usersId",
                table: "appointmentDetails",
                column: "usersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointmentDetails_Users_usersId",
                table: "appointmentDetails");

            migrationBuilder.DropColumn(
                name: "visitStatusId",
                table: "appointmentDetails");

            migrationBuilder.RenameColumn(
                name: "usersId",
                table: "appointmentDetails",
                newName: "usersid");

            migrationBuilder.RenameIndex(
                name: "IX_appointmentDetails_usersId",
                table: "appointmentDetails",
                newName: "IX_appointmentDetails_usersid");

            migrationBuilder.AlterColumn<string>(
                name: "updatedBy",
                table: "appointmentDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "createdBy",
                table: "appointmentDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "visitStatus",
                table: "appointmentDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_appointmentDetails_UserLogin_usersid",
                table: "appointmentDetails",
                column: "usersid",
                principalTable: "UserLogin",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

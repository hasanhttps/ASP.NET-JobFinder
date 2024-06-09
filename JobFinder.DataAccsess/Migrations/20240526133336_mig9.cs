using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobFinder.DataAccsess.Migrations
{
    /// <inheritdoc />
    public partial class mig9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ProfileRequierments",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "StandartEntranceProccess",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "StateType",
                table: "Jobs");

            migrationBuilder.RenameColumn(
                name: "WorkingSchedule",
                table: "Jobs",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "VacancyUrl",
                table: "Jobs",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "VacancyCode",
                table: "Jobs",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Jobs",
                newName: "Experience");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxSalary",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinSalary",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CategoryId",
                table: "Jobs",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Categories_CategoryId",
                table: "Jobs",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Categories_CategoryId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_CategoryId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "MaxSalary",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "MinSalary",
                table: "Jobs");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Jobs",
                newName: "WorkingSchedule");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Jobs",
                newName: "VacancyUrl");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Jobs",
                newName: "VacancyCode");

            migrationBuilder.RenameColumn(
                name: "Experience",
                table: "Jobs",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfileRequierments",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StandartEntranceProccess",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StateType",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

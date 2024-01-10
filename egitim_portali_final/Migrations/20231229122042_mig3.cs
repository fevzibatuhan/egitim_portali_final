using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace egitim_portali_final.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_egitimAndTeachers_Educations_EducationId",
                table: "egitimAndTeachers");

            migrationBuilder.DropIndex(
                name: "IX_egitimAndTeachers_EducationId",
                table: "egitimAndTeachers");

            migrationBuilder.DropColumn(
                name: "EducationId",
                table: "egitimAndTeachers");

            migrationBuilder.AddColumn<string>(
                name: "Teachersıd",
                table: "Educations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Teachersıd",
                table: "Educations");

            migrationBuilder.AddColumn<int>(
                name: "EducationId",
                table: "egitimAndTeachers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_egitimAndTeachers_EducationId",
                table: "egitimAndTeachers",
                column: "EducationId");

            migrationBuilder.AddForeignKey(
                name: "FK_egitimAndTeachers_Educations_EducationId",
                table: "egitimAndTeachers",
                column: "EducationId",
                principalTable: "Educations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

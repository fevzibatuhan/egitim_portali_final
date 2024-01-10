using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace egitim_portali_final.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Teachersıd",
                table: "Educations",
                newName: "TeachersUserName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TeachersUserName",
                table: "Educations",
                newName: "Teachersıd");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutorCabinet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DirectionStudyTableRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_students_DirectionStudies_DirectionStudyId",
                table: "students"
            );

            migrationBuilder.DropPrimaryKey(name: "PK_DirectionStudies", table: "DirectionStudies");

            migrationBuilder.RenameTable(name: "DirectionStudies", newName: "direction_studies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_direction_studies",
                table: "direction_studies",
                column: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_students_direction_studies_DirectionStudyId",
                table: "students",
                column: "DirectionStudyId",
                principalTable: "direction_studies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_students_direction_studies_DirectionStudyId",
                table: "students"
            );

            migrationBuilder.DropPrimaryKey(
                name: "PK_direction_studies",
                table: "direction_studies"
            );

            migrationBuilder.RenameTable(name: "direction_studies", newName: "DirectionStudies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DirectionStudies",
                table: "DirectionStudies",
                column: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_students_DirectionStudies_DirectionStudyId",
                table: "students",
                column: "DirectionStudyId",
                principalTable: "DirectionStudies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
            );
        }
    }
}

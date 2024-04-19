using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Departmant2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmantHasMajorClasses_MajorClasses_MajorHasClassId",
                table: "DepartmantHasMajorClasses");

            migrationBuilder.RenameColumn(
                name: "MajorHasClassId",
                table: "DepartmantHasMajorClasses",
                newName: "StudentHasMajorHasClassId");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmantHasMajorClasses_MajorHasClassId",
                table: "DepartmantHasMajorClasses",
                newName: "IX_DepartmantHasMajorClasses_StudentHasMajorHasClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmantHasMajorClasses_StudenthasMajorClasses_StudentHasMajorHasClassId",
                table: "DepartmantHasMajorClasses",
                column: "StudentHasMajorHasClassId",
                principalTable: "StudenthasMajorClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmantHasMajorClasses_StudenthasMajorClasses_StudentHasMajorHasClassId",
                table: "DepartmantHasMajorClasses");

            migrationBuilder.RenameColumn(
                name: "StudentHasMajorHasClassId",
                table: "DepartmantHasMajorClasses",
                newName: "MajorHasClassId");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmantHasMajorClasses_StudentHasMajorHasClassId",
                table: "DepartmantHasMajorClasses",
                newName: "IX_DepartmantHasMajorClasses_MajorHasClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmantHasMajorClasses_MajorClasses_MajorHasClassId",
                table: "DepartmantHasMajorClasses",
                column: "MajorHasClassId",
                principalTable: "MajorClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

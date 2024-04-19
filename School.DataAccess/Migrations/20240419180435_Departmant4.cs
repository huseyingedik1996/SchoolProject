using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Departmant4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsDepartmant_DepartmantHasMajorClasses_DepartmantHasMinorClassId",
                table: "StudentsDepartmant");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsDepartmant_Students_StudentsId",
                table: "StudentsDepartmant");

            migrationBuilder.DropIndex(
                name: "IX_StudentsDepartmant_DepartmantHasMinorClassId",
                table: "StudentsDepartmant");

            migrationBuilder.DropColumn(
                name: "DepartmantHasMajorClass",
                table: "StudentsDepartmant");

            migrationBuilder.DropColumn(
                name: "DepartmantHasMinorClassId",
                table: "StudentsDepartmant");

            migrationBuilder.RenameColumn(
                name: "StudentsId",
                table: "StudentsDepartmant",
                newName: "DepartmantHasMajorClassId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentsDepartmant_StudentsId",
                table: "StudentsDepartmant",
                newName: "IX_StudentsDepartmant_DepartmantHasMajorClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsDepartmant_StudentId",
                table: "StudentsDepartmant",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsDepartmant_DepartmantHasMajorClasses_DepartmantHasMajorClassId",
                table: "StudentsDepartmant",
                column: "DepartmantHasMajorClassId",
                principalTable: "DepartmantHasMajorClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsDepartmant_Students_StudentId",
                table: "StudentsDepartmant",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsDepartmant_DepartmantHasMajorClasses_DepartmantHasMajorClassId",
                table: "StudentsDepartmant");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsDepartmant_Students_StudentId",
                table: "StudentsDepartmant");

            migrationBuilder.DropIndex(
                name: "IX_StudentsDepartmant_StudentId",
                table: "StudentsDepartmant");

            migrationBuilder.RenameColumn(
                name: "DepartmantHasMajorClassId",
                table: "StudentsDepartmant",
                newName: "StudentsId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentsDepartmant_DepartmantHasMajorClassId",
                table: "StudentsDepartmant",
                newName: "IX_StudentsDepartmant_StudentsId");

            migrationBuilder.AddColumn<int>(
                name: "DepartmantHasMajorClass",
                table: "StudentsDepartmant",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmantHasMinorClassId",
                table: "StudentsDepartmant",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudentsDepartmant_DepartmantHasMinorClassId",
                table: "StudentsDepartmant",
                column: "DepartmantHasMinorClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsDepartmant_DepartmantHasMajorClasses_DepartmantHasMinorClassId",
                table: "StudentsDepartmant",
                column: "DepartmantHasMinorClassId",
                principalTable: "DepartmantHasMajorClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsDepartmant_Students_StudentsId",
                table: "StudentsDepartmant",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

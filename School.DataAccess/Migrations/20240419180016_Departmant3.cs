using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Departmant3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "StudentsDepartmant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    DepartmantHasMajorClass = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentsId = table.Column<int>(type: "INTEGER", nullable: false),
                    DepartmantHasMinorClassId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsDepartmant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentsDepartmant_DepartmantHasMajorClasses_DepartmantHasMinorClassId",
                        column: x => x.DepartmantHasMinorClassId,
                        principalTable: "DepartmantHasMajorClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsDepartmant_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentsDepartmant_DepartmantHasMinorClassId",
                table: "StudentsDepartmant",
                column: "DepartmantHasMinorClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsDepartmant_StudentsId",
                table: "StudentsDepartmant",
                column: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmantHasMajorClasses_MajorClasses_MajorHasClassId",
                table: "DepartmantHasMajorClasses",
                column: "MajorHasClassId",
                principalTable: "MajorClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmantHasMajorClasses_MajorClasses_MajorHasClassId",
                table: "DepartmantHasMajorClasses");

            migrationBuilder.DropTable(
                name: "StudentsDepartmant");

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
    }
}

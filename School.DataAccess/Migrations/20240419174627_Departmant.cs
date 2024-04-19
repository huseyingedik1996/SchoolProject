using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Departmant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BranchName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepartmantNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmantNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepartmantHasMajorClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DepartmantId = table.Column<int>(type: "INTEGER", nullable: false),
                    MajorHasClassId = table.Column<int>(type: "INTEGER", nullable: false),
                    DepartmantNameId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmantHasMajorClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmantHasMajorClasses_DepartmantNames_DepartmantNameId",
                        column: x => x.DepartmantNameId,
                        principalTable: "DepartmantNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmantHasMajorClasses_MajorClasses_MajorHasClassId",
                        column: x => x.MajorHasClassId,
                        principalTable: "MajorClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmantHasMajorClasses_DepartmantNameId",
                table: "DepartmantHasMajorClasses",
                column: "DepartmantNameId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmantHasMajorClasses_MajorHasClassId",
                table: "DepartmantHasMajorClasses",
                column: "MajorHasClassId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "DepartmantHasMajorClasses");

            migrationBuilder.DropTable(
                name: "DepartmantNames");
        }
    }
}

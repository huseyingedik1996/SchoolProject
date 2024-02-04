using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace School.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MigStudenthasClassesMajor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Students",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParentsId",
                table: "Students",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StudenthasMajorClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentsId = table.Column<int>(type: "integer", nullable: false),
                    MajorhasClassesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudenthasMajorClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudenthasMajorClasses_MajorClasses_MajorhasClassesId",
                        column: x => x.MajorhasClassesId,
                        principalTable: "MajorClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudenthasMajorClasses_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_ParentsId",
                table: "Students",
                column: "ParentsId");

            migrationBuilder.CreateIndex(
                name: "IX_StudenthasMajorClasses_MajorhasClassesId",
                table: "StudenthasMajorClasses",
                column: "MajorhasClassesId");

            migrationBuilder.CreateIndex(
                name: "IX_StudenthasMajorClasses_StudentsId",
                table: "StudenthasMajorClasses",
                column: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Parents_ParentsId",
                table: "Students",
                column: "ParentsId",
                principalTable: "Parents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Parents_ParentsId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "StudenthasMajorClasses");

            migrationBuilder.DropIndex(
                name: "IX_Students_ParentsId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ParentsId",
                table: "Students");
        }
    }
}

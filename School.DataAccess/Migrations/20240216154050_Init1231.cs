using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Init1231 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Parents_ParentId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ParentId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Parents",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentsId",
                table: "Parents",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Parents_StudentsId",
                table: "Parents",
                column: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_Students_StudentsId",
                table: "Parents",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parents_Students_StudentsId",
                table: "Parents");

            migrationBuilder.DropIndex(
                name: "IX_Parents_StudentsId",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "StudentsId",
                table: "Parents");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Students",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_ParentId",
                table: "Students",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Parents_ParentId",
                table: "Students",
                column: "ParentId",
                principalTable: "Parents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

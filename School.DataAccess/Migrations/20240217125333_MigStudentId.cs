using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MigStudentId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parents_Students_StudentsId",
                table: "Parents");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_AppUserId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_AppUserId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Parents_StudentsId",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentsId",
                table: "Parents");

            migrationBuilder.AddColumn<int>(
                name: "StudentsId",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Parents_StudentId",
                table: "Parents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StudentsId",
                table: "AspNetUsers",
                column: "StudentsId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Students_StudentsId",
                table: "AspNetUsers",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_Students_StudentId",
                table: "Parents",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Students_StudentsId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Parents_Students_StudentId",
                table: "Parents");

            migrationBuilder.DropIndex(
                name: "IX_Parents_StudentId",
                table: "Parents");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StudentsId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StudentsId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Students",
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
                name: "IX_Students_AppUserId",
                table: "Students",
                column: "AppUserId",
                unique: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_AppUserId",
                table: "Students",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

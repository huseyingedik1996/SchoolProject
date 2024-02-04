using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStudentNavigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Students_StudentsId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Students_StudentsId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Majors_Students_StudentsId",
                table: "Majors");

            migrationBuilder.DropForeignKey(
                name: "FK_Parents_Students_StudentsId",
                table: "Parents");

            migrationBuilder.DropIndex(
                name: "IX_Parents_StudentsId",
                table: "Parents");

            migrationBuilder.DropIndex(
                name: "IX_Majors_StudentsId",
                table: "Majors");

            migrationBuilder.DropIndex(
                name: "IX_Classes_StudentsId",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StudentsId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StudentsId",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "StudentsId",
                table: "Majors");

            migrationBuilder.DropColumn(
                name: "StudentsId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "StudentsId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Students",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_AppUserId",
                table: "Students",
                column: "AppUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_AppUserId",
                table: "Students",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_AppUserId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_AppUserId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "StudentsId",
                table: "Parents",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentsId",
                table: "Majors",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentsId",
                table: "Classes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentsId",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Parents_StudentsId",
                table: "Parents",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Majors_StudentsId",
                table: "Majors",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_StudentsId",
                table: "Classes",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StudentsId",
                table: "AspNetUsers",
                column: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Students_StudentsId",
                table: "AspNetUsers",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Students_StudentsId",
                table: "Classes",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Majors_Students_StudentsId",
                table: "Majors",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_Students_StudentsId",
                table: "Parents",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

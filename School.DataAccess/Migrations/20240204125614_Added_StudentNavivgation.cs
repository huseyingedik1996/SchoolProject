using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedStudentNavivgation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parents_Students_StudentsId",
                table: "Parents");

            migrationBuilder.AlterColumn<int>(
                name: "StudentsId",
                table: "Parents",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "StudentsId",
                table: "Parents",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_Students_StudentsId",
                table: "Parents",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}

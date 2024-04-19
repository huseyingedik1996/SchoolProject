using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Departmant6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "DepartmantNames",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "DepartmantNames");
        }
    }
}

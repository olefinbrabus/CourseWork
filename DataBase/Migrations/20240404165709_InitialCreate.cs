using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "courseWorks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisciplineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkTheme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeacherFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courseWorks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "graduateWorks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DegreeLevel = table.Column<int>(type: "int", nullable: false),
                    WorkTheme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeacherFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_graduateWorks", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "courseWorks");

            migrationBuilder.DropTable(
                name: "graduateWorks");
        }
    }
}

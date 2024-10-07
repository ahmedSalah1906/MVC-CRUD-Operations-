using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVC_day2_task1_the_lab_one.Migrations
{
    /// <inheritdoc />
    public partial class intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    degree = table.Column<int>(type: "int", nullable: false),
                    mindegree = table.Column<int>(type: "int", nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tranies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tranies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tranies_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructors_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Instructors_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tranieeCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    degree = table.Column<int>(type: "int", nullable: false),
                    Courseid = table.Column<int>(type: "int", nullable: true),
                    TranieeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tranieeCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tranieeCourses_Courses_Courseid",
                        column: x => x.Courseid,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tranieeCourses_Tranies_TranieeId",
                        column: x => x.TranieeId,
                        principalTable: "Tranies",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "ManagerName", "Name" },
                values: new object[,]
                {
                    { 1, "ali", "DOT NET" },
                    { 2, "ahmed", "PHP" },
                    { 3, "omar", "CS" },
                    { 4, "amr", "SD" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "DepartmentId", "Hours", "Name", "degree", "mindegree" },
                values: new object[,]
                {
                    { 1, 1, null, "OOP", 100, 60 },
                    { 2, 2, null, "HTML5", 100, 60 },
                    { 3, 3, null, "CSS3", 100, 60 },
                    { 4, 4, null, "EF", 100, 60 }
                });

            migrationBuilder.InsertData(
                table: "Tranies",
                columns: new[] { "Id", "DepartmentId", "Grade", "Name", "address", "imageUrl" },
                values: new object[,]
                {
                    { 1, 1, 98, "Ahmed", "Alex", "1.jpg" },
                    { 2, 1, 88, "Ismael", "Cairo", "2.jpg" },
                    { 3, 2, 78, "mohamed", "Tanta", "3.jpg" },
                    { 4, 2, 88, "Ahmed", "Gia", "4.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "CourseID", "DepartmentId", "Name", "address", "image_url", "salary" },
                values: new object[,]
                {
                    { 1, 1, 1, "ahmed", "cairo", "1.jpg", 12000m },
                    { 2, 2, 2, "ali", "alex", "2.jpg", 12500m },
                    { 3, 3, 3, "amr", "monufia", "3.jpg", 13000m },
                    { 4, 4, 4, "omar", "tanta", "4.jpg", 14000m }
                });

            migrationBuilder.InsertData(
                table: "tranieeCourses",
                columns: new[] { "Id", "Courseid", "TranieeId", "degree" },
                values: new object[,]
                {
                    { 1, 2, 1, 88 },
                    { 2, 1, 1, 98 },
                    { 3, 3, 1, 66 },
                    { 4, 4, 1, 40 },
                    { 5, 1, 2, 88 },
                    { 6, 4, 2, 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartmentId",
                table: "Courses",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_CourseID",
                table: "Instructors",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_DepartmentId",
                table: "Instructors",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_tranieeCourses_Courseid",
                table: "tranieeCourses",
                column: "Courseid");

            migrationBuilder.CreateIndex(
                name: "IX_tranieeCourses_TranieeId",
                table: "tranieeCourses",
                column: "TranieeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tranies_DepartmentId",
                table: "Tranies",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "tranieeCourses");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Tranies");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}

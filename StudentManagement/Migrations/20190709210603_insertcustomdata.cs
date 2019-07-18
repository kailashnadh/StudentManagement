using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagement.Migrations
{
    public partial class insertcustomdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Department", "Email", "Name" },
                values: new object[] { 1, 1, "mkailashnadh@gmail.com", "Kailash" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Department", "Email", "Name" },
                values: new object[] { 2, 3, "mounicayelchuri@gmail.com", "Mounica" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagementSystem.MainInfrastructure.Migrations
{
    public partial class RolesFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8691d119-f241-474a-bf88-3941618e5caf",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEHbQf/Y8sHRkceDXi+2TaTWyIQBRPL1crXBBD0RiGPlvm7Ra48Q+wUPR5uxtNOmbNg==", "c8adf49b-dd6d-4c3f-ae57-584618224020" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8691d119-f241-474a-bf88-3941618e5caf",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEOHYxswY4SMi9sB9YdJYLm6UrvQzOZ7GLy4lq6xZInRcHNPiDwT18HzziWc06KY6Fw==", "1c3d8ea3-9c32-4ee4-94ae-5bfc57543479" });
        }
    }
}

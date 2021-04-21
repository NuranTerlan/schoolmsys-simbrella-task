using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagementSystem.MainInfrastructure.Migrations
{
    public partial class AllRolesAddedToAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bcf2deb6-1dc6-4dfd-a8be-573f3f998af1", "8691d119-f241-474a-bf88-3941618e5caf" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9cd957ee-1c33-494e-b153-cc9a4a4edead", "8691d119-f241-474a-bf88-3941618e5caf" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8691d119-f241-474a-bf88-3941618e5caf",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEOHYxswY4SMi9sB9YdJYLm6UrvQzOZ7GLy4lq6xZInRcHNPiDwT18HzziWc06KY6Fw==", "1c3d8ea3-9c32-4ee4-94ae-5bfc57543479" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9cd957ee-1c33-494e-b153-cc9a4a4edead", "8691d119-f241-474a-bf88-3941618e5caf" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bcf2deb6-1dc6-4dfd-a8be-573f3f998af1", "8691d119-f241-474a-bf88-3941618e5caf" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8691d119-f241-474a-bf88-3941618e5caf",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEMcAwJQuYrZPAeD0vgW5ikcLWmKLGW86Al6OGKo86T2UFCSjGslXbDKFZ4oGYup0Tw==", "ee961eb5-5868-45a0-af40-400f817ea544" });
        }
    }
}

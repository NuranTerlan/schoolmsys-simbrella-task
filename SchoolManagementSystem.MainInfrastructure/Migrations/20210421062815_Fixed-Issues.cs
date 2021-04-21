using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagementSystem.MainInfrastructure.Migrations
{
    public partial class FixedIssues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_Roles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_Roles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.AlterColumn<string>(
                name: "IndividualRoom",
                table: "Teachers",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a1bb5179-59a8-471e-a29a-90065b471062", "a1bb5179-59a8-471e-a29a-90065b471062", "Admin", "ADMIN" },
                    { "bcf2deb6-1dc6-4dfd-a8be-573f3f998af1", "bcf2deb6-1dc6-4dfd-a8be-573f3f998af1", "Teacher", "TEACHER" },
                    { "9cd957ee-1c33-494e-b153-cc9a4a4edead", "9cd957ee-1c33-494e-b153-cc9a4a4edead", "Student", "STUDENT" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8691d119-f241-474a-bf88-3941618e5caf",
                columns: new[] { "PasswordHash", "SecurityStamp", "TwoFactorEnabled" },
                values: new object[] { "AQAAAAEAACcQAAAAEKEcr3Lv2BkqN9mG1H949nzGRuP3Q5NdYdwHKmRAAgqvZynBu+zRX8uc0AuR4MLV6g==", "75fa774e-4735-4e20-a89c-3084b1388480", true });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.AlterColumn<string>(
                name: "IndividualRoom",
                table: "Teachers",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a1bb5179-59a8-471e-a29a-90065b471062", "a1bb5179-59a8-471e-a29a-90065b471062", "Admin can manage everything in app", "Admin", "ADMIN" },
                    { "bcf2deb6-1dc6-4dfd-a8be-573f3f998af1", "bcf2deb6-1dc6-4dfd-a8be-573f3f998af1", "Teacher can report, schedule exam dates, give marks etc.", "Teacher", "TEACHER" },
                    { "9cd957ee-1c33-494e-b153-cc9a4a4edead", "9cd957ee-1c33-494e-b153-cc9a4a4edead", "Students can check their exam dates, marks etc.", "Student", "STUDENT" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8691d119-f241-474a-bf88-3941618e5caf",
                columns: new[] { "PasswordHash", "SecurityStamp", "TwoFactorEnabled" },
                values: new object[] { "AQAAAAEAACcQAAAAEOrztoNl4q2OY7u9AcQtM09w0Z+Cmj3/kt6Th6li1MqGkhLWZ41jAO5GMfKE8t3IIQ==", "5a213b7d-720f-42ac-b8e1-b8cde7c8cb80", false });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_Roles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_Roles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

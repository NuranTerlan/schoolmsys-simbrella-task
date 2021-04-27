using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagementSystem.MainInfrastructure.Migrations
{
    public partial class PsychologistAndItsRelationsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PsychologistId",
                table: "SchoolClasses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Psychologists",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IndividualRoom = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Psychologists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Psychologists_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "2403f407-e7bf-4c60-ade2-fc36f26afc55", "2403f407-e7bf-4c60-ade2-fc36f26afc55", "Psychologists can give motivation to students", "Psychologist", "PSYCHOLOGIST" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8691d119-f241-474a-bf88-3941618e5caf",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEOHryQF1W9sUqL7tMUkpukOSxOEcqxpnguR0orJav7hr2aJT2mzKSM81/6FVa6ChZA==", "c01455db-f141-4b24-9563-9fac69343c34" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2403f407-e7bf-4c60-ade2-fc36f26afc55", "8691d119-f241-474a-bf88-3941618e5caf" });

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClasses_PsychologistId",
                table: "SchoolClasses",
                column: "PsychologistId");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolClasses_Psychologists_PsychologistId",
                table: "SchoolClasses",
                column: "PsychologistId",
                principalTable: "Psychologists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolClasses_Psychologists_PsychologistId",
                table: "SchoolClasses");

            migrationBuilder.DropTable(
                name: "Psychologists");

            migrationBuilder.DropIndex(
                name: "IX_SchoolClasses_PsychologistId",
                table: "SchoolClasses");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2403f407-e7bf-4c60-ade2-fc36f26afc55", "8691d119-f241-474a-bf88-3941618e5caf" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2403f407-e7bf-4c60-ade2-fc36f26afc55");

            migrationBuilder.DropColumn(
                name: "PsychologistId",
                table: "SchoolClasses");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8691d119-f241-474a-bf88-3941618e5caf",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEHbQf/Y8sHRkceDXi+2TaTWyIQBRPL1crXBBD0RiGPlvm7Ra48Q+wUPR5uxtNOmbNg==", "c8adf49b-dd6d-4c3f-ae57-584618224020" });
        }
    }
}

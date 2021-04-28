using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagementSystem.MainInfrastructure.Migrations
{
    public partial class StudentTableUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "AbsentMarkCount",
                table: "Students",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8691d119-f241-474a-bf88-3941618e5caf",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEJNXj0Wc59LBvbk0iizILONUXY2JaudYeBmzQT8jxQNPWTy5Hnn1PiNWr5yMavSVjQ==", "ae868f51-56c3-45ff-86aa-24ed488cc9a0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AbsentMarkCount",
                table: "Students");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8691d119-f241-474a-bf88-3941618e5caf",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEOHryQF1W9sUqL7tMUkpukOSxOEcqxpnguR0orJav7hr2aJT2mzKSM81/6FVa6ChZA==", "c01455db-f141-4b24-9563-9fac69343c34" });
        }
    }
}

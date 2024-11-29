using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "028b0d6b-0954-45e2-bed1-e8a60c04792e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0431a597-94e4-414b-ba2a-73a88c639650");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b52a619-17bd-4e65-a5c7-02556b11dd93");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "72e979ee-20b6-43c9-8bfc-816aa86c0d48", "c809650d-ebfa-4d4b-8d8d-8bfd62ff14ca", "Admin", "admin" },
                    { "8f8f0222-f8f5-4383-baf4-f4c3555f782f", "7e049f72-a8dd-46fc-abd9-2cb96e9075a7", "Patient", "patient" },
                    { "d9bf452f-78c8-4bc3-8b9b-dbc2c169ff9c", "3b6672f1-b5df-4a10-960a-0209b60a0766", "Doctor", "doctor" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72e979ee-20b6-43c9-8bfc-816aa86c0d48");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f8f0222-f8f5-4383-baf4-f4c3555f782f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9bf452f-78c8-4bc3-8b9b-dbc2c169ff9c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "028b0d6b-0954-45e2-bed1-e8a60c04792e", "47d1217e-71d7-4264-a9d6-51c910ae8edf", "Admin", "admin" },
                    { "0431a597-94e4-414b-ba2a-73a88c639650", "9f56520b-cba2-45bc-a97b-e7b918b67727", "Patient", "patient" },
                    { "6b52a619-17bd-4e65-a5c7-02556b11dd93", "6a4e9874-b35a-48d9-a132-4fdec251736a", "Doctor", "doctor" }
                });
        }
    }
}

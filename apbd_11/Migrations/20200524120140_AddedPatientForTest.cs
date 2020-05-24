using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apbd_11.Migrations
{
    public partial class AddedPatientForTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "IdPatient", "BirthDate", "FirstName", "LastName" },
                values: new object[] { 3, new DateTime(1999, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "James", "McDonalds" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 3);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HairdresserBlazor.Migrations
{
    /// <inheritdoc />
    public partial class AddAppointments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "EndTime", "HairdresserId", "StartTime", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 8, 11, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2023, 3, 8, 10, 30, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2023, 3, 8, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2023, 3, 8, 11, 30, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2023, 3, 8, 11, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2023, 3, 8, 10, 30, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, new DateTime(2023, 3, 8, 8, 30, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2023, 3, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 5, new DateTime(2023, 4, 8, 8, 30, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2023, 4, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 6, new DateTime(2023, 2, 8, 8, 30, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2023, 2, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}

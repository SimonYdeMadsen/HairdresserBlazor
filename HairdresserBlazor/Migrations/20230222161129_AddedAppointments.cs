using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HairdresserBlazor.Migrations
{
    /// <inheritdoc />
    public partial class AddedAppointments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 2, 22, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 22, 10, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 2, 22, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 22, 11, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 2, 22, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 22, 10, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 2, 22, 8, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 22, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "EndTime", "HairdresserId", "StartTime", "UserId" },
                values: new object[,]
                {
                    { 5, new DateTime(2023, 3, 22, 8, 30, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2023, 3, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 6, new DateTime(2023, 1, 22, 8, 30, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2023, 1, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "33aa396b-18d6-4ed4-9dac-6820faad1c21");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "b830af09-8a58-47fe-9790-b5fe0a0537b5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "fffbe3cc-c909-4150-b81e-d77ea0aa444a");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 2, 21, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 21, 10, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 2, 21, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 21, 11, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 2, 21, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 21, 10, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 2, 21, 8, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 21, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "7d6b4c36-eb5b-4293-8f44-00891bbe36ba");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "47d264d4-fed0-4ab8-9bcf-5b87bc8b725c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "58e4d264-65e5-44b5-9e73-e0541e14492f");
        }
    }
}

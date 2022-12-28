using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessObject.Migrations
{
    public partial class AddServiceSeederAndNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 10, 15, 335, DateTimeKind.Utc).AddTicks(3681), new DateTime(2026, 12, 28, 7, 10, 15, 335, DateTimeKind.Utc).AddTicks(3681) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 10, 15, 335, DateTimeKind.Utc).AddTicks(3681), new DateTime(2026, 12, 28, 7, 10, 15, 335, DateTimeKind.Utc).AddTicks(3681) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 10, 15, 335, DateTimeKind.Utc).AddTicks(3681), new DateTime(2026, 12, 28, 7, 10, 15, 335, DateTimeKind.Utc).AddTicks(3681) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 10, 15, 335, DateTimeKind.Utc).AddTicks(3681), new DateTime(2026, 12, 28, 7, 10, 15, 335, DateTimeKind.Utc).AddTicks(3681) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 10, 15, 335, DateTimeKind.Utc).AddTicks(3681), new DateTime(2026, 12, 28, 7, 10, 15, 335, DateTimeKind.Utc).AddTicks(3681) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 10, 15, 335, DateTimeKind.Utc).AddTicks(3681), new DateTime(2026, 12, 28, 7, 10, 15, 335, DateTimeKind.Utc).AddTicks(3681) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 10, 15, 335, DateTimeKind.Utc).AddTicks(3681), new DateTime(2026, 12, 28, 7, 10, 15, 335, DateTimeKind.Utc).AddTicks(3681) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 10, 15, 335, DateTimeKind.Utc).AddTicks(3681), new DateTime(2026, 12, 28, 7, 10, 15, 335, DateTimeKind.Utc).AddTicks(3681) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 10, 15, 335, DateTimeKind.Utc).AddTicks(3681), new DateTime(2026, 12, 28, 7, 10, 15, 335, DateTimeKind.Utc).AddTicks(3681) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 10, 15, 335, DateTimeKind.Utc).AddTicks(3681), new DateTime(2026, 12, 28, 7, 10, 15, 335, DateTimeKind.Utc).AddTicks(3681) });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "Id", "AppointmentId", "CreatedBy", "CreatedDate", "DeletedDate", "IsDelete", "ServiceName", "ServicePrice", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(2022, 12, 28, 7, 10, 15, 336, DateTimeKind.Utc).AddTicks(6535), null, false, "Normal", 250000m, null, null },
                    { 2, null, null, new DateTime(2022, 12, 28, 7, 10, 15, 336, DateTimeKind.Utc).AddTicks(6535), null, false, "MRI scan", 300000m, null, null },
                    { 3, null, null, new DateTime(2022, 12, 28, 7, 10, 15, 336, DateTimeKind.Utc).AddTicks(6535), null, false, "General examination", 500000m, null, null },
                    { 4, null, null, new DateTime(2022, 12, 28, 7, 10, 15, 336, DateTimeKind.Utc).AddTicks(6535), null, false, "Detect Alzheimer's Disease", 1000000m, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 9, 3, 337, DateTimeKind.Utc).AddTicks(9557), new DateTime(2026, 12, 28, 7, 9, 3, 337, DateTimeKind.Utc).AddTicks(9557) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 9, 3, 337, DateTimeKind.Utc).AddTicks(9557), new DateTime(2026, 12, 28, 7, 9, 3, 337, DateTimeKind.Utc).AddTicks(9557) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 9, 3, 337, DateTimeKind.Utc).AddTicks(9557), new DateTime(2026, 12, 28, 7, 9, 3, 337, DateTimeKind.Utc).AddTicks(9557) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 9, 3, 337, DateTimeKind.Utc).AddTicks(9557), new DateTime(2026, 12, 28, 7, 9, 3, 337, DateTimeKind.Utc).AddTicks(9557) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 9, 3, 337, DateTimeKind.Utc).AddTicks(9557), new DateTime(2026, 12, 28, 7, 9, 3, 337, DateTimeKind.Utc).AddTicks(9557) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 9, 3, 337, DateTimeKind.Utc).AddTicks(9557), new DateTime(2026, 12, 28, 7, 9, 3, 337, DateTimeKind.Utc).AddTicks(9557) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 9, 3, 337, DateTimeKind.Utc).AddTicks(9557), new DateTime(2026, 12, 28, 7, 9, 3, 337, DateTimeKind.Utc).AddTicks(9557) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 9, 3, 337, DateTimeKind.Utc).AddTicks(9557), new DateTime(2026, 12, 28, 7, 9, 3, 337, DateTimeKind.Utc).AddTicks(9557) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 9, 3, 337, DateTimeKind.Utc).AddTicks(9557), new DateTime(2026, 12, 28, 7, 9, 3, 337, DateTimeKind.Utc).AddTicks(9557) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 9, 3, 337, DateTimeKind.Utc).AddTicks(9557), new DateTime(2026, 12, 28, 7, 9, 3, 337, DateTimeKind.Utc).AddTicks(9557) });
        }
    }
}

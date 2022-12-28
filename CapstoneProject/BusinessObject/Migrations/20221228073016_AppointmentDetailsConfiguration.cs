using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessObject.Migrations
{
    public partial class AppointmentDetailsConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointmentDetails_Appointment_AppointmentId",
                table: "appointmentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_appointmentDetails_Service_ServiceId",
                table: "appointmentDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_appointmentDetails",
                table: "appointmentDetails");

            migrationBuilder.RenameTable(
                name: "appointmentDetails",
                newName: "AppointmentDetails");

            migrationBuilder.RenameIndex(
                name: "IX_appointmentDetails_ServiceId",
                table: "AppointmentDetails",
                newName: "IX_AppointmentDetails_ServiceId");

            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "AppointmentDetails",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentDetails",
                table: "AppointmentDetails",
                columns: new[] { "AppointmentId", "ServiceId" });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 30, 16, 307, DateTimeKind.Utc).AddTicks(2270), new DateTime(2026, 12, 28, 7, 30, 16, 307, DateTimeKind.Utc).AddTicks(2270) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 30, 16, 307, DateTimeKind.Utc).AddTicks(2270), new DateTime(2026, 12, 28, 7, 30, 16, 307, DateTimeKind.Utc).AddTicks(2270) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 30, 16, 307, DateTimeKind.Utc).AddTicks(2270), new DateTime(2026, 12, 28, 7, 30, 16, 307, DateTimeKind.Utc).AddTicks(2270) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 30, 16, 307, DateTimeKind.Utc).AddTicks(2270), new DateTime(2026, 12, 28, 7, 30, 16, 307, DateTimeKind.Utc).AddTicks(2270) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 30, 16, 307, DateTimeKind.Utc).AddTicks(2270), new DateTime(2026, 12, 28, 7, 30, 16, 307, DateTimeKind.Utc).AddTicks(2270) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 30, 16, 307, DateTimeKind.Utc).AddTicks(2270), new DateTime(2026, 12, 28, 7, 30, 16, 307, DateTimeKind.Utc).AddTicks(2270) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 30, 16, 307, DateTimeKind.Utc).AddTicks(2270), new DateTime(2026, 12, 28, 7, 30, 16, 307, DateTimeKind.Utc).AddTicks(2270) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 30, 16, 307, DateTimeKind.Utc).AddTicks(2270), new DateTime(2026, 12, 28, 7, 30, 16, 307, DateTimeKind.Utc).AddTicks(2270) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 30, 16, 307, DateTimeKind.Utc).AddTicks(2270), new DateTime(2026, 12, 28, 7, 30, 16, 307, DateTimeKind.Utc).AddTicks(2270) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 30, 16, 307, DateTimeKind.Utc).AddTicks(2270), new DateTime(2026, 12, 28, 7, 30, 16, 307, DateTimeKind.Utc).AddTicks(2270) });

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 28, 7, 30, 16, 308, DateTimeKind.Utc).AddTicks(7527));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 28, 7, 30, 16, 308, DateTimeKind.Utc).AddTicks(7527));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 28, 7, 30, 16, 308, DateTimeKind.Utc).AddTicks(7527));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 28, 7, 30, 16, 308, DateTimeKind.Utc).AddTicks(7527));

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentDetails_Appointment_AppointmentId",
                table: "AppointmentDetails",
                column: "AppointmentId",
                principalTable: "Appointment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentDetails_Service_ServiceId",
                table: "AppointmentDetails",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentDetails_Appointment_AppointmentId",
                table: "AppointmentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentDetails_Service_ServiceId",
                table: "AppointmentDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentDetails",
                table: "AppointmentDetails");

            migrationBuilder.RenameTable(
                name: "AppointmentDetails",
                newName: "appointmentDetails");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentDetails_ServiceId",
                table: "appointmentDetails",
                newName: "IX_appointmentDetails_ServiceId");

            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "appointmentDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddPrimaryKey(
                name: "PK_appointmentDetails",
                table: "appointmentDetails",
                columns: new[] { "AppointmentId", "ServiceId" });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 29, 12, 403, DateTimeKind.Utc).AddTicks(2886), new DateTime(2026, 12, 28, 7, 29, 12, 403, DateTimeKind.Utc).AddTicks(2886) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 29, 12, 403, DateTimeKind.Utc).AddTicks(2886), new DateTime(2026, 12, 28, 7, 29, 12, 403, DateTimeKind.Utc).AddTicks(2886) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 29, 12, 403, DateTimeKind.Utc).AddTicks(2886), new DateTime(2026, 12, 28, 7, 29, 12, 403, DateTimeKind.Utc).AddTicks(2886) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 29, 12, 403, DateTimeKind.Utc).AddTicks(2886), new DateTime(2026, 12, 28, 7, 29, 12, 403, DateTimeKind.Utc).AddTicks(2886) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 29, 12, 403, DateTimeKind.Utc).AddTicks(2886), new DateTime(2026, 12, 28, 7, 29, 12, 403, DateTimeKind.Utc).AddTicks(2886) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 29, 12, 403, DateTimeKind.Utc).AddTicks(2886), new DateTime(2026, 12, 28, 7, 29, 12, 403, DateTimeKind.Utc).AddTicks(2886) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 29, 12, 403, DateTimeKind.Utc).AddTicks(2886), new DateTime(2026, 12, 28, 7, 29, 12, 403, DateTimeKind.Utc).AddTicks(2886) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 29, 12, 403, DateTimeKind.Utc).AddTicks(2886), new DateTime(2026, 12, 28, 7, 29, 12, 403, DateTimeKind.Utc).AddTicks(2886) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 29, 12, 403, DateTimeKind.Utc).AddTicks(2886), new DateTime(2026, 12, 28, 7, 29, 12, 403, DateTimeKind.Utc).AddTicks(2886) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 29, 12, 403, DateTimeKind.Utc).AddTicks(2886), new DateTime(2026, 12, 28, 7, 29, 12, 403, DateTimeKind.Utc).AddTicks(2886) });

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 28, 7, 29, 12, 404, DateTimeKind.Utc).AddTicks(8503));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 28, 7, 29, 12, 404, DateTimeKind.Utc).AddTicks(8503));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 28, 7, 29, 12, 404, DateTimeKind.Utc).AddTicks(8503));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 28, 7, 29, 12, 404, DateTimeKind.Utc).AddTicks(8503));

            migrationBuilder.AddForeignKey(
                name: "FK_appointmentDetails_Appointment_AppointmentId",
                table: "appointmentDetails",
                column: "AppointmentId",
                principalTable: "Appointment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_appointmentDetails_Service_ServiceId",
                table: "appointmentDetails",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

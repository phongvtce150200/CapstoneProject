using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessObject.Migrations
{
    public partial class AppointmentDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionDetails_Medicine_MedicineId",
                table: "PrescriptionDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionDetails_Prescription_PrescriptionId",
                table: "PrescriptionDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_Appointment_AppointmentId",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Service_AppointmentId",
                table: "Service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrescriptionDetails",
                table: "PrescriptionDetails");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Appointment");

            migrationBuilder.RenameTable(
                name: "PrescriptionDetails",
                newName: "prescriptionDetails");

            migrationBuilder.RenameIndex(
                name: "IX_PrescriptionDetails_MedicineId",
                table: "prescriptionDetails",
                newName: "IX_prescriptionDetails_MedicineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_prescriptionDetails",
                table: "prescriptionDetails",
                columns: new[] { "PrescriptionId", "MedicineId" });

            migrationBuilder.CreateTable(
                name: "appointmentDetails",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointmentDetails", x => new { x.AppointmentId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_appointmentDetails_Appointment_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_appointmentDetails_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_appointmentDetails_ServiceId",
                table: "appointmentDetails",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_prescriptionDetails_Medicine_MedicineId",
                table: "prescriptionDetails",
                column: "MedicineId",
                principalTable: "Medicine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_prescriptionDetails_Prescription_PrescriptionId",
                table: "prescriptionDetails",
                column: "PrescriptionId",
                principalTable: "Prescription",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_prescriptionDetails_Medicine_MedicineId",
                table: "prescriptionDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_prescriptionDetails_Prescription_PrescriptionId",
                table: "prescriptionDetails");

            migrationBuilder.DropTable(
                name: "appointmentDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_prescriptionDetails",
                table: "prescriptionDetails");

            migrationBuilder.RenameTable(
                name: "prescriptionDetails",
                newName: "PrescriptionDetails");

            migrationBuilder.RenameIndex(
                name: "IX_prescriptionDetails_MedicineId",
                table: "PrescriptionDetails",
                newName: "IX_PrescriptionDetails_MedicineId");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "Service",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "Appointment",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrescriptionDetails",
                table: "PrescriptionDetails",
                columns: new[] { "PrescriptionId", "MedicineId" });

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

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 28, 7, 10, 15, 336, DateTimeKind.Utc).AddTicks(6535));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 28, 7, 10, 15, 336, DateTimeKind.Utc).AddTicks(6535));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 28, 7, 10, 15, 336, DateTimeKind.Utc).AddTicks(6535));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 28, 7, 10, 15, 336, DateTimeKind.Utc).AddTicks(6535));

            migrationBuilder.CreateIndex(
                name: "IX_Service_AppointmentId",
                table: "Service",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionDetails_Medicine_MedicineId",
                table: "PrescriptionDetails",
                column: "MedicineId",
                principalTable: "Medicine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionDetails_Prescription_PrescriptionId",
                table: "PrescriptionDetails",
                column: "PrescriptionId",
                principalTable: "Prescription",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Appointment_AppointmentId",
                table: "Service",
                column: "AppointmentId",
                principalTable: "Appointment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

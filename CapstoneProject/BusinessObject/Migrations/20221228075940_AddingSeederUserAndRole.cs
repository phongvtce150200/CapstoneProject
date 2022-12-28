using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessObject.Migrations
{
    public partial class AddingSeederUserAndRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 59, 40, 228, DateTimeKind.Utc).AddTicks(9647), new DateTime(2026, 12, 28, 7, 59, 40, 228, DateTimeKind.Utc).AddTicks(9647) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 59, 40, 228, DateTimeKind.Utc).AddTicks(9647), new DateTime(2026, 12, 28, 7, 59, 40, 228, DateTimeKind.Utc).AddTicks(9647) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 59, 40, 228, DateTimeKind.Utc).AddTicks(9647), new DateTime(2026, 12, 28, 7, 59, 40, 228, DateTimeKind.Utc).AddTicks(9647) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 59, 40, 228, DateTimeKind.Utc).AddTicks(9647), new DateTime(2026, 12, 28, 7, 59, 40, 228, DateTimeKind.Utc).AddTicks(9647) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 59, 40, 228, DateTimeKind.Utc).AddTicks(9647), new DateTime(2026, 12, 28, 7, 59, 40, 228, DateTimeKind.Utc).AddTicks(9647) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 59, 40, 228, DateTimeKind.Utc).AddTicks(9647), new DateTime(2026, 12, 28, 7, 59, 40, 228, DateTimeKind.Utc).AddTicks(9647) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 59, 40, 228, DateTimeKind.Utc).AddTicks(9647), new DateTime(2026, 12, 28, 7, 59, 40, 228, DateTimeKind.Utc).AddTicks(9647) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 59, 40, 228, DateTimeKind.Utc).AddTicks(9647), new DateTime(2026, 12, 28, 7, 59, 40, 228, DateTimeKind.Utc).AddTicks(9647) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 59, 40, 228, DateTimeKind.Utc).AddTicks(9647), new DateTime(2026, 12, 28, 7, 59, 40, 228, DateTimeKind.Utc).AddTicks(9647) });

            migrationBuilder.UpdateData(
                table: "Medicine",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "Expiration" },
                values: new object[] { new DateTime(2022, 12, 28, 7, 59, 40, 228, DateTimeKind.Utc).AddTicks(9647), new DateTime(2026, 12, 28, 7, 59, 40, 228, DateTimeKind.Utc).AddTicks(9647) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1dbd138d-3f89-466f-86cb-fd0d7a915e31", "0e01fc67-1566-4e45-babd-d02200ce3b83", "Admin", "ADMIN" },
                    { "e98b424a-ab2d-43c5-b655-2a969cfe9ddc", "92a7493a-1cde-45b8-99d2-8bda666f8f26", "Doctor", "DOCTOR" },
                    { "f0cc7ba3-c213-4a34-8165-ec3a3d9ae1af", "5d5585bb-7717-4b80-857f-952d08c0892d", "Nurse", "NURSE" },
                    { "3f7c4489-b9d7-4f59-8401-128d917290c8", "1fde649f-65ee-42b0-9e9e-1773ed75c6b9", "Patient", "PATIENT" }
                });

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 28, 7, 59, 40, 230, DateTimeKind.Utc).AddTicks(2796));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 28, 7, 59, 40, 230, DateTimeKind.Utc).AddTicks(2796));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 28, 7, 59, 40, 230, DateTimeKind.Utc).AddTicks(2796));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 28, 7, 59, 40, 230, DateTimeKind.Utc).AddTicks(2796));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDay", "ConcurrencyStamp", "CreatedBy", "CreatedDate", "DeletedDate", "Email", "EmailConfirmed", "FirstName", "Gender", "Image", "IsDelete", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedBy", "UpdatedDate", "UserName" },
                values: new object[,]
                {
                    { "f9ce7ce9-0491-48ff-898c-6e6b5e1f65ae", 0, "Cần Thơ", new DateTime(2001, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "574309a1-3cd5-4234-b7c5-f6f4e073fb97", null, new DateTime(2022, 12, 28, 7, 59, 40, 231, DateTimeKind.Utc).AddTicks(6826), null, "hungle@gmail.com", true, "Quốc Hùng", false, null, false, "Lê", false, null, "HUNGLE@GMAIL.COM", "HUNGLE", "AQAAAAEAACcQAAAAEPIpo719YROWQHSeV+cD2XueTTwXI+aXP9HDNWOeDsoGrL6vAiAR57j+20cuVQdR2A==", "0123456789", true, "6c0be8a9-af60-489d-99e9-3ace866f7897", false, null, null, "hungle" },
                    { "66bc5ee9-e946-4cf1-9a54-517f35e4b4e9", 0, "TP HCM", new DateTime(2001, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "c1364239-2307-4977-bba6-d632bed7fd12", null, new DateTime(2022, 12, 28, 7, 59, 40, 231, DateTimeKind.Utc).AddTicks(6826), null, "v.thanhphong1712@gmail.com", true, "Thanh Phong", true, null, false, "Võ", false, null, "V.THANHPHONG1712@GMAIL.COM", "PHONGVT1712", "AQAAAAEAACcQAAAAEIp0PTzF575HvuX/6zgU1JtT/EG9NTy9MIBHZeSocPCiZAzKymjq/eGNzGwAqHVX9g==", "0769339456", true, "15a2c061-1056-40b9-89b2-7d34922f2d97", false, null, null, "phongvt1712" },
                    { "59001bf3-0f38-4754-b656-e5981f3406ff", 0, "Bến Tre", new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ac2acc3a-5100-4cbc-838f-042db50254f9", null, new DateTime(2022, 12, 28, 7, 59, 40, 231, DateTimeKind.Utc).AddTicks(6826), null, "hauphan@gmail.com", true, "Công Hậu", false, null, false, "Phan", false, null, "HAUPHAN@GMAIL.COM", "HAUPHAN", "AQAAAAEAACcQAAAAEAMK62TUb9OO8tv9BQwsyV33Bb2jTGDLZ6X+uBeZ2WNXOOSOMykoVr1wHmo6BaIBKw==", "0808080080", true, "0ef47f77-034a-4aa1-ae35-c975365d80c4", false, null, null, "hauphan" },
                    { "318a5ae0-53dd-4ec2-931d-9ff0e3290d86", 0, "Admin", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "8d435c9e-bb7e-42ef-b9a7-a98783cb08a0", null, new DateTime(2022, 12, 28, 7, 59, 40, 231, DateTimeKind.Utc).AddTicks(6826), null, "admin@clinc.com", true, "admin", true, null, false, "admin", false, null, "ADMIN@CLINIC.COM", "ADMIN", "AQAAAAEAACcQAAAAEGL9SSbzUQZ0gufTul2N+5CrsnUZ54yHJPmcXokJUCQ1J/RoTNCWBzy0fHKtkVCnBg==", "0909090090", true, "20ccb861-4920-4289-ab82-e49def9d8830", false, null, null, "admin" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1dbd138d-3f89-466f-86cb-fd0d7a915e31");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "3f7c4489-b9d7-4f59-8401-128d917290c8");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e98b424a-ab2d-43c5-b655-2a969cfe9ddc");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "f0cc7ba3-c213-4a34-8165-ec3a3d9ae1af");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "318a5ae0-53dd-4ec2-931d-9ff0e3290d86");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "59001bf3-0f38-4754-b656-e5981f3406ff");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "66bc5ee9-e946-4cf1-9a54-517f35e4b4e9");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "f9ce7ce9-0491-48ff-898c-6e6b5e1f65ae");

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
        }
    }
}

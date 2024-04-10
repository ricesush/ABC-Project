using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ABC.Client.Migrations
{
    /// <inheritdoc />
    public partial class NewMigrationsv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeaders_Stores_StoreId",
                table: "OrderHeaders");

            migrationBuilder.DropIndex(
                name: "IX_OrderHeaders_StoreId",
                table: "OrderHeaders");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ce323ff2-3735-4806-bd9c-f0d9ed9fb255", "6678c76a-f899-483f-abe4-77b050f17299" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "73844e4c-2215-4034-80e3-b65fee77bb97", "69174cd4-318c-43da-8c3d-4988c7e96d48" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4f4d31ce-7428-4e34-962f-a62730ab65d1", "a1e31d4d-3c35-4f3e-9382-3a2b17171970" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d59318f5-319f-4d6e-8fc6-2d2c45222b0b", "a2613f35-7d02-4641-8562-f20e320950c4" });

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("8e0d8c64-d077-4969-8d0c-ab1ac2446e41"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f4d31ce-7428-4e34-962f-a62730ab65d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73844e4c-2215-4034-80e3-b65fee77bb97");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce323ff2-3735-4806-bd9c-f0d9ed9fb255");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d59318f5-319f-4d6e-8fc6-2d2c45222b0b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6678c76a-f899-483f-abe4-77b050f17299");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69174cd4-318c-43da-8c3d-4988c7e96d48");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1e31d4d-3c35-4f3e-9382-3a2b17171970");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2613f35-7d02-4641-8562-f20e320950c4");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "OrderHeaders");

            migrationBuilder.AddColumn<string>(
                name: "StoreName",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "50e9a4d7-a591-466c-bba2-95593522a2f9", null, "Manager", "MANAGER" },
                    { "84cac90f-ea31-46aa-b596-e5a2affb0e14", null, "Customer", "CUSTOMER" },
                    { "9a52222b-0174-48f9-b53b-1c3ce5b68c88", null, "Employee", "EMPLOYEE" },
                    { "cc1e9640-b607-4fb3-b740-235e1ffe2021", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "Province", "SecurityStamp", "StoreId", "StoreName", "TimeStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1fc80a5a-598a-4702-a624-1b04de4575fb", 0, null, null, "ec2f68a9-7728-4d8d-8ad4-6b6773dfb6fe", "admin@abc.com", true, "Ej Admin", "Esan", false, null, null, "ADMIN@ABC.COM", "AQAAAAIAAYagAAAAEMfUYSfd1YvkmzlB9IYmHqvw1baumHwbqLMAPo1Kfthi6dllb9hXGDtCuqJmvYUYgQ==", null, false, null, null, "0d77a4b0-f3fd-4529-91c0-842f7dd0d65f", null, null, new DateTime(2024, 4, 10, 11, 26, 1, 28, DateTimeKind.Utc).AddTicks(4138), false, "admin@abc.com" },
                    { "5fad7b6f-afcd-4112-b067-43ac087a13b0", 0, null, null, "9deb08bc-1756-4b93-98ce-26da9820a9ad", "manager@abc.com", true, "Ej Manager", "Esan", false, null, null, "MANAGER@ABC.COM", "AQAAAAIAAYagAAAAENve0XGlitPYimgXdqDC6RrixZdUQOQC506ZRm5YwKIgyQIxHW9cP+tM2tpZALWzlw==", null, false, null, null, "1e00b3db-e674-459f-9eea-db396d22db3c", null, null, new DateTime(2024, 4, 10, 11, 26, 1, 107, DateTimeKind.Utc).AddTicks(7377), false, "manager@abc.com" },
                    { "75adbc7e-3556-4afc-a148-2f84dcf92c5e", 0, null, null, "ce2f6474-16da-4bce-a558-81536ef1524c", "emp@abc.com", true, "Ej Employee", "Esan", false, null, null, "EMP@ABC.COM", "AQAAAAIAAYagAAAAEG4JBORRHxupixXR+0ZFbbiP12GIPtznpJHrp7wr2RVcI2b3Mpj/LLnpDtyGPqhq4A==", null, false, null, null, "513791bf-3d5a-41d9-bb1e-7983496b5b14", null, null, new DateTime(2024, 4, 10, 11, 26, 1, 174, DateTimeKind.Utc).AddTicks(5783), false, "emp@abc.com" },
                    { "e4598434-f341-4403-9e81-5d062ebb12c4", 0, null, null, "d1e8f462-580b-44a6-b61c-a88ff6c2f55d", "cust@abc.com", true, "Ej Customer", "Esan", false, null, null, "CUST@ABC.COM", "AQAAAAIAAYagAAAAEDCx2LnkU3SJWoRCL3KaBI5raUiDUOow6TefFYyncsLYe2qi+TeCOQ1kudBe82Nfbw==", null, false, null, null, "31bc4a5f-0c08-4931-937a-cbd819129607", null, null, new DateTime(2024, 4, 10, 11, 26, 1, 248, DateTimeKind.Utc).AddTicks(9487), false, "cust@abc.com" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "ApSuUn", "Barangay", "City", "ContactNumber", "EmailAddress", "FirstName", "LastName", "Province", "StreetorSubd", "Type", "ZipCode" },
                values: new object[] { new Guid("70d9d03b-6cdd-49d6-90aa-2f377e140936"), "Unit 1234", "Batman", "Antipolo", 9568271611L, "neiljejomar@gmail.com", "Kurt", "Betonio", "Rizal", "Jasmine St.", "Walk in", 1870 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2024, 4, 10, 11, 26, 1, 344, DateTimeKind.Utc).AddTicks(5398));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2024, 4, 10, 11, 26, 1, 344, DateTimeKind.Utc).AddTicks(5404));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2024, 4, 10, 11, 26, 1, 344, DateTimeKind.Utc).AddTicks(5407));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2024, 4, 10, 11, 26, 1, 344, DateTimeKind.Utc).AddTicks(5410));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Timestamp",
                value: new DateTime(2024, 4, 10, 11, 26, 1, 344, DateTimeKind.Utc).AddTicks(5412));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2024, 4, 10, 11, 26, 1, 344, DateTimeKind.Utc).AddTicks(5508));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2024, 4, 10, 11, 26, 1, 344, DateTimeKind.Utc).AddTicks(5512));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "cc1e9640-b607-4fb3-b740-235e1ffe2021", "1fc80a5a-598a-4702-a624-1b04de4575fb" },
                    { "50e9a4d7-a591-466c-bba2-95593522a2f9", "5fad7b6f-afcd-4112-b067-43ac087a13b0" },
                    { "9a52222b-0174-48f9-b53b-1c3ce5b68c88", "75adbc7e-3556-4afc-a148-2f84dcf92c5e" },
                    { "84cac90f-ea31-46aa-b596-e5a2affb0e14", "e4598434-f341-4403-9e81-5d062ebb12c4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cc1e9640-b607-4fb3-b740-235e1ffe2021", "1fc80a5a-598a-4702-a624-1b04de4575fb" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "50e9a4d7-a591-466c-bba2-95593522a2f9", "5fad7b6f-afcd-4112-b067-43ac087a13b0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9a52222b-0174-48f9-b53b-1c3ce5b68c88", "75adbc7e-3556-4afc-a148-2f84dcf92c5e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "84cac90f-ea31-46aa-b596-e5a2affb0e14", "e4598434-f341-4403-9e81-5d062ebb12c4" });

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("70d9d03b-6cdd-49d6-90aa-2f377e140936"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50e9a4d7-a591-466c-bba2-95593522a2f9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84cac90f-ea31-46aa-b596-e5a2affb0e14");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a52222b-0174-48f9-b53b-1c3ce5b68c88");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc1e9640-b607-4fb3-b740-235e1ffe2021");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1fc80a5a-598a-4702-a624-1b04de4575fb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5fad7b6f-afcd-4112-b067-43ac087a13b0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75adbc7e-3556-4afc-a148-2f84dcf92c5e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4598434-f341-4403-9e81-5d062ebb12c4");

            migrationBuilder.DropColumn(
                name: "StoreName",
                table: "OrderHeaders");

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "OrderHeaders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4f4d31ce-7428-4e34-962f-a62730ab65d1", null, "Customer", "CUSTOMER" },
                    { "73844e4c-2215-4034-80e3-b65fee77bb97", null, "Admin", "ADMIN" },
                    { "ce323ff2-3735-4806-bd9c-f0d9ed9fb255", null, "Employee", "EMPLOYEE" },
                    { "d59318f5-319f-4d6e-8fc6-2d2c45222b0b", null, "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "Province", "SecurityStamp", "StoreId", "StoreName", "TimeStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6678c76a-f899-483f-abe4-77b050f17299", 0, null, null, "21f30b95-743b-41d8-8ce4-4cad2e3e0cce", "emp@abc.com", true, "Ej Employee", "Esan", false, null, null, "EMP@ABC.COM", "AQAAAAIAAYagAAAAEMfBslFtnHaR24/lYi1yKs0/fVVSRqo4hHI6Rf1cE22gH9bYA87SrI3Er2yyRSmmNA==", null, false, null, null, "4725fcf6-fdb0-4fb1-881b-252983665ca0", null, null, new DateTime(2024, 4, 10, 11, 23, 25, 860, DateTimeKind.Utc).AddTicks(7247), false, "emp@abc.com" },
                    { "69174cd4-318c-43da-8c3d-4988c7e96d48", 0, null, null, "05ee8de4-9ee5-495f-9ec3-0f32383bf064", "admin@abc.com", true, "Ej Admin", "Esan", false, null, null, "ADMIN@ABC.COM", "AQAAAAIAAYagAAAAEKOb/nMwEBXJw4rmIH2xhv/cnRA04eKj4QJ/gNUiz8bfgitMG8mRr/43VhO/NzQxmA==", null, false, null, null, "64937964-e16b-446b-be53-6d837ef19fee", null, null, new DateTime(2024, 4, 10, 11, 23, 25, 687, DateTimeKind.Utc).AddTicks(2862), false, "admin@abc.com" },
                    { "a1e31d4d-3c35-4f3e-9382-3a2b17171970", 0, null, null, "9ee9f0fd-b5f0-496a-951c-2223e8900ec5", "cust@abc.com", true, "Ej Customer", "Esan", false, null, null, "CUST@ABC.COM", "AQAAAAIAAYagAAAAEOYf74BVW3s56o602r7lNVRQkekSFUmyYVk3DELSwu7aZplVxdEILZkoZ65rx72IUQ==", null, false, null, null, "ff0601ca-5503-40f0-b951-a65e40aaec0a", null, null, new DateTime(2024, 4, 10, 11, 23, 25, 947, DateTimeKind.Utc).AddTicks(3858), false, "cust@abc.com" },
                    { "a2613f35-7d02-4641-8562-f20e320950c4", 0, null, null, "00afbcbb-f749-4462-b3bf-c0e429d1f9d1", "manager@abc.com", true, "Ej Manager", "Esan", false, null, null, "MANAGER@ABC.COM", "AQAAAAIAAYagAAAAELZGv3ie0PQKa00NENd59yYiI1Fv0qgsQJ8YkEKVdhkFkYW8Gd7uNm77Z/HTvj+GCg==", null, false, null, null, "14d595ce-9c52-4893-9f01-bbf91b7076c7", null, null, new DateTime(2024, 4, 10, 11, 23, 25, 755, DateTimeKind.Utc).AddTicks(333), false, "manager@abc.com" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "ApSuUn", "Barangay", "City", "ContactNumber", "EmailAddress", "FirstName", "LastName", "Province", "StreetorSubd", "Type", "ZipCode" },
                values: new object[] { new Guid("8e0d8c64-d077-4969-8d0c-ab1ac2446e41"), "Unit 1234", "Batman", "Antipolo", 9568271611L, "neiljejomar@gmail.com", "Kurt", "Betonio", "Rizal", "Jasmine St.", "Walk in", 1870 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2024, 4, 10, 11, 23, 26, 36, DateTimeKind.Utc).AddTicks(1988));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2024, 4, 10, 11, 23, 26, 36, DateTimeKind.Utc).AddTicks(1994));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2024, 4, 10, 11, 23, 26, 36, DateTimeKind.Utc).AddTicks(1997));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2024, 4, 10, 11, 23, 26, 36, DateTimeKind.Utc).AddTicks(1999));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Timestamp",
                value: new DateTime(2024, 4, 10, 11, 23, 26, 36, DateTimeKind.Utc).AddTicks(2001));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2024, 4, 10, 11, 23, 26, 36, DateTimeKind.Utc).AddTicks(2073));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2024, 4, 10, 11, 23, 26, 36, DateTimeKind.Utc).AddTicks(2076));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ce323ff2-3735-4806-bd9c-f0d9ed9fb255", "6678c76a-f899-483f-abe4-77b050f17299" },
                    { "73844e4c-2215-4034-80e3-b65fee77bb97", "69174cd4-318c-43da-8c3d-4988c7e96d48" },
                    { "4f4d31ce-7428-4e34-962f-a62730ab65d1", "a1e31d4d-3c35-4f3e-9382-3a2b17171970" },
                    { "d59318f5-319f-4d6e-8fc6-2d2c45222b0b", "a2613f35-7d02-4641-8562-f20e320950c4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_StoreId",
                table: "OrderHeaders",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeaders_Stores_StoreId",
                table: "OrderHeaders",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

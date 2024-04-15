using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ABC.Client.Migrations
{
    /// <inheritdoc />
    public partial class NewMigrationsv5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockPerStores_Products_ProductId",
                table: "StockPerStores");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "459abbdf-a184-47a1-b369-765c376a5689", null, "Manager", "MANAGER" },
                    { "7786f7b0-83ac-4f96-a4ae-1353e5f04372", null, "Employee", "EMPLOYEE" },
                    { "e24b294b-6039-49fe-abca-74b7669ce3ba", null, "Admin", "ADMIN" },
                    { "e574d90b-d050-4de9-b3e2-41d2f814da54", null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "Province", "SecurityStamp", "StoreId", "StoreName", "TimeStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "61a391e7-e2be-4081-91ba-488b10e016bf", 0, null, null, "df0521d7-59c3-49d1-abc8-f94bdc3eecef", "admin@abc.com", true, "Ej Admin", "Esan", false, null, null, "ADMIN@ABC.COM", "AQAAAAIAAYagAAAAEBBGq5ZsO8seH5fTegwFkkmWcdoVcSm6Jn9CD4wrEQJDrddCiKNHh0LJIUXT2USbDA==", null, false, null, null, "ddbff0d4-2e9e-4de7-bade-2dd28aa2b41f", null, null, new DateTime(2024, 4, 14, 10, 58, 31, 229, DateTimeKind.Utc).AddTicks(2213), false, "admin@abc.com" },
                    { "7b8a6dde-fc4f-49c6-b782-cdf8ec9343ac", 0, null, null, "995d4ad8-69c1-4559-b645-a27165531fd4", "cust@abc.com", true, "Ej Customer", "Esan", false, null, null, "CUST@ABC.COM", "AQAAAAIAAYagAAAAEII23VIX0ZyjN7GK+b8NEIn7gbwPnCozKzIqqLyy/0QzzsTpdjXKhvU0SFCuQqomWA==", null, false, null, null, "73c6de26-8af2-4839-8714-30107345257d", null, null, new DateTime(2024, 4, 14, 10, 58, 31, 448, DateTimeKind.Utc).AddTicks(1671), false, "cust@abc.com" },
                    { "ed877bb4-a3ce-43fa-9151-f89bec846df9", 0, null, null, "a4e8b39b-3fac-4c28-95fb-8c87a5d91531", "manager@abc.com", true, "Ej Manager", "Esan", false, null, null, "MANAGER@ABC.COM", "AQAAAAIAAYagAAAAELlSK3e/LFzmj8ooNbJNvc5lkJydyOaAeRgRluYvTgE77YzJduANqbzIP/ZIMFd/1Q==", null, false, null, null, "1c2ddb04-5e28-457a-ab43-73a8f1f900fd", null, null, new DateTime(2024, 4, 14, 10, 58, 31, 303, DateTimeKind.Utc).AddTicks(615), false, "manager@abc.com" },
                    { "f0970fdb-2cc4-495f-a1b2-956ebdb0e3db", 0, null, null, "a2b0c3ab-d9c8-4c37-aa06-52173946b7b3", "emp@abc.com", true, "Ej Employee", "Esan", false, null, null, "EMP@ABC.COM", "AQAAAAIAAYagAAAAECjk+vlND7JwQ6WRXIs8oVfSG/b+HYIqSlp4xBIPbckqikuoYnpoM75dEeXZHX7YTA==", null, false, null, null, "79086c80-ea3a-4abd-9bd4-9fd67fbaf22b", null, null, new DateTime(2024, 4, 14, 10, 58, 31, 376, DateTimeKind.Utc).AddTicks(2081), false, "emp@abc.com" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "ApSuUn", "Barangay", "City", "ContactNumber", "EmailAddress", "FirstName", "LastName", "Province", "StreetorSubd", "Type", "ZipCode" },
                values: new object[] { new Guid("82569289-9756-4644-b519-72744344ca1a"), "Unit 1234", "Batman", "Antipolo", 9568271611L, "neiljejomar@gmail.com", "Kurt", "Betonio", "Rizal", "Jasmine St.", "Walk in", 1870 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2024, 4, 14, 10, 58, 31, 523, DateTimeKind.Utc).AddTicks(3698));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2024, 4, 14, 10, 58, 31, 523, DateTimeKind.Utc).AddTicks(3707));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2024, 4, 14, 10, 58, 31, 523, DateTimeKind.Utc).AddTicks(3710));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2024, 4, 14, 10, 58, 31, 523, DateTimeKind.Utc).AddTicks(3714));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Timestamp",
                value: new DateTime(2024, 4, 14, 10, 58, 31, 523, DateTimeKind.Utc).AddTicks(3717));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2024, 4, 14, 10, 58, 31, 523, DateTimeKind.Utc).AddTicks(3839));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2024, 4, 14, 10, 58, 31, 523, DateTimeKind.Utc).AddTicks(3845));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "e24b294b-6039-49fe-abca-74b7669ce3ba", "61a391e7-e2be-4081-91ba-488b10e016bf" },
                    { "e574d90b-d050-4de9-b3e2-41d2f814da54", "7b8a6dde-fc4f-49c6-b782-cdf8ec9343ac" },
                    { "459abbdf-a184-47a1-b369-765c376a5689", "ed877bb4-a3ce-43fa-9151-f89bec846df9" },
                    { "7786f7b0-83ac-4f96-a4ae-1353e5f04372", "f0970fdb-2cc4-495f-a1b2-956ebdb0e3db" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_StockPerStores_Products_ProductId",
                table: "StockPerStores",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockPerStores_Products_ProductId",
                table: "StockPerStores");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e24b294b-6039-49fe-abca-74b7669ce3ba", "61a391e7-e2be-4081-91ba-488b10e016bf" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e574d90b-d050-4de9-b3e2-41d2f814da54", "7b8a6dde-fc4f-49c6-b782-cdf8ec9343ac" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "459abbdf-a184-47a1-b369-765c376a5689", "ed877bb4-a3ce-43fa-9151-f89bec846df9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7786f7b0-83ac-4f96-a4ae-1353e5f04372", "f0970fdb-2cc4-495f-a1b2-956ebdb0e3db" });

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("82569289-9756-4644-b519-72744344ca1a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "459abbdf-a184-47a1-b369-765c376a5689");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7786f7b0-83ac-4f96-a4ae-1353e5f04372");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e24b294b-6039-49fe-abca-74b7669ce3ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e574d90b-d050-4de9-b3e2-41d2f814da54");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "61a391e7-e2be-4081-91ba-488b10e016bf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b8a6dde-fc4f-49c6-b782-cdf8ec9343ac");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed877bb4-a3ce-43fa-9151-f89bec846df9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f0970fdb-2cc4-495f-a1b2-956ebdb0e3db");

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

            migrationBuilder.AddForeignKey(
                name: "FK_StockPerStores_Products_ProductId",
                table: "StockPerStores",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}

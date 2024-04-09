using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ABC.Client.Migrations
{
    /// <inheritdoc />
    public partial class NulledImgUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "862be04d-d784-4009-9231-6a3d3f77103a", "7cf7f651-1449-4a93-b954-b160a9447e29" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "27ee39b9-fd46-4bb1-96a7-60f49e12ba43", "a4ba3abf-4697-44b5-a79f-373c82ffdb96" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "efb79371-e4ad-4611-a530-d340eae6dfed", "b065dc97-120d-45a2-8edb-8665e29473ce" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f6ac1393-7c52-461b-a5ba-eecae2e6038c", "f639d4a0-e1b7-488b-b99e-aa3d182ebc5f" });

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("b4179327-a142-416d-b90e-eb2ddb33dc4d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27ee39b9-fd46-4bb1-96a7-60f49e12ba43");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "862be04d-d784-4009-9231-6a3d3f77103a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efb79371-e4ad-4611-a530-d340eae6dfed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6ac1393-7c52-461b-a5ba-eecae2e6038c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cf7f651-1449-4a93-b954-b160a9447e29");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a4ba3abf-4697-44b5-a79f-373c82ffdb96");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b065dc97-120d-45a2-8edb-8665e29473ce");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f639d4a0-e1b7-488b-b99e-aa3d182ebc5f");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "32c3390b-1f9e-45a9-b7b2-5fe836977343", null, "Employee", "EMPLOYEE" },
                    { "6b8d6d41-1379-4718-8a7e-a2256b8f0389", null, "Customer", "CUSTOMER" },
                    { "7414943a-461d-4662-9a96-b4fc6bf5b0b6", null, "Manager", "MANAGER" },
                    { "e0db689f-6b3d-4740-97a8-5a7cf49b4d57", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "Province", "SecurityStamp", "StoreId", "StoreName", "TimeStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0d016c50-49a2-4927-8e06-0742a3d59db8", 0, null, null, "76b6e9cb-bc05-4261-874c-844ed50671c8", "admin@abc.com", true, "Ej Admin", "Esan", false, null, null, "ADMIN@ABC.COM", "AQAAAAIAAYagAAAAEArkI5FT7H3xwYuScGayjZ0pznwWYfZTI9mEZLog8Cn31iXIex4OeDkkRyiGpqrlUQ==", null, false, null, null, "e577ea9b-63ec-4457-ac44-0b48d1f2a649", null, null, new DateTime(2024, 4, 9, 17, 18, 25, 971, DateTimeKind.Utc).AddTicks(1454), false, "admin@abc.com" },
                    { "2e37355a-4398-48a4-99fe-afed34c5b5ae", 0, null, null, "22e7d330-47fe-47b2-875a-f8c1f26cdbf6", "cust@abc.com", true, "Ej Customer", "Esan", false, null, null, "CUST@ABC.COM", "AQAAAAIAAYagAAAAELP7TtGLYQxWsPddWoC+Llbt/0tED14J5LZIKGIdHJfOQi/PA6+WymwyQbO4SrSKhg==", null, false, null, null, "e3212d8f-7322-4aa6-8e34-20861901c3d0", null, null, new DateTime(2024, 4, 9, 17, 18, 26, 183, DateTimeKind.Utc).AddTicks(6699), false, "cust@abc.com" },
                    { "339801ef-839f-4244-9223-bd51dda3c2d6", 0, null, null, "0c796c6e-2989-45ea-b47f-2e301596dd68", "emp@abc.com", true, "Ej Employee", "Esan", false, null, null, "EMP@ABC.COM", "AQAAAAIAAYagAAAAEOGyTy8ifVunAYKlu3PrHSQeYvqfk+LMEhmJGSMoKZ9wgycxxn8Vd0L/7QlV6b2XdA==", null, false, null, null, "e52207cc-5706-4388-9b58-876a6695ff06", null, null, new DateTime(2024, 4, 9, 17, 18, 26, 104, DateTimeKind.Utc).AddTicks(470), false, "emp@abc.com" },
                    { "3ac9352f-4172-4034-9773-1c37130b92c9", 0, null, null, "1ab156cf-4cf1-4012-a9a7-1d96f3dd4569", "manager@abc.com", true, "Ej Manager", "Esan", false, null, null, "MANAGER@ABC.COM", "AQAAAAIAAYagAAAAEIMe1GIivwcYS0YA9jk1ibQhEffpk2HiDPm2tMjS7zkvdR30yluGJRN5V7CeQi6HnQ==", null, false, null, null, "8f9a1974-9199-4633-ba6c-54a0e37dedf0", null, null, new DateTime(2024, 4, 9, 17, 18, 26, 37, DateTimeKind.Utc).AddTicks(9165), false, "manager@abc.com" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "ApSuUn", "Barangay", "City", "ContactNumber", "EmailAddress", "FirstName", "LastName", "Province", "StreetorSubd", "Type", "ZipCode" },
                values: new object[] { new Guid("d646797c-efcd-485b-9ae5-e2b36d651a87"), "Unit 1234", "Batman", "Antipolo", 9568271611L, "neiljejomar@gmail.com", "Kurt", "Betonio", "Rizal", "Jasmine St.", "Walk in", 1870 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2024, 4, 9, 17, 18, 26, 264, DateTimeKind.Utc).AddTicks(6318));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2024, 4, 9, 17, 18, 26, 264, DateTimeKind.Utc).AddTicks(6325));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2024, 4, 9, 17, 18, 26, 264, DateTimeKind.Utc).AddTicks(6327));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2024, 4, 9, 17, 18, 26, 264, DateTimeKind.Utc).AddTicks(6330));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Timestamp",
                value: new DateTime(2024, 4, 9, 17, 18, 26, 264, DateTimeKind.Utc).AddTicks(6333));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2024, 4, 9, 17, 18, 26, 264, DateTimeKind.Utc).AddTicks(6487));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2024, 4, 9, 17, 18, 26, 264, DateTimeKind.Utc).AddTicks(6491));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "e0db689f-6b3d-4740-97a8-5a7cf49b4d57", "0d016c50-49a2-4927-8e06-0742a3d59db8" },
                    { "6b8d6d41-1379-4718-8a7e-a2256b8f0389", "2e37355a-4398-48a4-99fe-afed34c5b5ae" },
                    { "32c3390b-1f9e-45a9-b7b2-5fe836977343", "339801ef-839f-4244-9223-bd51dda3c2d6" },
                    { "7414943a-461d-4662-9a96-b4fc6bf5b0b6", "3ac9352f-4172-4034-9773-1c37130b92c9" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e0db689f-6b3d-4740-97a8-5a7cf49b4d57", "0d016c50-49a2-4927-8e06-0742a3d59db8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6b8d6d41-1379-4718-8a7e-a2256b8f0389", "2e37355a-4398-48a4-99fe-afed34c5b5ae" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "32c3390b-1f9e-45a9-b7b2-5fe836977343", "339801ef-839f-4244-9223-bd51dda3c2d6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7414943a-461d-4662-9a96-b4fc6bf5b0b6", "3ac9352f-4172-4034-9773-1c37130b92c9" });

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("d646797c-efcd-485b-9ae5-e2b36d651a87"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32c3390b-1f9e-45a9-b7b2-5fe836977343");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b8d6d41-1379-4718-8a7e-a2256b8f0389");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7414943a-461d-4662-9a96-b4fc6bf5b0b6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0db689f-6b3d-4740-97a8-5a7cf49b4d57");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d016c50-49a2-4927-8e06-0742a3d59db8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e37355a-4398-48a4-99fe-afed34c5b5ae");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "339801ef-839f-4244-9223-bd51dda3c2d6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ac9352f-4172-4034-9773-1c37130b92c9");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "27ee39b9-fd46-4bb1-96a7-60f49e12ba43", null, "Manager", "MANAGER" },
                    { "862be04d-d784-4009-9231-6a3d3f77103a", null, "Employee", "EMPLOYEE" },
                    { "efb79371-e4ad-4611-a530-d340eae6dfed", null, "Customer", "CUSTOMER" },
                    { "f6ac1393-7c52-461b-a5ba-eecae2e6038c", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "Province", "SecurityStamp", "StoreId", "StoreName", "TimeStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "7cf7f651-1449-4a93-b954-b160a9447e29", 0, null, null, "d78dc893-29a1-41fc-b443-b36c949f03a3", "emp@abc.com", true, "Ej Employee", "Esan", false, null, null, "EMP@ABC.COM", "AQAAAAIAAYagAAAAEL9fA72R/rSGcnZ2Rd7m/OwP7cJ/VYuAtNWH31B96oFlnBhrJfbHXXysQsXADy5PqA==", null, false, null, null, "2cfb3e99-33a5-4426-8b93-4beac2db59bb", null, null, new DateTime(2024, 4, 9, 15, 50, 30, 369, DateTimeKind.Utc).AddTicks(6175), false, "emp@abc.com" },
                    { "a4ba3abf-4697-44b5-a79f-373c82ffdb96", 0, null, null, "7283291c-b73e-41e3-bdf8-2d13fcda168c", "manager@abc.com", true, "Ej Manager", "Esan", false, null, null, "MANAGER@ABC.COM", "AQAAAAIAAYagAAAAELWIQFJlD0f2BPhx5Dk9oD7IxurMOE9OerYvQCqZVx1klpzgbpid+E1jNxWMJmLmHA==", null, false, null, null, "32f3bf94-be9a-4a96-8220-f79ec5861d7e", null, null, new DateTime(2024, 4, 9, 15, 50, 30, 284, DateTimeKind.Utc).AddTicks(1783), false, "manager@abc.com" },
                    { "b065dc97-120d-45a2-8edb-8665e29473ce", 0, null, null, "41cfd624-61ef-4b38-a91b-34321d773ccf", "cust@abc.com", true, "Ej Customer", "Esan", false, null, null, "CUST@ABC.COM", "AQAAAAIAAYagAAAAEDMP2dKIxGCCxvmbw0HLxZhJ2bsFXU34L9at6tFlk2I3BHOpYpIcYBPZ1A62CiIpNg==", null, false, null, null, "e745c504-1963-4d94-9666-c94dc0cc4e77", null, null, new DateTime(2024, 4, 9, 15, 50, 30, 448, DateTimeKind.Utc).AddTicks(3868), false, "cust@abc.com" },
                    { "f639d4a0-e1b7-488b-b99e-aa3d182ebc5f", 0, null, null, "53977480-c94e-4303-89fe-c275b0821e93", "admin@abc.com", true, "Ej Admin", "Esan", false, null, null, "ADMIN@ABC.COM", "AQAAAAIAAYagAAAAEKkNvy66ca6Cd5SDeHovkPwsKKfJRM8sHHBg5mxmDNKoxCHksJmaaLkzhoKSeGDsuA==", null, false, null, null, "05c25c00-eefe-41f6-af38-1059945a1a9d", null, null, new DateTime(2024, 4, 9, 15, 50, 30, 217, DateTimeKind.Utc).AddTicks(8208), false, "admin@abc.com" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "ApSuUn", "Barangay", "City", "ContactNumber", "EmailAddress", "FirstName", "LastName", "Province", "StreetorSubd", "Type", "ZipCode" },
                values: new object[] { new Guid("b4179327-a142-416d-b90e-eb2ddb33dc4d"), "Unit 1234", "Batman", "Antipolo", 9568271611L, "neiljejomar@gmail.com", "Kurt", "Betonio", "Rizal", "Jasmine St.", "Walk in", 1870 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2024, 4, 9, 15, 50, 30, 524, DateTimeKind.Utc).AddTicks(4497));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2024, 4, 9, 15, 50, 30, 524, DateTimeKind.Utc).AddTicks(4505));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2024, 4, 9, 15, 50, 30, 524, DateTimeKind.Utc).AddTicks(4508));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2024, 4, 9, 15, 50, 30, 524, DateTimeKind.Utc).AddTicks(4510));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Timestamp",
                value: new DateTime(2024, 4, 9, 15, 50, 30, 524, DateTimeKind.Utc).AddTicks(4513));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2024, 4, 9, 15, 50, 30, 524, DateTimeKind.Utc).AddTicks(4651));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2024, 4, 9, 15, 50, 30, 524, DateTimeKind.Utc).AddTicks(4655));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "862be04d-d784-4009-9231-6a3d3f77103a", "7cf7f651-1449-4a93-b954-b160a9447e29" },
                    { "27ee39b9-fd46-4bb1-96a7-60f49e12ba43", "a4ba3abf-4697-44b5-a79f-373c82ffdb96" },
                    { "efb79371-e4ad-4611-a530-d340eae6dfed", "b065dc97-120d-45a2-8edb-8665e29473ce" },
                    { "f6ac1393-7c52-461b-a5ba-eecae2e6038c", "f639d4a0-e1b7-488b-b99e-aa3d182ebc5f" }
                });
        }
    }
}

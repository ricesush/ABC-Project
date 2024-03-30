using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ABC.Client.Migrations
{
    /// <inheritdoc />
    public partial class changedStatusofProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "396561dc-3ada-4d94-80bb-d3743795ef3a", "11f56711-e9e8-4859-a4d5-521f95cf8f0a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8e7e6469-30b3-42eb-8504-4508b8a71dc1", "1d1d6d57-99b4-4bae-9df9-517a07a1a810" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "75358206-2d78-4dd7-8dd4-e784623f864c", "2d0d8b23-a7cf-4dd6-9a8e-88d18f3a7f7f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c7016ec8-9293-421e-af6a-8ed6406ab0a6", "d40f295f-4435-4f1d-83fe-22014741caa4" });

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("79d4853e-5463-49b0-8922-fd09c52c57f2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "396561dc-3ada-4d94-80bb-d3743795ef3a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75358206-2d78-4dd7-8dd4-e784623f864c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e7e6469-30b3-42eb-8504-4508b8a71dc1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7016ec8-9293-421e-af6a-8ed6406ab0a6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11f56711-e9e8-4859-a4d5-521f95cf8f0a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1d1d6d57-99b4-4bae-9df9-517a07a1a810");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2d0d8b23-a7cf-4dd6-9a8e-88d18f3a7f7f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d40f295f-4435-4f1d-83fe-22014741caa4");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "EndSaleDate",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "17c1bed5-0b14-482e-b260-878dc8d65d10", null, "Admin", "ADMIN" },
                    { "63a131ae-07bc-42ae-a0e3-f2aa69d593b1", null, "Employee", "EMPLOYEE" },
                    { "ad9a7c0a-58d6-4f70-adcc-a691bfea4716", null, "Customer", "CUSTOMER" },
                    { "dea49970-ba2e-4189-b00b-9413375878a0", null, "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "Province", "SecurityStamp", "StoreId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "68e95a5e-b855-4b34-81fe-68532c11543d", 0, null, null, "ea55a40b-fcd5-49ba-8868-ebadfb31b4e6", "cust@abc.com", true, "Ej Customer", "Esan", false, null, null, "CUST@ABC.COM", "AQAAAAIAAYagAAAAEAH0/XYcHDMkslaV5/2S+IF0BFG/ewG8xUYL4auPDqPkVQntNfOcG6MD6WbqOdniyw==", null, false, null, null, "9ba467d0-c875-43f2-b3ea-1e3786f02be5", null, false, "cust@abc.com" },
                    { "7bf0e188-2c97-4276-ba3d-62e9302c7da4", 0, null, null, "1be0a2e2-759c-4aa2-9b0d-a943df772ed2", "manager@abc.com", true, "Ej Manager", "Esan", false, null, null, "MANAGER@ABC.COM", "AQAAAAIAAYagAAAAEJjUa0w7nTKbM4Sfuq7757WidVrLG3SYnmwBqat49/LFRc7l+RwbJvosFXZL6+f16g==", null, false, null, null, "2e0a0202-3e11-46e4-9b76-2cf7af75102e", null, false, "manager@abc.com" },
                    { "7f24ed53-fb08-4add-9d09-c8ef36747db0", 0, null, null, "86c89c3a-b0ba-4433-bc57-5ecf6788362d", "admin@abc.com", true, "Ej Admin", "Esan", false, null, null, "ADMIN@ABC.COM", "AQAAAAIAAYagAAAAEP43tjxLu1uHqcJDF7HCzdOmQVoQCf97LK4zneXegsVnJegIc8dhKSJYdTyLgxCVlQ==", null, false, null, null, "61e92534-32fb-4983-9ef6-607f76a1b770", null, false, "admin@abc.com" },
                    { "bd4f17de-d00c-497b-ba91-3568334e9d13", 0, null, null, "2d137727-9c75-4c81-925b-8b65c4bfe94a", "emp@abc.com", true, "Ej Employee", "Esan", false, null, null, "EMP@ABC.COM", "AQAAAAIAAYagAAAAEMwXJHeSx7I0b7f1cNS9n7gr1uac3A1nsX9VQ5LZX/AidKZ979BmpMsI3RjseMxmEg==", null, false, null, null, "7bf076a3-356b-4ac1-a74f-74569fa6e9ea", null, false, "emp@abc.com" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "ApSuUn", "Barangay", "City", "ContactNumber", "EmailAddress", "FirstName", "LastName", "Province", "StreetorSubd", "Type", "ZipCode" },
                values: new object[] { new Guid("2b115604-8538-4080-acca-9bb6b3aea9e1"), "Unit 1234", "Batman", "Antipolo", 9568271611L, "neiljejomar@gmail.com", "Kurt", "Betonio", "Rizal", "Jasmine St.", "Walk in", 1870 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "status",
                value: "Active");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ad9a7c0a-58d6-4f70-adcc-a691bfea4716", "68e95a5e-b855-4b34-81fe-68532c11543d" },
                    { "dea49970-ba2e-4189-b00b-9413375878a0", "7bf0e188-2c97-4276-ba3d-62e9302c7da4" },
                    { "17c1bed5-0b14-482e-b260-878dc8d65d10", "7f24ed53-fb08-4add-9d09-c8ef36747db0" },
                    { "63a131ae-07bc-42ae-a0e3-f2aa69d593b1", "bd4f17de-d00c-497b-ba91-3568334e9d13" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad9a7c0a-58d6-4f70-adcc-a691bfea4716", "68e95a5e-b855-4b34-81fe-68532c11543d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "dea49970-ba2e-4189-b00b-9413375878a0", "7bf0e188-2c97-4276-ba3d-62e9302c7da4" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "17c1bed5-0b14-482e-b260-878dc8d65d10", "7f24ed53-fb08-4add-9d09-c8ef36747db0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "63a131ae-07bc-42ae-a0e3-f2aa69d593b1", "bd4f17de-d00c-497b-ba91-3568334e9d13" });

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("2b115604-8538-4080-acca-9bb6b3aea9e1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17c1bed5-0b14-482e-b260-878dc8d65d10");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63a131ae-07bc-42ae-a0e3-f2aa69d593b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad9a7c0a-58d6-4f70-adcc-a691bfea4716");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dea49970-ba2e-4189-b00b-9413375878a0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "68e95a5e-b855-4b34-81fe-68532c11543d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7bf0e188-2c97-4276-ba3d-62e9302c7da4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7f24ed53-fb08-4add-9d09-c8ef36747db0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bd4f17de-d00c-497b-ba91-3568334e9d13");

            migrationBuilder.AlterColumn<bool>(
                name: "status",
                table: "Products",
                type: "bit",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndSaleDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "396561dc-3ada-4d94-80bb-d3743795ef3a", null, "Employee", "EMPLOYEE" },
                    { "75358206-2d78-4dd7-8dd4-e784623f864c", null, "Manager", "MANAGER" },
                    { "8e7e6469-30b3-42eb-8504-4508b8a71dc1", null, "Customer", "CUSTOMER" },
                    { "c7016ec8-9293-421e-af6a-8ed6406ab0a6", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "Province", "SecurityStamp", "StoreId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "11f56711-e9e8-4859-a4d5-521f95cf8f0a", 0, null, null, "51190ac5-5b05-47b2-bc4e-986cb266f4cf", "emp@abc.com", true, "Ej Employee", "Esan", false, null, null, "EMP@ABC.COM", "AQAAAAIAAYagAAAAEGZ9CiYLh+dQmmmRWBVLmtWdxcqzwBm15bXEEXCZqHTCjRNdKqCPc6bYOLqQghv9mg==", null, false, null, null, "ac57c541-9ff9-4a0a-bc8e-cdf8000be5ce", null, false, "emp@abc.com" },
                    { "1d1d6d57-99b4-4bae-9df9-517a07a1a810", 0, null, null, "7fc213ad-494b-4202-a3b8-a3cb02494772", "cust@abc.com", true, "Ej Customer", "Esan", false, null, null, "CUST@ABC.COM", "AQAAAAIAAYagAAAAEC5sRmqpwJfG7WVIUcuSpPEk4owiPDBQ79mFqCz2KceESeG/z4bnea9lPWqc26rGkw==", null, false, null, null, "0c182087-5d2b-4105-8f44-23142fbab38f", null, false, "cust@abc.com" },
                    { "2d0d8b23-a7cf-4dd6-9a8e-88d18f3a7f7f", 0, null, null, "1ffd56e5-d848-4670-8791-0cdd0016bbcf", "manager@abc.com", true, "Ej Manager", "Esan", false, null, null, "MANAGER@ABC.COM", "AQAAAAIAAYagAAAAEHAvzdIqbpjEyv4hYOz3dqlj0A3I6GTyg1Hz5Rb2b3lXTa+sluOJHfyS+qlW/h1yig==", null, false, null, null, "f14cb160-6588-4448-886a-3bf340a74fe2", null, false, "manager@abc.com" },
                    { "d40f295f-4435-4f1d-83fe-22014741caa4", 0, null, null, "7a494a51-e020-44ae-b70e-c6e1d5287d8d", "admin@abc.com", true, "Ej Admin", "Esan", false, null, null, "ADMIN@ABC.COM", "AQAAAAIAAYagAAAAEAECVUveOwvQxWkGbRKghlfbd6q1fLuoufv7/N+lkIEIVN3XCIabbxqp7leyxyt7pg==", null, false, null, null, "52d9eade-eb65-4848-9566-da5cd1e2f4ab", null, false, "admin@abc.com" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "ApSuUn", "Barangay", "City", "ContactNumber", "EmailAddress", "FirstName", "LastName", "Province", "StreetorSubd", "Type", "ZipCode" },
                values: new object[] { new Guid("79d4853e-5463-49b0-8922-fd09c52c57f2"), "Unit 1234", "Batman", "Antipolo", 9568271611L, "neiljejomar@gmail.com", "Kurt", "Betonio", "Rizal", "Jasmine St.", "Walk in", 1870 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateAdded", "EndSaleDate", "status" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateAdded", "EndSaleDate", "status" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateAdded", "EndSaleDate", "status" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateAdded", "EndSaleDate", "status" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateAdded", "EndSaleDate", "status" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "396561dc-3ada-4d94-80bb-d3743795ef3a", "11f56711-e9e8-4859-a4d5-521f95cf8f0a" },
                    { "8e7e6469-30b3-42eb-8504-4508b8a71dc1", "1d1d6d57-99b4-4bae-9df9-517a07a1a810" },
                    { "75358206-2d78-4dd7-8dd4-e784623f864c", "2d0d8b23-a7cf-4dd6-9a8e-88d18f3a7f7f" },
                    { "c7016ec8-9293-421e-af6a-8ed6406ab0a6", "d40f295f-4435-4f1d-83fe-22014741caa4" }
                });
        }
    }
}

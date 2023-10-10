using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTableSystemParameter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("ce7ccc94-ad8f-469b-99e1-8bdef2109071"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("61536409-8e85-4348-9699-8ed4c56f5f67"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b30c9723-1de3-48e5-9f59-44d87d86284a"));

            migrationBuilder.CreateTable(
                name: "SystemParameters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParameterKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParameterValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SampleValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemParameters", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[] { new Guid("daec6604-33ad-4232-8f2e-1ff812afb58d"), "Admin", new DateTime(2023, 10, 10, 11, 42, 46, 782, DateTimeKind.Local).AddTicks(1897), null, null, null, "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedBy", "CreatedDate", "CultureType", "DeletedDate", "Email", "FirstName", "LastName", "ModifiedBy", "ModifiedDate", "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new Guid("69fa64e3-e59a-4908-84f4-cae7e1491f03"), 0, "Admin", new DateTime(2023, 10, 10, 11, 42, 46, 783, DateTimeKind.Local).AddTicks(3625), 0, null, "admin@admin.com", "Admin", "Admin", null, null, new byte[] { 201, 123, 213, 71, 130, 181, 88, 137, 8, 151, 83, 220, 238, 234, 30, 174, 230, 127, 68, 214, 228, 103, 235, 78, 218, 243, 163, 119, 33, 118, 28, 107, 224, 92, 105, 20, 199, 216, 151, 229, 65, 19, 193, 40, 88, 53, 110, 189, 124, 20, 227, 159, 169, 109, 54, 150, 233, 41, 70, 201, 77, 207, 73, 24 }, new byte[] { 195, 135, 183, 186, 30, 58, 225, 148, 133, 98, 3, 226, 231, 171, 189, 29, 12, 101, 104, 21, 208, 111, 119, 21, 106, 191, 169, 228, 172, 195, 69, 65, 44, 62, 51, 243, 124, 203, 72, 130, 226, 158, 98, 43, 70, 133, 123, 202, 243, 16, 47, 26, 52, 220, 132, 244, 79, 84, 70, 227, 81, 39, 19, 237, 144, 118, 219, 141, 29, 135, 93, 25, 157, 60, 27, 102, 244, 225, 46, 32, 1, 96, 246, 239, 223, 244, 173, 17, 98, 161, 162, 235, 56, 0, 203, 135, 143, 127, 13, 123, 44, 244, 179, 106, 161, 142, 33, 112, 5, 45, 151, 85, 242, 213, 229, 72, 238, 238, 219, 194, 218, 210, 252, 19, 248, 118, 202, 135 }, 1 });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("59e6c0de-a212-40c7-b794-44525435fee2"), "Admin", new DateTime(2023, 10, 10, 11, 42, 46, 783, DateTimeKind.Local).AddTicks(8898), null, null, null, new Guid("daec6604-33ad-4232-8f2e-1ff812afb58d"), 1, new Guid("69fa64e3-e59a-4908-84f4-cae7e1491f03") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemParameters");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("59e6c0de-a212-40c7-b794-44525435fee2"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("daec6604-33ad-4232-8f2e-1ff812afb58d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69fa64e3-e59a-4908-84f4-cae7e1491f03"));

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[] { new Guid("61536409-8e85-4348-9699-8ed4c56f5f67"), "Admin", new DateTime(2023, 10, 9, 17, 31, 0, 994, DateTimeKind.Local).AddTicks(9277), null, null, null, "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedBy", "CreatedDate", "CultureType", "DeletedDate", "Email", "FirstName", "LastName", "ModifiedBy", "ModifiedDate", "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new Guid("b30c9723-1de3-48e5-9f59-44d87d86284a"), 0, "Admin", new DateTime(2023, 10, 9, 17, 31, 0, 996, DateTimeKind.Local).AddTicks(4949), 0, null, "admin@admin.com", "Admin", "Admin", null, null, new byte[] { 144, 207, 230, 125, 169, 78, 34, 52, 16, 71, 110, 187, 85, 37, 182, 96, 146, 104, 82, 94, 196, 179, 240, 184, 20, 194, 244, 57, 8, 53, 10, 87, 24, 233, 51, 40, 47, 172, 129, 109, 25, 169, 104, 29, 186, 114, 71, 73, 140, 246, 72, 159, 141, 245, 77, 138, 166, 78, 16, 236, 193, 105, 61, 187 }, new byte[] { 157, 147, 29, 150, 242, 170, 126, 168, 76, 122, 78, 31, 72, 233, 97, 62, 212, 119, 63, 1, 86, 70, 138, 221, 174, 200, 0, 116, 23, 224, 222, 43, 247, 118, 152, 208, 13, 112, 229, 57, 48, 19, 103, 89, 232, 29, 151, 145, 160, 227, 207, 25, 41, 17, 167, 127, 81, 183, 81, 128, 27, 127, 140, 59, 211, 156, 4, 43, 135, 231, 184, 95, 99, 249, 175, 72, 200, 203, 145, 181, 251, 113, 108, 101, 207, 164, 135, 192, 43, 217, 237, 35, 226, 177, 46, 66, 100, 24, 152, 114, 176, 8, 89, 253, 10, 162, 52, 170, 209, 101, 176, 26, 29, 158, 32, 145, 17, 219, 170, 144, 107, 158, 185, 185, 213, 221, 133, 44 }, 1 });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("ce7ccc94-ad8f-469b-99e1-8bdef2109071"), "Admin", new DateTime(2023, 10, 9, 17, 31, 0, 997, DateTimeKind.Local).AddTicks(1856), null, null, null, new Guid("61536409-8e85-4348-9699-8ed4c56f5f67"), 1, new Guid("b30c9723-1de3-48e5-9f59-44d87d86284a") });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTableContract : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("152635dc-0745-4b8e-a617-afbcedfcb55a"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("f4709c7f-4c99-4a9e-818d-1e6dbe984e8d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("09dbef42-982b-4009-b815-ff24ff897593"));

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[] { new Guid("3b966010-f430-432a-b61f-3e6d99d6caca"), "Admin", new DateTime(2023, 10, 3, 12, 38, 37, 741, DateTimeKind.Local).AddTicks(2914), null, null, null, "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedBy", "CreatedDate", "CultureType", "DeletedDate", "Email", "FirstName", "LastName", "ModifiedBy", "ModifiedDate", "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new Guid("90ba4547-e809-4faa-9dd8-e4e12af9ae4a"), 0, "Admin", new DateTime(2023, 10, 3, 12, 38, 37, 742, DateTimeKind.Local).AddTicks(2327), 0, null, "admin@admin.com", "Admin", "Admin", null, null, new byte[] { 51, 210, 145, 17, 79, 25, 115, 234, 81, 163, 243, 81, 25, 206, 184, 162, 89, 24, 122, 180, 102, 118, 222, 219, 192, 103, 127, 241, 80, 188, 154, 246, 149, 242, 219, 192, 46, 147, 244, 7, 244, 248, 125, 66, 219, 152, 36, 31, 52, 53, 61, 35, 184, 151, 157, 105, 212, 57, 179, 193, 78, 244, 132, 59 }, new byte[] { 217, 29, 90, 249, 171, 157, 215, 148, 69, 95, 208, 190, 165, 187, 84, 11, 198, 28, 208, 79, 157, 226, 121, 107, 178, 99, 93, 81, 161, 71, 150, 1, 108, 75, 51, 122, 169, 13, 139, 138, 37, 254, 10, 140, 95, 128, 216, 227, 210, 130, 185, 22, 152, 65, 94, 15, 226, 97, 185, 43, 68, 248, 251, 48, 221, 28, 136, 75, 36, 42, 73, 220, 203, 195, 79, 140, 167, 5, 224, 4, 55, 26, 125, 216, 43, 192, 146, 72, 184, 59, 214, 225, 133, 248, 245, 196, 67, 62, 214, 144, 245, 147, 253, 167, 156, 114, 2, 99, 25, 168, 117, 170, 214, 57, 243, 121, 155, 220, 205, 42, 61, 233, 69, 78, 138, 252, 116, 59 }, 1 });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("36f5bd2b-4380-49dd-b7c9-a134101363b3"), "Admin", new DateTime(2023, 10, 3, 12, 38, 37, 742, DateTimeKind.Local).AddTicks(6976), null, null, null, new Guid("3b966010-f430-432a-b61f-3e6d99d6caca"), 1, new Guid("90ba4547-e809-4faa-9dd8-e4e12af9ae4a") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("36f5bd2b-4380-49dd-b7c9-a134101363b3"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("3b966010-f430-432a-b61f-3e6d99d6caca"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("90ba4547-e809-4faa-9dd8-e4e12af9ae4a"));

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[] { new Guid("f4709c7f-4c99-4a9e-818d-1e6dbe984e8d"), "Admin", new DateTime(2023, 9, 28, 17, 32, 22, 853, DateTimeKind.Local).AddTicks(8885), null, null, null, "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedBy", "CreatedDate", "CultureType", "DeletedDate", "Email", "FirstName", "LastName", "ModifiedBy", "ModifiedDate", "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new Guid("09dbef42-982b-4009-b815-ff24ff897593"), 0, "Admin", new DateTime(2023, 9, 28, 17, 32, 22, 855, DateTimeKind.Local).AddTicks(1006), 0, null, "admin@admin.com", "Admin", "Admin", null, null, new byte[] { 87, 234, 181, 62, 151, 141, 225, 152, 183, 140, 136, 8, 126, 187, 91, 65, 29, 96, 101, 130, 148, 134, 65, 187, 75, 244, 253, 191, 114, 199, 194, 14, 226, 96, 198, 99, 166, 227, 28, 40, 47, 89, 55, 199, 83, 35, 174, 55, 176, 175, 177, 39, 111, 77, 108, 194, 185, 16, 107, 86, 121, 244, 26, 74 }, new byte[] { 15, 7, 23, 4, 152, 143, 195, 130, 172, 213, 85, 249, 137, 255, 150, 221, 119, 132, 183, 254, 206, 252, 9, 63, 54, 8, 172, 26, 179, 71, 66, 101, 252, 236, 201, 65, 243, 51, 170, 171, 11, 83, 241, 68, 91, 196, 240, 42, 20, 246, 105, 231, 129, 91, 229, 111, 115, 8, 101, 173, 65, 76, 184, 236, 43, 107, 229, 177, 109, 234, 26, 25, 73, 232, 228, 78, 33, 111, 233, 17, 247, 162, 46, 17, 138, 15, 164, 14, 35, 123, 81, 143, 104, 181, 61, 81, 192, 236, 176, 147, 206, 9, 62, 37, 22, 107, 44, 253, 24, 44, 120, 234, 241, 132, 226, 157, 156, 244, 12, 26, 164, 145, 11, 47, 121, 225, 189, 131 }, 1 });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("152635dc-0745-4b8e-a617-afbcedfcb55a"), "Admin", new DateTime(2023, 9, 28, 17, 32, 22, 855, DateTimeKind.Local).AddTicks(6914), null, null, null, new Guid("f4709c7f-4c99-4a9e-818d-1e6dbe984e8d"), 1, new Guid("09dbef42-982b-4009-b815-ff24ff897593") });
        }
    }
}

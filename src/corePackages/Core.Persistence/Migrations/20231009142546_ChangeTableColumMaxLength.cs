using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTableColumMaxLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "QrCode",
                table: "Tips",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentReference",
                table: "Tips",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "QrCode",
                table: "Invoices",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "Invoices",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[] { new Guid("310e5624-ae58-4ef5-91bc-61fd58c3e84a"), "Admin", new DateTime(2023, 10, 9, 17, 25, 46, 684, DateTimeKind.Local).AddTicks(5418), null, null, null, "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedBy", "CreatedDate", "CultureType", "DeletedDate", "Email", "FirstName", "LastName", "ModifiedBy", "ModifiedDate", "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new Guid("ee2bb6ed-1ba9-4a1d-b041-490bd67d20f1"), 0, "Admin", new DateTime(2023, 10, 9, 17, 25, 46, 685, DateTimeKind.Local).AddTicks(8105), 0, null, "admin@admin.com", "Admin", "Admin", null, null, new byte[] { 138, 106, 88, 177, 160, 140, 145, 219, 58, 186, 102, 45, 5, 14, 191, 213, 198, 0, 14, 80, 63, 251, 42, 122, 54, 208, 184, 103, 34, 58, 222, 254, 134, 40, 198, 42, 234, 180, 153, 115, 197, 206, 49, 216, 47, 38, 91, 131, 75, 154, 174, 44, 253, 53, 45, 75, 218, 149, 10, 100, 208, 186, 79, 155 }, new byte[] { 103, 114, 222, 241, 172, 10, 34, 131, 125, 109, 107, 151, 98, 19, 34, 111, 225, 252, 215, 238, 15, 49, 57, 37, 203, 14, 74, 96, 200, 196, 76, 225, 78, 48, 198, 211, 200, 231, 53, 188, 204, 249, 35, 93, 176, 154, 252, 51, 60, 81, 53, 200, 134, 253, 63, 81, 193, 20, 126, 178, 106, 11, 106, 85, 87, 232, 110, 77, 72, 91, 229, 248, 240, 100, 205, 89, 209, 76, 204, 25, 27, 38, 23, 206, 42, 252, 88, 151, 94, 187, 67, 155, 125, 172, 113, 88, 209, 26, 155, 22, 215, 175, 204, 23, 101, 69, 198, 177, 245, 50, 32, 58, 155, 179, 101, 64, 37, 82, 154, 119, 94, 29, 173, 129, 134, 204, 216, 210 }, 1 });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("f64a9ce4-3659-49cc-b97a-d2a5ece35f80"), "Admin", new DateTime(2023, 10, 9, 17, 25, 46, 686, DateTimeKind.Local).AddTicks(4751), null, null, null, new Guid("310e5624-ae58-4ef5-91bc-61fd58c3e84a"), 1, new Guid("ee2bb6ed-1ba9-4a1d-b041-490bd67d20f1") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("f64a9ce4-3659-49cc-b97a-d2a5ece35f80"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("310e5624-ae58-4ef5-91bc-61fd58c3e84a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ee2bb6ed-1ba9-4a1d-b041-490bd67d20f1"));

            migrationBuilder.AlterColumn<string>(
                name: "QrCode",
                table: "Tips",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "PaymentReference",
                table: "Tips",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "QrCode",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

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
    }
}

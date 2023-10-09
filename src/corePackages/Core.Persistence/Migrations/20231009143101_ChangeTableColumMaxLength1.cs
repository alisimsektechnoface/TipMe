using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTableColumMaxLength1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Photo",
                table: "Waiters",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Waiters",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stores",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Options",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsHappy",
                table: "Options",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Icon",
                table: "Options",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Contracts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.CreateIndex(
                name: "IX_Tips_QrCode",
                table: "Tips",
                column: "QrCode");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_QrCode",
                table: "Invoices",
                column: "QrCode");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_Url",
                table: "Contracts",
                column: "Url");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tips_QrCode",
                table: "Tips");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_QrCode",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_Url",
                table: "Contracts");

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

            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "Waiters",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Waiters",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Options",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<bool>(
                name: "IsHappy",
                table: "Options",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Icon",
                table: "Options",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
    }
}

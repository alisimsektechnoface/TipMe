using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("721a810d-2698-474c-ab4c-69066d9a2556"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("7911d86f-4b57-4faa-9d9f-99158077da46"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("27089910-95fb-4936-a0c3-e3ab0a0f6740"));

            migrationBuilder.AddColumn<Guid>(
                name: "TipId",
                table: "Invoices",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_TipId",
                table: "Invoices",
                column: "TipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Tips_TipId",
                table: "Invoices",
                column: "TipId",
                principalTable: "Tips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Tips_TipId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_TipId",
                table: "Invoices");

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

            migrationBuilder.DropColumn(
                name: "TipId",
                table: "Invoices");

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[] { new Guid("7911d86f-4b57-4faa-9d9f-99158077da46"), "Admin", new DateTime(2023, 9, 28, 15, 37, 15, 684, DateTimeKind.Local).AddTicks(586), null, null, null, "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedBy", "CreatedDate", "CultureType", "DeletedDate", "Email", "FirstName", "LastName", "ModifiedBy", "ModifiedDate", "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new Guid("27089910-95fb-4936-a0c3-e3ab0a0f6740"), 0, "Admin", new DateTime(2023, 9, 28, 15, 37, 15, 685, DateTimeKind.Local).AddTicks(2859), 0, null, "admin@admin.com", "Admin", "Admin", null, null, new byte[] { 255, 225, 230, 50, 179, 240, 167, 31, 171, 101, 104, 184, 207, 65, 87, 115, 1, 61, 215, 248, 220, 124, 238, 8, 13, 121, 187, 50, 177, 48, 55, 46, 147, 245, 116, 252, 58, 67, 194, 28, 208, 120, 160, 4, 232, 223, 99, 187, 248, 100, 17, 2, 94, 132, 113, 199, 93, 226, 219, 239, 246, 124, 185, 184 }, new byte[] { 111, 191, 121, 106, 143, 163, 105, 9, 21, 193, 30, 3, 61, 51, 233, 242, 255, 162, 241, 137, 207, 165, 189, 77, 126, 248, 181, 68, 203, 196, 129, 142, 162, 53, 107, 69, 134, 230, 88, 81, 2, 31, 151, 101, 164, 175, 236, 18, 215, 211, 253, 108, 209, 65, 3, 25, 109, 48, 31, 214, 80, 124, 66, 137, 196, 183, 248, 133, 58, 62, 63, 80, 49, 106, 132, 1, 14, 208, 209, 20, 60, 180, 164, 62, 83, 109, 5, 91, 93, 242, 71, 100, 186, 29, 6, 77, 34, 9, 237, 4, 8, 250, 136, 3, 133, 137, 3, 115, 255, 35, 200, 133, 10, 243, 36, 61, 189, 181, 51, 202, 26, 82, 22, 100, 43, 56, 10, 6 }, 1 });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("721a810d-2698-474c-ab4c-69066d9a2556"), "Admin", new DateTime(2023, 9, 28, 15, 37, 15, 685, DateTimeKind.Local).AddTicks(9406), null, null, null, new Guid("7911d86f-4b57-4faa-9d9f-99158077da46"), 1, new Guid("27089910-95fb-4936-a0c3-e3ab0a0f6740") });
        }
    }
}

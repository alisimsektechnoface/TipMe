using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("027b47df-be82-4315-80f1-b047607b0808"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("5841449c-4b34-454a-acc1-d802ee198530"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8435d78f-cfe4-4a6b-b6b7-4b686761379c"));

            migrationBuilder.AddColumn<decimal>(
                name: "TipAmount",
                table: "Tips",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "TipAmount",
                table: "Tips");

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[] { new Guid("5841449c-4b34-454a-acc1-d802ee198530"), "Admin", new DateTime(2023, 9, 28, 12, 22, 1, 160, DateTimeKind.Local).AddTicks(4118), null, null, null, "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedBy", "CreatedDate", "CultureType", "DeletedDate", "Email", "FirstName", "LastName", "ModifiedBy", "ModifiedDate", "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new Guid("8435d78f-cfe4-4a6b-b6b7-4b686761379c"), 0, "Admin", new DateTime(2023, 9, 28, 12, 22, 1, 161, DateTimeKind.Local).AddTicks(4670), 0, null, "admin@admin.com", "Admin", "Admin", null, null, new byte[] { 92, 244, 195, 46, 10, 206, 187, 196, 72, 33, 167, 212, 154, 32, 248, 51, 28, 69, 73, 80, 110, 156, 173, 108, 114, 100, 51, 194, 113, 38, 173, 98, 22, 224, 65, 145, 227, 0, 1, 14, 16, 217, 116, 137, 161, 28, 7, 35, 203, 81, 221, 147, 99, 33, 179, 19, 161, 243, 203, 195, 147, 145, 65, 44 }, new byte[] { 5, 240, 238, 118, 30, 128, 171, 184, 252, 21, 94, 19, 221, 151, 19, 249, 247, 91, 154, 163, 101, 36, 242, 141, 155, 228, 7, 18, 9, 46, 111, 67, 78, 244, 223, 247, 102, 239, 63, 203, 181, 106, 213, 203, 151, 167, 18, 246, 49, 255, 43, 89, 127, 164, 114, 144, 18, 93, 221, 186, 115, 197, 12, 198, 150, 42, 252, 139, 204, 105, 61, 185, 44, 193, 49, 139, 198, 175, 103, 76, 143, 95, 231, 200, 63, 5, 63, 42, 240, 243, 226, 54, 14, 180, 12, 201, 161, 183, 167, 154, 97, 223, 248, 73, 244, 164, 196, 75, 176, 177, 14, 120, 168, 82, 30, 151, 135, 139, 31, 248, 201, 133, 23, 45, 39, 52, 219, 180 }, 1 });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("027b47df-be82-4315-80f1-b047607b0808"), "Admin", new DateTime(2023, 9, 28, 12, 22, 1, 161, DateTimeKind.Local).AddTicks(9778), null, null, null, new Guid("5841449c-4b34-454a-acc1-d802ee198530"), 1, new Guid("8435d78f-cfe4-4a6b-b6b7-4b686761379c") });
        }
    }
}

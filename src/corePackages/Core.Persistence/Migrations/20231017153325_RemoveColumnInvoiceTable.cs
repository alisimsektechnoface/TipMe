using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveColumnInvoiceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Stores_StoreId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_StoreId",
                table: "Invoices");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("a606f482-66d6-4572-b8e2-0c83663cb854"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("2fa5d3f5-1770-45b6-af11-d8e251cc4f77"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6d64ba23-da92-4364-93ae-7b129d56b771"));

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Invoices");

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[] { new Guid("35fa2322-bd86-44de-87c5-44aaf1aa1617"), "Admin", new DateTime(2023, 10, 17, 18, 33, 25, 644, DateTimeKind.Local).AddTicks(2351), null, null, null, "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedBy", "CreatedDate", "CultureType", "DeletedDate", "Email", "FirstName", "LastName", "ModifiedBy", "ModifiedDate", "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new Guid("2dcfb8d1-516d-43ed-a205-8aed0a1cc4f4"), 0, "Admin", new DateTime(2023, 10, 17, 18, 33, 25, 645, DateTimeKind.Local).AddTicks(5931), 0, null, "admin@admin.com", "Admin", "Admin", null, null, new byte[] { 45, 75, 229, 37, 68, 7, 200, 53, 42, 51, 241, 98, 83, 148, 194, 149, 240, 207, 43, 170, 203, 120, 57, 27, 138, 246, 134, 113, 113, 12, 13, 87, 35, 173, 127, 240, 54, 145, 84, 153, 71, 233, 0, 59, 215, 161, 210, 49, 69, 214, 201, 115, 105, 212, 146, 73, 19, 226, 60, 72, 14, 140, 44, 49 }, new byte[] { 116, 169, 252, 91, 191, 197, 231, 178, 220, 59, 203, 171, 157, 206, 93, 45, 65, 216, 42, 62, 227, 84, 254, 13, 119, 5, 106, 93, 175, 122, 254, 3, 33, 97, 129, 27, 206, 139, 118, 112, 140, 90, 17, 196, 92, 108, 250, 29, 172, 180, 157, 30, 230, 158, 170, 111, 219, 145, 161, 138, 41, 88, 201, 228, 3, 226, 145, 234, 1, 77, 80, 41, 249, 130, 129, 87, 22, 216, 221, 243, 168, 170, 63, 251, 126, 52, 247, 75, 244, 187, 119, 58, 118, 238, 136, 183, 235, 47, 228, 206, 90, 33, 67, 102, 46, 215, 113, 60, 193, 134, 48, 254, 40, 13, 246, 169, 76, 155, 135, 154, 118, 234, 156, 211, 116, 26, 91, 115 }, 1 });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("3f2df83b-b87b-46ad-a79d-4cf46f8bd723"), "Admin", new DateTime(2023, 10, 17, 18, 33, 25, 646, DateTimeKind.Local).AddTicks(2546), null, null, null, new Guid("35fa2322-bd86-44de-87c5-44aaf1aa1617"), 1, new Guid("2dcfb8d1-516d-43ed-a205-8aed0a1cc4f4") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("3f2df83b-b87b-46ad-a79d-4cf46f8bd723"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("35fa2322-bd86-44de-87c5-44aaf1aa1617"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2dcfb8d1-516d-43ed-a205-8aed0a1cc4f4"));

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "Invoices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[] { new Guid("2fa5d3f5-1770-45b6-af11-d8e251cc4f77"), "Admin", new DateTime(2023, 10, 17, 18, 18, 52, 31, DateTimeKind.Local).AddTicks(5734), null, null, null, "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedBy", "CreatedDate", "CultureType", "DeletedDate", "Email", "FirstName", "LastName", "ModifiedBy", "ModifiedDate", "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new Guid("6d64ba23-da92-4364-93ae-7b129d56b771"), 0, "Admin", new DateTime(2023, 10, 17, 18, 18, 52, 32, DateTimeKind.Local).AddTicks(7674), 0, null, "admin@admin.com", "Admin", "Admin", null, null, new byte[] { 108, 19, 110, 152, 29, 20, 149, 160, 150, 97, 101, 151, 45, 143, 246, 108, 123, 40, 151, 120, 214, 145, 216, 146, 51, 137, 83, 88, 248, 190, 2, 102, 130, 155, 44, 248, 69, 236, 22, 171, 69, 180, 252, 158, 0, 243, 102, 252, 101, 239, 138, 232, 54, 83, 28, 186, 160, 22, 131, 210, 198, 241, 107, 151 }, new byte[] { 92, 131, 114, 131, 114, 39, 92, 210, 10, 160, 45, 18, 32, 101, 101, 133, 20, 20, 28, 45, 105, 204, 47, 137, 31, 186, 57, 132, 0, 127, 154, 137, 142, 250, 166, 15, 13, 232, 174, 170, 223, 166, 134, 46, 140, 9, 71, 129, 205, 18, 217, 197, 18, 227, 169, 223, 74, 65, 201, 16, 232, 180, 249, 206, 174, 140, 82, 30, 172, 183, 61, 50, 107, 23, 220, 41, 197, 18, 86, 141, 87, 252, 157, 120, 77, 94, 153, 103, 25, 173, 0, 231, 246, 13, 127, 89, 75, 73, 38, 207, 30, 4, 168, 122, 46, 3, 207, 58, 113, 201, 194, 251, 50, 237, 137, 126, 45, 37, 176, 210, 99, 61, 223, 208, 11, 164, 109, 245 }, 1 });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("a606f482-66d6-4572-b8e2-0c83663cb854"), "Admin", new DateTime(2023, 10, 17, 18, 18, 52, 33, DateTimeKind.Local).AddTicks(3367), null, null, null, new Guid("2fa5d3f5-1770-45b6-af11-d8e251cc4f77"), 1, new Guid("6d64ba23-da92-4364-93ae-7b129d56b771") });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_StoreId",
                table: "Invoices",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Stores_StoreId",
                table: "Invoices",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

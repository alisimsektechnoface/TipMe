using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddStoreColumnUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("85a21399-e3c0-4ce1-8a9d-08dbcf14a70e"));

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[] { new Guid("a67375dc-89cb-4be2-a48a-79b32f2ed936"), "Admin", new DateTime(2023, 10, 17, 19, 17, 37, 436, DateTimeKind.Local).AddTicks(2784), null, null, null, "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedBy", "CreatedDate", "CultureType", "DeletedDate", "Email", "FirstName", "LastName", "ModifiedBy", "ModifiedDate", "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new Guid("227ef9ca-d88f-4d1d-9dc5-aa0c539bee01"), 0, "Admin", new DateTime(2023, 10, 17, 19, 17, 37, 437, DateTimeKind.Local).AddTicks(5498), 0, null, "admin@admin.com", "Admin", "Admin", null, null, new byte[] { 191, 62, 111, 161, 253, 29, 227, 122, 83, 199, 116, 177, 231, 143, 233, 194, 18, 80, 154, 30, 122, 157, 95, 43, 69, 97, 185, 191, 58, 215, 14, 13, 26, 118, 167, 19, 33, 162, 67, 10, 132, 36, 41, 33, 142, 53, 23, 245, 228, 184, 116, 192, 150, 82, 66, 222, 167, 179, 197, 164, 233, 250, 198, 105 }, new byte[] { 251, 156, 139, 214, 119, 191, 206, 26, 27, 251, 205, 0, 142, 96, 178, 142, 213, 167, 66, 138, 147, 116, 225, 6, 5, 237, 224, 243, 105, 148, 166, 66, 118, 36, 39, 32, 105, 95, 251, 158, 117, 38, 20, 186, 246, 97, 195, 132, 156, 183, 182, 64, 100, 222, 59, 67, 188, 115, 6, 95, 42, 69, 239, 87, 93, 10, 57, 53, 176, 22, 16, 61, 64, 54, 231, 54, 204, 208, 8, 202, 145, 128, 77, 158, 59, 38, 12, 220, 161, 237, 243, 241, 30, 236, 39, 11, 119, 39, 5, 7, 145, 49, 138, 252, 22, 6, 76, 57, 52, 165, 156, 137, 75, 4, 118, 227, 87, 21, 185, 27, 168, 153, 32, 55, 4, 134, 149, 139 }, 1 });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("84baa481-13a2-4afd-94bd-c214dc7b2b5f"), "Admin", new DateTime(2023, 10, 17, 19, 17, 37, 438, DateTimeKind.Local).AddTicks(1012), null, null, null, new Guid("a67375dc-89cb-4be2-a48a-79b32f2ed936"), 1, new Guid("227ef9ca-d88f-4d1d-9dc5-aa0c539bee01") });

            migrationBuilder.CreateIndex(
                name: "IX_Users_StoreId",
                table: "Users",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Stores_StoreId",
                table: "Users",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Stores_StoreId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_StoreId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("84baa481-13a2-4afd-94bd-c214dc7b2b5f"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("a67375dc-89cb-4be2-a48a-79b32f2ed936"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("227ef9ca-d88f-4d1d-9dc5-aa0c539bee01"));

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Users");

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
    }
}

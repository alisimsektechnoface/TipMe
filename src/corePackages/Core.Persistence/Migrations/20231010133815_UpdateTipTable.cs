using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTipTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<decimal>(
                name: "TaxAmount",
                table: "Tips",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[] { new Guid("9f476800-d090-47e5-8a33-3d900f21a0f5"), "Admin", new DateTime(2023, 10, 10, 16, 38, 14, 960, DateTimeKind.Local).AddTicks(2068), null, null, null, "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedBy", "CreatedDate", "CultureType", "DeletedDate", "Email", "FirstName", "LastName", "ModifiedBy", "ModifiedDate", "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new Guid("62e492c9-3f16-4f97-88c1-97d297e6e3c6"), 0, "Admin", new DateTime(2023, 10, 10, 16, 38, 14, 961, DateTimeKind.Local).AddTicks(2783), 0, null, "admin@admin.com", "Admin", "Admin", null, null, new byte[] { 8, 190, 10, 165, 82, 134, 43, 78, 108, 58, 79, 57, 89, 223, 57, 10, 85, 187, 3, 127, 87, 60, 34, 144, 82, 70, 232, 32, 92, 61, 255, 214, 126, 69, 125, 100, 50, 199, 231, 160, 183, 131, 210, 161, 148, 143, 75, 32, 228, 104, 58, 172, 161, 255, 187, 59, 56, 241, 223, 128, 195, 240, 56, 61 }, new byte[] { 41, 169, 187, 54, 100, 211, 208, 106, 205, 100, 237, 2, 107, 36, 252, 191, 63, 2, 170, 104, 35, 75, 107, 153, 160, 160, 117, 176, 172, 70, 0, 5, 123, 86, 151, 176, 166, 151, 65, 27, 193, 212, 233, 112, 169, 185, 108, 120, 198, 194, 94, 128, 42, 232, 182, 238, 246, 172, 84, 104, 5, 127, 23, 38, 252, 169, 238, 192, 150, 119, 103, 247, 67, 215, 41, 19, 82, 233, 240, 54, 240, 198, 231, 161, 197, 144, 166, 32, 42, 74, 37, 92, 163, 173, 76, 210, 9, 213, 244, 26, 29, 165, 215, 2, 20, 153, 240, 115, 184, 227, 24, 180, 10, 115, 67, 76, 72, 212, 88, 106, 72, 196, 82, 14, 174, 215, 106, 238 }, 1 });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("735e3192-d68c-413c-b682-650545cb00ee"), "Admin", new DateTime(2023, 10, 10, 16, 38, 14, 961, DateTimeKind.Local).AddTicks(8161), null, null, null, new Guid("9f476800-d090-47e5-8a33-3d900f21a0f5"), 1, new Guid("62e492c9-3f16-4f97-88c1-97d297e6e3c6") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("735e3192-d68c-413c-b682-650545cb00ee"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("9f476800-d090-47e5-8a33-3d900f21a0f5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("62e492c9-3f16-4f97-88c1-97d297e6e3c6"));

            migrationBuilder.DropColumn(
                name: "TaxAmount",
                table: "Tips");

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
    }
}

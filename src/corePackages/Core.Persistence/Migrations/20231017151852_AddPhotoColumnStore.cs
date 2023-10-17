using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddPhotoColumnStore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "Waiters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Photo",
                table: "Stores");

            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "Waiters",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}

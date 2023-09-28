using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("aaf84913-b79e-457e-a2bf-98e4130fce4d"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("a101eb63-35f2-49dd-8645-306054797f16"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("68c6e50e-9031-4c65-b405-cba9368c8c6e"));

            migrationBuilder.AlterColumn<int>(
                name: "Point",
                table: "Tips",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentReference",
                table: "Tips",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentDate",
                table: "Tips",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "IsTipped",
                table: "Tips",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsCommented",
                table: "Tips",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CommentDate",
                table: "Tips",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Tips",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TipDate",
                table: "Invoices",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "Point",
                table: "Tips",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PaymentReference",
                table: "Tips",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentDate",
                table: "Tips",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsTipped",
                table: "Tips",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsCommented",
                table: "Tips",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CommentDate",
                table: "Tips",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Tips",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TipDate",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[] { new Guid("a101eb63-35f2-49dd-8645-306054797f16"), "Admin", new DateTime(2023, 9, 27, 21, 20, 36, 735, DateTimeKind.Local).AddTicks(185), null, null, null, "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedBy", "CreatedDate", "CultureType", "DeletedDate", "Email", "FirstName", "LastName", "ModifiedBy", "ModifiedDate", "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new Guid("68c6e50e-9031-4c65-b405-cba9368c8c6e"), 0, "Admin", new DateTime(2023, 9, 27, 21, 20, 36, 737, DateTimeKind.Local).AddTicks(4160), 0, null, "admin@admin.com", "Admin", "Admin", null, null, new byte[] { 54, 122, 47, 193, 206, 179, 14, 84, 95, 126, 13, 238, 159, 210, 51, 122, 58, 214, 120, 41, 223, 139, 112, 232, 122, 153, 233, 62, 166, 29, 119, 137, 254, 61, 252, 169, 7, 211, 123, 39, 130, 119, 129, 210, 125, 243, 235, 195, 62, 146, 110, 48, 255, 127, 6, 45, 157, 34, 162, 239, 154, 200, 75, 255 }, new byte[] { 164, 53, 145, 191, 72, 23, 25, 251, 255, 57, 233, 119, 65, 145, 71, 195, 181, 133, 243, 16, 113, 232, 167, 244, 55, 181, 50, 141, 252, 6, 121, 154, 8, 101, 100, 80, 225, 229, 58, 115, 192, 229, 198, 133, 63, 172, 4, 43, 104, 16, 89, 19, 161, 0, 110, 127, 113, 140, 209, 79, 30, 232, 57, 140, 101, 141, 204, 106, 221, 64, 31, 166, 11, 199, 10, 244, 241, 142, 15, 98, 177, 53, 84, 56, 83, 185, 241, 25, 200, 232, 21, 29, 210, 86, 80, 90, 42, 42, 226, 33, 131, 106, 213, 225, 158, 138, 179, 134, 109, 225, 214, 118, 251, 170, 133, 30, 24, 242, 229, 10, 19, 84, 130, 230, 164, 53, 78, 114 }, 1 });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("aaf84913-b79e-457e-a2bf-98e4130fce4d"), "Admin", new DateTime(2023, 9, 27, 21, 20, 36, 738, DateTimeKind.Local).AddTicks(2385), null, null, null, new Guid("a101eb63-35f2-49dd-8645-306054797f16"), 1, new Guid("68c6e50e-9031-4c65-b405-cba9368c8c6e") });
        }
    }
}

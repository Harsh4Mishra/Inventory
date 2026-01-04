using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.PersistenceService.Migrations
{
    /// <inheritdoc />
    public partial class _04012025 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_user_role_RoleID_NotEmpty",
                schema: "system",
                table: "RefUserRole");

            migrationBuilder.DropCheckConstraint(
                name: "CK_user_role_UserID_NotEmpty",
                schema: "system",
                table: "RefUserRole");

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                schema: "master",
                table: "RefUser",
                type: "INT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)");

            migrationBuilder.AddCheckConstraint(
                name: "CK_user_role_RoleID_NotZero",
                schema: "system",
                table: "RefUserRole",
                sql: "[RoleId] > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_user_role_UserID_NotZero",
                schema: "system",
                table: "RefUserRole",
                sql: "[UserId] > 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_user_role_RoleID_NotZero",
                schema: "system",
                table: "RefUserRole");

            migrationBuilder.DropCheckConstraint(
                name: "CK_user_role_UserID_NotZero",
                schema: "system",
                table: "RefUserRole");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                schema: "master",
                table: "RefUser",
                type: "VARCHAR(100)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AddCheckConstraint(
                name: "CK_user_role_RoleID_NotEmpty",
                schema: "system",
                table: "RefUserRole",
                sql: "\"RoleId\" != '00000000-0000-0000-0000-000000000000'");

            migrationBuilder.AddCheckConstraint(
                name: "CK_user_role_UserID_NotEmpty",
                schema: "system",
                table: "RefUserRole",
                sql: "\"UserId\" != '00000000-0000-0000-0000-000000000000'");
        }
    }
}

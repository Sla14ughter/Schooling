using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shooling.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "UserInfo",
                newName: "Salt");

            migrationBuilder.AddColumn<string>(
                name: "Firstname",
                table: "UserInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "UserInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "UserInfo",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "UserInfo",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Patronymic",
                table: "UserInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Firstname",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "Patronymic",
                table: "UserInfo");

            migrationBuilder.RenameColumn(
                name: "Salt",
                table: "UserInfo",
                newName: "Name");
        }
    }
}

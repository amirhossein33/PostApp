using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostApp.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddUserNameForRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Manager",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Manager",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Manager",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginAt",
                table: "Manager",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Manager",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Manager",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Driver",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Driver",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginAt",
                table: "Driver",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Driver",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Driver",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_Email",
                table: "Manager",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manager_ManagerNumber",
                table: "Manager",
                column: "ManagerNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manager_Username",
                table: "Manager",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Manager_Email",
                table: "Manager");

            migrationBuilder.DropIndex(
                name: "IX_Manager_ManagerNumber",
                table: "Manager");

            migrationBuilder.DropIndex(
                name: "IX_Manager_Username",
                table: "Manager");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Manager");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Manager");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Manager");

            migrationBuilder.DropColumn(
                name: "LastLoginAt",
                table: "Manager");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Manager");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Manager");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "LastLoginAt",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Driver");
        }
    }
}

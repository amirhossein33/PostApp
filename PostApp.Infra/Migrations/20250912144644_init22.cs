using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostApp.Infra.Migrations
{
    /// <inheritdoc />
    public partial class init22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mission_Driver_DriverId",
                table: "Mission");

            migrationBuilder.DropForeignKey(
                name: "FK_Mission_Manager_ManagerId",
                table: "Mission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mission",
                table: "Mission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Manager",
                table: "Manager");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Driver",
                table: "Driver");

            migrationBuilder.RenameTable(
                name: "Mission",
                newName: "Missions");

            migrationBuilder.RenameTable(
                name: "Manager",
                newName: "Managers");

            migrationBuilder.RenameTable(
                name: "Driver",
                newName: "Drivers");

            migrationBuilder.RenameIndex(
                name: "IX_Mission_ManagerId_CreatedDatetime",
                table: "Missions",
                newName: "IX_Missions_ManagerId_CreatedDatetime");

            migrationBuilder.RenameIndex(
                name: "IX_Mission_DriverId_CreatedDatetime",
                table: "Missions",
                newName: "IX_Missions_DriverId_CreatedDatetime");

            migrationBuilder.RenameIndex(
                name: "IX_Mission_CreatedDatetime",
                table: "Missions",
                newName: "IX_Missions_CreatedDatetime");

            migrationBuilder.RenameIndex(
                name: "IX_Manager_Username",
                table: "Managers",
                newName: "IX_Managers_Username");

            migrationBuilder.RenameIndex(
                name: "IX_Manager_ManagerNumber",
                table: "Managers",
                newName: "IX_Managers_ManagerNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Manager_Email",
                table: "Managers",
                newName: "IX_Managers_Email");

            migrationBuilder.RenameIndex(
                name: "IX_Driver_DriverNumber",
                table: "Drivers",
                newName: "IX_Drivers_DriverNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Missions",
                table: "Missions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Managers",
                table: "Managers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drivers",
                table: "Drivers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Missions_Drivers_DriverId",
                table: "Missions",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Missions_Managers_ManagerId",
                table: "Missions",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Missions_Drivers_DriverId",
                table: "Missions");

            migrationBuilder.DropForeignKey(
                name: "FK_Missions_Managers_ManagerId",
                table: "Missions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Missions",
                table: "Missions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Managers",
                table: "Managers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Drivers",
                table: "Drivers");

            migrationBuilder.RenameTable(
                name: "Missions",
                newName: "Mission");

            migrationBuilder.RenameTable(
                name: "Managers",
                newName: "Manager");

            migrationBuilder.RenameTable(
                name: "Drivers",
                newName: "Driver");

            migrationBuilder.RenameIndex(
                name: "IX_Missions_ManagerId_CreatedDatetime",
                table: "Mission",
                newName: "IX_Mission_ManagerId_CreatedDatetime");

            migrationBuilder.RenameIndex(
                name: "IX_Missions_DriverId_CreatedDatetime",
                table: "Mission",
                newName: "IX_Mission_DriverId_CreatedDatetime");

            migrationBuilder.RenameIndex(
                name: "IX_Missions_CreatedDatetime",
                table: "Mission",
                newName: "IX_Mission_CreatedDatetime");

            migrationBuilder.RenameIndex(
                name: "IX_Managers_Username",
                table: "Manager",
                newName: "IX_Manager_Username");

            migrationBuilder.RenameIndex(
                name: "IX_Managers_ManagerNumber",
                table: "Manager",
                newName: "IX_Manager_ManagerNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Managers_Email",
                table: "Manager",
                newName: "IX_Manager_Email");

            migrationBuilder.RenameIndex(
                name: "IX_Drivers_DriverNumber",
                table: "Driver",
                newName: "IX_Driver_DriverNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mission",
                table: "Mission",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Manager",
                table: "Manager",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Driver",
                table: "Driver",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mission_Driver_DriverId",
                table: "Mission",
                column: "DriverId",
                principalTable: "Driver",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mission_Manager_ManagerId",
                table: "Mission",
                column: "ManagerId",
                principalTable: "Manager",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

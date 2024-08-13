using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Appointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfileImageUrl",
                table: "AppointmentRecords",
                newName: "Time");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "AppointmentRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "AppointmentRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Mode",
                table: "AppointmentRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Problem",
                table: "AppointmentRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Solution",
                table: "AppointmentRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "AppointmentRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "AppointmentRecords");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "AppointmentRecords");

            migrationBuilder.DropColumn(
                name: "Mode",
                table: "AppointmentRecords");

            migrationBuilder.DropColumn(
                name: "Problem",
                table: "AppointmentRecords");

            migrationBuilder.DropColumn(
                name: "Solution",
                table: "AppointmentRecords");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AppointmentRecords");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "AppointmentRecords",
                newName: "ProfileImageUrl");
        }
    }
}

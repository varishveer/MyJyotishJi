using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class JyotishVi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Extertise",
                table: "JyotishRecords",
                newName: "Expertise");

            migrationBuilder.AlterColumn<bool>(
                name: "Chat",
                table: "JyotishRecords",
                type: "bit",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Expertise",
                table: "JyotishRecords",
                newName: "Extertise");

            migrationBuilder.AlterColumn<string>(
                name: "Chat",
                table: "JyotishRecords",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }
    }
}

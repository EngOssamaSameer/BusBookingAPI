using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusBookink.Migrations
{
    /// <inheritdoc />
    public partial class addTitleintoAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "TbAppointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "TbAppointments");
        }
    }
}

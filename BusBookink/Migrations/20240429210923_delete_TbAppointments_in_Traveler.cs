using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusBookink.Migrations
{
    /// <inheritdoc />
    public partial class delete_TbAppointments_in_Traveler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbAppointments_TbTraveler_TravelerId",
                table: "TbAppointments");

            migrationBuilder.DropIndex(
                name: "IX_TbAppointments_TravelerId",
                table: "TbAppointments");

            migrationBuilder.DropColumn(
                name: "TravelerId",
                table: "TbAppointments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TravelerId",
                table: "TbAppointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbAppointments_TravelerId",
                table: "TbAppointments",
                column: "TravelerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbAppointments_TbTraveler_TravelerId",
                table: "TbAppointments",
                column: "TravelerId",
                principalTable: "TbTraveler",
                principalColumn: "Id");
        }
    }
}

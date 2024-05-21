using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusBookink.Migrations
{
    /// <inheritdoc />
    public partial class addClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbDestination",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbDestination", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbTraveler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbTraveler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbAppointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DestinationId = table.Column<int>(type: "int", nullable: false),
                    MaxNumberOfTravellers = table.Column<int>(type: "int", nullable: false),
                    AppoinmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TravelerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbAppointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbAppointments_TbDestination_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "TbDestination",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TbAppointments_TbTraveler_TravelerId",
                        column: x => x.TravelerId,
                        principalTable: "TbTraveler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TravelerId = table.Column<int>(type: "int", nullable: false),
                    AppoinmentId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbRequest_TbAppointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "TbAppointments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TbRequest_TbTraveler_TravelerId",
                        column: x => x.TravelerId,
                        principalTable: "TbTraveler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbAppointments_DestinationId",
                table: "TbAppointments",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_TbAppointments_TravelerId",
                table: "TbAppointments",
                column: "TravelerId");

            migrationBuilder.CreateIndex(
                name: "IX_TbRequest_AppointmentId",
                table: "TbRequest",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TbRequest_TravelerId",
                table: "TbRequest",
                column: "TravelerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbRequest");

            migrationBuilder.DropTable(
                name: "TbAppointments");

            migrationBuilder.DropTable(
                name: "TbDestination");

            migrationBuilder.DropTable(
                name: "TbTraveler");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stafferable.Server.Migrations
{
    public partial class TimesheetRecordsAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimesheetRecords",
                columns: table => new
                {
                    RecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimesheetCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    WeekNo = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Project = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimesheetRecords", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_TimesheetRecords_TimesheetCards_TimesheetCardId",
                        column: x => x.TimesheetCardId,
                        principalTable: "TimesheetCards",
                        principalColumn: "TimesheetCardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimesheetRecords_TimesheetCardId",
                table: "TimesheetRecords",
                column: "TimesheetCardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimesheetRecords");
        }
    }
}

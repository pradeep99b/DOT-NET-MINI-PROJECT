using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medical_Laboratory_Management.Migrations
{
    /// <inheritdoc />
    public partial class AddLabAssistantIdToAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "AppointmentTime",
                table: "Appointment",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "LabAssistantId",
                table: "Appointment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_LabAssistantId",
                table: "Appointment",
                column: "LabAssistantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_LabAssistants_LabAssistantId",
                table: "Appointment",
                column: "LabAssistantId",
                principalTable: "LabAssistants",
                principalColumn: "LabAssistantId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_LabAssistants_LabAssistantId",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_LabAssistantId",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "LabAssistantId",
                table: "Appointment");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AppointmentTime",
                table: "Appointment",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");
        }
    }
}

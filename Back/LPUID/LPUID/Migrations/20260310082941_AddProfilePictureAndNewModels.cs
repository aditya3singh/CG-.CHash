using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LPUID.Migrations
{
    /// <inheritdoc />
    public partial class AddProfilePictureAndNewModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TransportAllocations");

            migrationBuilder.DropColumn(
                name: "BreakfastTime",
                table: "MessAllocations");

            migrationBuilder.DropColumn(
                name: "DinnerTime",
                table: "MessAllocations");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "MessAllocations");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MessAllocations");

            migrationBuilder.DropColumn(
                name: "LunchTime",
                table: "MessAllocations");

            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "HostelLeaves");

            migrationBuilder.DropColumn(
                name: "EmergencyContact",
                table: "HostelLeaves");

            migrationBuilder.DropColumn(
                name: "Building",
                table: "ClassSchedules");

            migrationBuilder.DropColumn(
                name: "Credits",
                table: "ClassSchedules");

            migrationBuilder.DropColumn(
                name: "FacultyName",
                table: "ClassSchedules");

            migrationBuilder.DropColumn(
                name: "Semester",
                table: "ClassSchedules");

            migrationBuilder.RenameColumn(
                name: "SubjectName",
                table: "ClassSchedules",
                newName: "Subject");

            migrationBuilder.RenameColumn(
                name: "SubjectCode",
                table: "ClassSchedules",
                newName: "Instructor");

            migrationBuilder.AlterColumn<string>(
                name: "MealPlan",
                table: "MessAllocations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "HostelLeaves",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartTime",
                table: "ClassSchedules",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndTime",
                table: "ClassSchedules",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "ClassSchedules",
                newName: "SubjectName");

            migrationBuilder.RenameColumn(
                name: "Instructor",
                table: "ClassSchedules",
                newName: "SubjectCode");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TransportAllocations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "MealPlan",
                table: "MessAllocations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BreakfastTime",
                table: "MessAllocations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DinnerTime",
                table: "MessAllocations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "MessAllocations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MessAllocations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LunchTime",
                table: "MessAllocations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "HostelLeaves",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "HostelLeaves",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmergencyContact",
                table: "HostelLeaves",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "StartTime",
                table: "ClassSchedules",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<string>(
                name: "EndTime",
                table: "ClassSchedules",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AddColumn<string>(
                name: "Building",
                table: "ClassSchedules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Credits",
                table: "ClassSchedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FacultyName",
                table: "ClassSchedules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Semester",
                table: "ClassSchedules",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LPUID.Migrations
{
    /// <inheritdoc />
    public partial class AddComprehensiveFeatures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AdmissionDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicturePath",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AllocationDate",
                table: "HostelAllocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "BedNumber",
                table: "HostelAllocations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CheckInTime",
                table: "HostelAllocations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CheckOutTime",
                table: "HostelAllocations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Floor",
                table: "HostelAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "HostelAllocations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RoomType",
                table: "HostelAllocations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WardenContact",
                table: "HostelAllocations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WardenName",
                table: "HostelAllocations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClassSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacultyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DayOfWeek = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Building = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassSchedules_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HostelLeaves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    LeaveFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmergencyContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppliedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HostelLeaves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HostelLeaves_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessAllocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    MessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MealPlan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BreakfastTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LunchTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DinnerTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessAllocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessAllocations_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransportAllocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    RouteNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PickupPoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DropPoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PickupTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DropTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonthlyFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportAllocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportAllocations_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_Email",
                table: "Students",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClassSchedules_StudentId",
                table: "ClassSchedules",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_HostelLeaves_StudentId",
                table: "HostelLeaves",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_MessAllocations_StudentId",
                table: "MessAllocations",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransportAllocations_StudentId",
                table: "TransportAllocations",
                column: "StudentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassSchedules");

            migrationBuilder.DropTable(
                name: "HostelLeaves");

            migrationBuilder.DropTable(
                name: "MessAllocations");

            migrationBuilder.DropTable(
                name: "TransportAllocations");

            migrationBuilder.DropIndex(
                name: "IX_Students_Email",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "AdmissionDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ProfilePicturePath",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "AllocationDate",
                table: "HostelAllocations");

            migrationBuilder.DropColumn(
                name: "BedNumber",
                table: "HostelAllocations");

            migrationBuilder.DropColumn(
                name: "CheckInTime",
                table: "HostelAllocations");

            migrationBuilder.DropColumn(
                name: "CheckOutTime",
                table: "HostelAllocations");

            migrationBuilder.DropColumn(
                name: "Floor",
                table: "HostelAllocations");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "HostelAllocations");

            migrationBuilder.DropColumn(
                name: "RoomType",
                table: "HostelAllocations");

            migrationBuilder.DropColumn(
                name: "WardenContact",
                table: "HostelAllocations");

            migrationBuilder.DropColumn(
                name: "WardenName",
                table: "HostelAllocations");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}

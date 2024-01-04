using System;
using System.Globalization;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthcareBackendVS.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Create Hospitals table
            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    HospitalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.HospitalID);
                });

            // Insert dummy data into Hospitals table
            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Name", "Location" },
                values: new object[,]
                {
                { "General Hospital", "City A" },
                { "Community Hospital", "City B" },
                { "Galway Hospital", "City Galway" },
                });

            // Create Patients table
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            // Insert dummy data into Patients table
            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Name" },
                values: new object[,]
                {
                { "John Doe" },
                { "Jane Smith" },
                { "Cane Theman" },
                });

            // Create Visits table
            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    VisitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    HospitalID = table.Column<int>(type: "int", nullable: false),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.VisitID);
                    table.ForeignKey(
                        name: "FK_Visits_Hospitals_HospitalID",
                        column: x => x.HospitalID,
                        principalTable: "Hospitals",
                        principalColumn: "HospitalID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visits_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // Insert dummy data into Visits table
            migrationBuilder.InsertData(
                table: "Visits",
                columns: new[] { "PatientID", "HospitalID", "VisitDate" },
                values: new object[,]
                {
                { 1, 1, DateTime.ParseExact("2022-01-01", "yyyy-MM-dd", CultureInfo.InvariantCulture) },
                { 2, 2, DateTime.ParseExact("2022-01-02", "yyyy-MM-dd", CultureInfo.InvariantCulture) },
                { 3, 3, DateTime.ParseExact("2022-01-02", "yyyy-MM-dd", CultureInfo.InvariantCulture) },
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visits_HospitalID",
                table: "Visits",
                column: "HospitalID");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_PatientID",
                table: "Visits",
                column: "PatientID");
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropTable(
                name: "Hospitals");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}

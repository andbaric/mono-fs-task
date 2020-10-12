using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Service.DataAccess.Migrations
{
    public partial class VehicleMakeDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "vehicle_make",
                columns: new[] { "Id", "Abrv", "Name" },
                values: new object[] { 325, "BMW", "BMW" });

            migrationBuilder.InsertData(
                table: "vehicle_make",
                columns: new[] { "Id", "Abrv", "Name" },
                values: new object[] { 100, "Ford", "Ford" });

            migrationBuilder.InsertData(
                table: "vehicle_make",
                columns: new[] { "Id", "Abrv", "Name" },
                values: new object[] { 200, "VW", "Volkswagen" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "vehicle_make",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "vehicle_make",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "vehicle_make",
                keyColumn: "Id",
                keyValue: 325);
        }
    }
}

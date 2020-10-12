using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Service.DataAccess.Migrations
{
    public partial class VehicleModelDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "vehicle_model",
                columns: new[] { "Id", "Abrv", "MakeId", "Name" },
                values: new object[] { 128, "X5", 325, "X5 (BMW)" });

            migrationBuilder.InsertData(
                table: "vehicle_model",
                columns: new[] { "Id", "Abrv", "MakeId", "Name" },
                values: new object[] { 2, "Golf 6", 200, "Golf 6 (VW) " });

            migrationBuilder.InsertData(
                table: "vehicle_model",
                columns: new[] { "Id", "Abrv", "MakeId", "Name" },
                values: new object[] { 3, "Golf 7", 200, "Golf 7 (VW)" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "vehicle_model",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "vehicle_model",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "vehicle_model",
                keyColumn: "Id",
                keyValue: 128);
        }
    }
}

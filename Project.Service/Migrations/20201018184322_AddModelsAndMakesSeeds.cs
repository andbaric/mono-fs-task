using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Service.DataAccess.Migrations
{
    public partial class AddModelsAndMakesSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "vehicle_make",
                keyColumn: "Id",
                keyValue: 100);

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

            migrationBuilder.DeleteData(
                table: "vehicle_make",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "vehicle_make",
                keyColumn: "Id",
                keyValue: 325);

            migrationBuilder.InsertData(
                table: "vehicle_make",
                columns: new[] { "Id", "Abrv", "Name" },
                values: new object[,]
                {
                    { 1, "BMW", "Bayerische Motoren Werke" },
                    { 15, "Hyundai", "Hyundai" },
                    { 14, "Kia", "Kia" },
                    { 13, "Mercedes", "Mercedes-Benz" },
                    { 12, "Mitsubishi", "Mitsubishi" },
                    { 11, "Suzuki", "Suzuki" },
                    { 10, "Honda", "Honda" },
                    { 16, "Nissan", "Nissan" },
                    { 9, "Toyota", "Toyota" },
                    { 7, "Peugeot", "Peugeot" },
                    { 6, "Ford", "Ford" },
                    { 5, "Renault", "Renault" },
                    { 4, "Audi", "Audi" },
                    { 3, "Opel", "Opel" },
                    { 2, "VW", "Volkswagen" },
                    { 8, "Mazda", "Mazda" },
                    { 17, "Rimac", "Rimac" }
                });

            migrationBuilder.InsertData(
                table: "vehicle_model",
                columns: new[] { "Id", "Abrv", "MakeId", "Name" },
                values: new object[,]
                {
                    { 1, "X5", 1, "X5 (BMW)" },
                    { 21, "Yaris", 9, "Yaris (Toyota)" },
                    { 22, "Auris", 9, "Auris (Toyota)" },
                    { 23, "CR-V", 10, "CR-V (Honda)" },
                    { 24, "Accord", 10, "Accord (Honda)" },
                    { 25, "SWIFT", 11, "Swift (Suzuki)" },
                    { 26, "Ignis", 11, "Ignis (Suzuki) " },
                    { 20, "Corola", 9, "Corola (Toyota) " },
                    { 27, "Jimny", 11, "Jimny 7 (Suzuki)" },
                    { 29, "Mirage", 12, "Mirage (Mitsubishi) " },
                    { 30, "G-Class", 13, "G-Class (Mercedes)" },
                    { 31, "Kona", 14, "Kona (Kia)" },
                    { 32, "Sportage", 14, "Sportage (Kia) " },
                    { 33, "Rio", 14, "Rio (Kia)" },
                    { 34, "Qashqai", 16, "Qashqai (Nissan)" },
                    { 28, "Lancer", 12, "Lancer (Mitsubishi)" },
                    { 19, "RAV4", 9, "RAV4 (Toyota)" },
                    { 18, "3", 8, "3 (Mazda)" },
                    { 17, "6", 8, "6 (Mazda)" },
                    { 2, "M4", 1, "M4 (BMW)" },
                    { 3, "Golf 7", 2, "Golf 7 (VW)" },
                    { 4, "Pasat", 2, "Pasat (VW)" },
                    { 5, "Arteon", 2, "Arteon (VW) " },
                    { 6, "Corsa", 3, "Corsa (Opel)" },
                    { 7, "A4", 4, "A4 (Audi)" },
                    { 8, "Q5", 4, "Q5 (Audi) " },
                    { 9, "Q7", 4, "Q7 (Audi)" },
                    { 10, "Megane", 5, "Megane (Renault)" },
                    { 11, "Renault", 5, "Clio (Renault) " },
                    { 12, "Mondeo", 6, "Mondeo (Ford)" },
                    { 13, "Mustang", 6, "Mustang (Ford)" },
                    { 14, "Fiesta", 6, "Fiesta (Ford) " },
                    { 15, "Focus", 6, "Focus (Ford)" },
                    { 16, "206", 7, "206 (Peugeot)" },
                    { 35, "Juke", 16, "Juke (Nissan)" },
                    { 36, "Concept_One", 17, "Concept_One (Rimac)" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "vehicle_make",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "vehicle_model",
                keyColumn: "Id",
                keyValue: 1);

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
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "vehicle_model",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "vehicle_model",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "vehicle_model",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "vehicle_model",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "vehicle_model",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "vehicle_model",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "vehicle_model",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "vehicle_model",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "vehicle_model",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "vehicle_model",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "vehicle_model",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "vehicle_model",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "vehicle_model",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "vehicle_model",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "vehicle_model",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "vehicle_model",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "vehicle_model",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "vehicle_model",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "vehicle_model",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "vehicle_model",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "vehicle_model",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "vehicle_model",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "vehicle_model",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "vehicle_model",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "vehicle_model",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "vehicle_model",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "vehicle_model",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "vehicle_model",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "vehicle_model",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "vehicle_model",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "vehicle_model",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "vehicle_model",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "vehicle_make",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "vehicle_make",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "vehicle_make",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "vehicle_make",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "vehicle_make",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "vehicle_make",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "vehicle_make",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "vehicle_make",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "vehicle_make",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "vehicle_make",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "vehicle_make",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "vehicle_make",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "vehicle_make",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "vehicle_make",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "vehicle_make",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "vehicle_make",
                keyColumn: "Id",
                keyValue: 17);

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

            migrationBuilder.InsertData(
                table: "vehicle_model",
                columns: new[] { "Id", "Abrv", "MakeId", "Name" },
                values: new object[] { 128, "X5", 325, "X5 (BMW)" });

            migrationBuilder.InsertData(
                table: "vehicle_model",
                columns: new[] { "Id", "Abrv", "MakeId", "Name" },
                values: new object[] { 3, "Golf 7", 200, "Golf 7 (VW)" });

            migrationBuilder.InsertData(
                table: "vehicle_model",
                columns: new[] { "Id", "Abrv", "MakeId", "Name" },
                values: new object[] { 2, "Golf 6", 200, "Golf 6 (VW) " });
        }
    }
}

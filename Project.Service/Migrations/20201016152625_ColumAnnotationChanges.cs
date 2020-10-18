using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Service.DataAccess.Migrations
{
    public partial class ColumAnnotationChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "vehicle_make",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "Abrv",
                table: "vehicle_make",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(16)",
                oldMaxLength: 16);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "vehicle_make",
                type: "VARCHAR(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Abrv",
                table: "vehicle_make",
                type: "VARCHAR(16)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}

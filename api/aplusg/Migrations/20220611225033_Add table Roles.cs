using Microsoft.EntityFrameworkCore.Migrations;

namespace aplusg.Migrations
{
    public partial class AddtableRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_moistureSensors",
                table: "moistureSensors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_lightSensors",
                table: "lightSensors");

            migrationBuilder.RenameTable(
                name: "moistureSensors",
                newName: "MoistureSensors");

            migrationBuilder.RenameTable(
                name: "lightSensors",
                newName: "LightSensors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoistureSensors",
                table: "MoistureSensors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LightSensors",
                table: "LightSensors",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MoistureSensors",
                table: "MoistureSensors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LightSensors",
                table: "LightSensors");

            migrationBuilder.RenameTable(
                name: "MoistureSensors",
                newName: "moistureSensors");

            migrationBuilder.RenameTable(
                name: "LightSensors",
                newName: "lightSensors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_moistureSensors",
                table: "moistureSensors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_lightSensors",
                table: "lightSensors",
                column: "Id");
        }
    }
}

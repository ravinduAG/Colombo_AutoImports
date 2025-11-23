using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColomboAutoImports.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addfueltypetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChassisId",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EngineCapacity",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChassisId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "EngineCapacity",
                table: "Vehicles");
        }
    }
}

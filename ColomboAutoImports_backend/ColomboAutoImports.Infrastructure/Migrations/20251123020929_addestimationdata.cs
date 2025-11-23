using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColomboAutoImports.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addestimationdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BankDocCharge",
                table: "SubModels",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CIF_JPY",
                table: "SubModels",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CIF_LKR",
                table: "SubModels",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ClearingCharges",
                table: "SubModels",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DeliveryCharges",
                table: "SubModels",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ExchangeRate",
                table: "SubModels",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalDuty",
                table: "SubModels",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankDocCharge",
                table: "SubModels");

            migrationBuilder.DropColumn(
                name: "CIF_JPY",
                table: "SubModels");

            migrationBuilder.DropColumn(
                name: "CIF_LKR",
                table: "SubModels");

            migrationBuilder.DropColumn(
                name: "ClearingCharges",
                table: "SubModels");

            migrationBuilder.DropColumn(
                name: "DeliveryCharges",
                table: "SubModels");

            migrationBuilder.DropColumn(
                name: "ExchangeRate",
                table: "SubModels");

            migrationBuilder.DropColumn(
                name: "TotalDuty",
                table: "SubModels");
        }
    }
}

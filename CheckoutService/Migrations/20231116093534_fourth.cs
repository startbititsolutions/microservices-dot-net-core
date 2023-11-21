using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckoutService.Migrations
{
    /// <inheritdoc />
    public partial class fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Total",
                table: "orders",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}

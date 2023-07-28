using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistem_Point_Of_Sales.Migrations
{
    /// <inheritdoc />
    public partial class updaterelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductTags");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "ProductTags");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductTags",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "ProductTags",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

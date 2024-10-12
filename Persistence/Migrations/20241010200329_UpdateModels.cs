using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Vehicle",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "Vehicle",
                newName: "TotalFee");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Vehicle",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "TotalFee",
                table: "Vehicle",
                newName: "Total");
        }
    }
}

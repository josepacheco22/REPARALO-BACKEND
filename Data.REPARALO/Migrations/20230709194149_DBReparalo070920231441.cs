using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.REPARALO.Migrations
{
    /// <inheritdoc />
    public partial class DBReparalo070920231441 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "REPLACEMENT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "REPLACEMENT",
                type: "int",
                nullable: true);
        }
    }
}

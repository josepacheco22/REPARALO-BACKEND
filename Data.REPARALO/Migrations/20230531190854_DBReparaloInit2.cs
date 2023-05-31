using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.REPARALO.Migrations
{
    /// <inheritdoc />
    public partial class DBReparaloInit2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserRegistration",
                table: "REPLACEMENT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserRegistration",
                table: "REPLACEMENT",
                type: "int",
                nullable: true);
        }
    }
}

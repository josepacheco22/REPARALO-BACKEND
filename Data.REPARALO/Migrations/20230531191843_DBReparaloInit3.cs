using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.REPARALO.Migrations
{
    /// <inheritdoc />
    public partial class DBReparaloInit3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchaseDate",
                table: "REPLACEMENT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PurchaseDate",
                table: "REPLACEMENT",
                type: "datetime(6)",
                nullable: true);
        }
    }
}

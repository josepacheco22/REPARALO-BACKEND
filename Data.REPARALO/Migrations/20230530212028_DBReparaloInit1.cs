using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Data.REPARALO.Migrations
{
    /// <inheritdoc />
    public partial class DBReparaloInit1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ACCESSORYTYPE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCESSORYTYPE", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "REPLACEMENTTYPE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REPLACEMENTTYPE", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ACCESSORY",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Code = table.Column<string>(type: "longtext", nullable: true),
                    Model = table.Column<string>(type: "longtext", nullable: true),
                    SerialNumber = table.Column<string>(type: "longtext", nullable: true),
                    IdInvoice = table.Column<string>(type: "longtext", nullable: true),
                    MTRADEMARKId = table.Column<int>(type: "int", nullable: true),
                    MACCESSORYTYPEId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true),
                    Detail = table.Column<string>(type: "longtext", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Cost = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCESSORY", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ACCESSORY_ACCESSORYTYPE_MACCESSORYTYPEId",
                        column: x => x.MACCESSORYTYPEId,
                        principalTable: "ACCESSORYTYPE",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ACCESSORY_TRADEMARK_MTRADEMARKId",
                        column: x => x.MTRADEMARKId,
                        principalTable: "TRADEMARK",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "REPLACEMENT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    PurchaseDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IdInvoice = table.Column<string>(type: "longtext", nullable: true),
                    MEQUIPMENTTYPEId = table.Column<int>(type: "int", nullable: true),
                    MTRADEMARKId = table.Column<int>(type: "int", nullable: true),
                    MREPLACEMENTTYPEId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    Model = table.Column<string>(type: "longtext", nullable: true),
                    Note = table.Column<string>(type: "longtext", nullable: true),
                    UserRegistration = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    QuantityAvailable = table.Column<int>(type: "int", nullable: true),
                    AmountUsed = table.Column<int>(type: "int", nullable: true),
                    Cost = table.Column<float>(type: "float", nullable: true),
                    Labour = table.Column<float>(type: "float", nullable: true),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REPLACEMENT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_REPLACEMENT_EQUIPMENTTYPE_MEQUIPMENTTYPEId",
                        column: x => x.MEQUIPMENTTYPEId,
                        principalTable: "EQUIPMENTTYPE",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_REPLACEMENT_REPLACEMENTTYPE_MREPLACEMENTTYPEId",
                        column: x => x.MREPLACEMENTTYPEId,
                        principalTable: "REPLACEMENTTYPE",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_REPLACEMENT_TRADEMARK_MTRADEMARKId",
                        column: x => x.MTRADEMARKId,
                        principalTable: "TRADEMARK",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ACCESSORY_MACCESSORYTYPEId",
                table: "ACCESSORY",
                column: "MACCESSORYTYPEId");

            migrationBuilder.CreateIndex(
                name: "IX_ACCESSORY_MTRADEMARKId",
                table: "ACCESSORY",
                column: "MTRADEMARKId");

            migrationBuilder.CreateIndex(
                name: "IX_REPLACEMENT_MEQUIPMENTTYPEId",
                table: "REPLACEMENT",
                column: "MEQUIPMENTTYPEId");

            migrationBuilder.CreateIndex(
                name: "IX_REPLACEMENT_MREPLACEMENTTYPEId",
                table: "REPLACEMENT",
                column: "MREPLACEMENTTYPEId");

            migrationBuilder.CreateIndex(
                name: "IX_REPLACEMENT_MTRADEMARKId",
                table: "REPLACEMENT",
                column: "MTRADEMARKId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACCESSORY");

            migrationBuilder.DropTable(
                name: "REPLACEMENT");

            migrationBuilder.DropTable(
                name: "ACCESSORYTYPE");

            migrationBuilder.DropTable(
                name: "REPLACEMENTTYPE");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Data.REPARALO.Migrations
{
    /// <inheritdoc />
    public partial class DBReparaloInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "COUNTRY",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COUNTRY", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DOCUMENTTYPE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true),
                    Min = table.Column<int>(type: "int", nullable: true),
                    Max = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOCUMENTTYPE", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EQUIPMENTTYPE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EQUIPMENTTYPE", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ORDENTYPE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDENTYPE", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TRADEMARK",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRADEMARK", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "STATE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true),
                    MCOUNTRYId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STATE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_STATE_COUNTRY_MCOUNTRYId",
                        column: x => x.MCOUNTRYId,
                        principalTable: "COUNTRY",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CITY",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true),
                    MSTATEId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CITY", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CITY_STATE_MSTATEId",
                        column: x => x.MSTATEId,
                        principalTable: "STATE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ORDENREPAIR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    MORDENTYPEId = table.Column<int>(type: "int", nullable: true),
                    DeadLine = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    MUSERCreatedId = table.Column<int>(type: "int", nullable: true),
                    MUSERAssignedId = table.Column<int>(type: "int", nullable: true),
                    AssignedTechnician = table.Column<string>(type: "longtext", nullable: true),
                    FirstName = table.Column<string>(type: "longtext", nullable: true),
                    SecondName = table.Column<string>(type: "longtext", nullable: true),
                    FirstLastName = table.Column<string>(type: "longtext", nullable: true),
                    SecondLastName = table.Column<string>(type: "longtext", nullable: true),
                    MDOCUMENTTYPEId = table.Column<int>(type: "int", nullable: true),
                    DocumentNumber = table.Column<string>(type: "longtext", nullable: true),
                    Email = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true),
                    MCOUNTRYId = table.Column<int>(type: "int", nullable: true),
                    MSTATEId = table.Column<int>(type: "int", nullable: true),
                    MCITYId = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "longtext", nullable: true),
                    MTRADEMARKId = table.Column<int>(type: "int", nullable: true),
                    Model = table.Column<string>(type: "longtext", nullable: true),
                    MEQUIPMENTTYPEId = table.Column<int>(type: "int", nullable: true),
                    IMEI1 = table.Column<string>(type: "longtext", nullable: true),
                    IMEI2 = table.Column<string>(type: "longtext", nullable: true),
                    Accessories = table.Column<string>(type: "longtext", nullable: true),
                    Symptoms = table.Column<string>(type: "longtext", nullable: true),
                    State = table.Column<string>(type: "longtext", nullable: true),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDENREPAIR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ORDENREPAIR_CITY_MCITYId",
                        column: x => x.MCITYId,
                        principalTable: "CITY",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ORDENREPAIR_COUNTRY_MCOUNTRYId",
                        column: x => x.MCOUNTRYId,
                        principalTable: "COUNTRY",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ORDENREPAIR_DOCUMENTTYPE_MDOCUMENTTYPEId",
                        column: x => x.MDOCUMENTTYPEId,
                        principalTable: "DOCUMENTTYPE",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ORDENREPAIR_EQUIPMENTTYPE_MEQUIPMENTTYPEId",
                        column: x => x.MEQUIPMENTTYPEId,
                        principalTable: "EQUIPMENTTYPE",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ORDENREPAIR_ORDENTYPE_MORDENTYPEId",
                        column: x => x.MORDENTYPEId,
                        principalTable: "ORDENTYPE",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ORDENREPAIR_STATE_MSTATEId",
                        column: x => x.MSTATEId,
                        principalTable: "STATE",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ORDENREPAIR_TRADEMARK_MTRADEMARKId",
                        column: x => x.MTRADEMARKId,
                        principalTable: "TRADEMARK",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ORDENREPAIR_USER_MUSERAssignedId",
                        column: x => x.MUSERAssignedId,
                        principalTable: "USER",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ORDENREPAIR_USER_MUSERCreatedId",
                        column: x => x.MUSERCreatedId,
                        principalTable: "USER",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CITY_MSTATEId",
                table: "CITY",
                column: "MSTATEId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDENREPAIR_MCITYId",
                table: "ORDENREPAIR",
                column: "MCITYId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDENREPAIR_MCOUNTRYId",
                table: "ORDENREPAIR",
                column: "MCOUNTRYId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDENREPAIR_MDOCUMENTTYPEId",
                table: "ORDENREPAIR",
                column: "MDOCUMENTTYPEId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDENREPAIR_MEQUIPMENTTYPEId",
                table: "ORDENREPAIR",
                column: "MEQUIPMENTTYPEId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDENREPAIR_MORDENTYPEId",
                table: "ORDENREPAIR",
                column: "MORDENTYPEId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDENREPAIR_MSTATEId",
                table: "ORDENREPAIR",
                column: "MSTATEId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDENREPAIR_MTRADEMARKId",
                table: "ORDENREPAIR",
                column: "MTRADEMARKId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDENREPAIR_MUSERAssignedId",
                table: "ORDENREPAIR",
                column: "MUSERAssignedId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDENREPAIR_MUSERCreatedId",
                table: "ORDENREPAIR",
                column: "MUSERCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_STATE_MCOUNTRYId",
                table: "STATE",
                column: "MCOUNTRYId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ORDENREPAIR");

            migrationBuilder.DropTable(
                name: "CITY");

            migrationBuilder.DropTable(
                name: "DOCUMENTTYPE");

            migrationBuilder.DropTable(
                name: "EQUIPMENTTYPE");

            migrationBuilder.DropTable(
                name: "ORDENTYPE");

            migrationBuilder.DropTable(
                name: "TRADEMARK");

            migrationBuilder.DropTable(
                name: "USER");

            migrationBuilder.DropTable(
                name: "STATE");

            migrationBuilder.DropTable(
                name: "COUNTRY");
        }
    }
}

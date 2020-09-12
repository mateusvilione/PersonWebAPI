using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace PersonWebAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Cpf = table.Column<string>(maxLength: 11, nullable: false),
                    DataBirth = table.Column<DateTime>(nullable: false),
                    ContryBirth = table.Column<string>(maxLength: 100, nullable: false),
                    StateBirth = table.Column<string>(maxLength: 100, nullable: false),
                    CityBirth = table.Column<string>(maxLength: 100, nullable: false),
                    FatherName = table.Column<string>(maxLength: 255, nullable: true),
                    MotherName = table.Column<string>(maxLength: 255, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_person_Cpf",
                table: "person",
                column: "Cpf",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "person");
        }
    }
}

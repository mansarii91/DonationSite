using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DonationSite.DataAccess.EF.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seit",
                columns: table => new
                {
                    SiteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seit", x => x.SiteID);
                });

            migrationBuilder.CreateTable(
                name: "Donate",
                columns: table => new
                {
                    DonateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonatorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SitesSiteID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donate", x => x.DonateID);
                    table.ForeignKey(
                        name: "FK_Donate_Seit_SitesSiteID",
                        column: x => x.SitesSiteID,
                        principalTable: "Seit",
                        principalColumn: "SiteID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donate_SitesSiteID",
                table: "Donate",
                column: "SitesSiteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donate");

            migrationBuilder.DropTable(
                name: "Seit");
        }
    }
}

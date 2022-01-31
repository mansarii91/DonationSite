using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DonationSite.DataAccess.EF.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Site",
                columns: table => new
                {
                    SiteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site", x => x.SiteID);
                });

            migrationBuilder.CreateTable(
                name: "Donate",
                columns: table => new
                {
                    DonateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonatorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FKSiteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donate", x => x.DonateID);
                    table.ForeignKey(
                        name: "FK_Donate_Site_FKSiteID",
                        column: x => x.FKSiteID,
                        principalTable: "Site",
                        principalColumn: "SiteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Site",
                columns: new[] { "SiteID", "CreatedDateTime", "Name", "URL" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 31, 16, 41, 13, 611, DateTimeKind.Local).AddTicks(1731), "Google Co.", "www.google.com" },
                    { 2, new DateTime(2022, 1, 31, 16, 41, 13, 617, DateTimeKind.Local).AddTicks(1942), "Facebook Co.", "www.Facebook.com" },
                    { 3, new DateTime(2022, 1, 31, 16, 41, 13, 617, DateTimeKind.Local).AddTicks(2026), "Amazon Co.", "www.Amazon.com" },
                    { 4, new DateTime(2022, 1, 31, 16, 41, 13, 617, DateTimeKind.Local).AddTicks(2042), "MCI Co.", "www.MCI.com" },
                    { 5, new DateTime(2022, 1, 31, 16, 41, 13, 617, DateTimeKind.Local).AddTicks(2049), "Alexa Co.", "www.Alexa.com" },
                    { 6, new DateTime(2022, 1, 31, 16, 41, 13, 617, DateTimeKind.Local).AddTicks(2056), "Linkedin Co.", "www.Linkedin.com" },
                    { 7, new DateTime(2022, 1, 31, 16, 41, 13, 617, DateTimeKind.Local).AddTicks(2062), "Microsoft Co.", "www.Microsoft.com" },
                    { 8, new DateTime(2022, 1, 31, 16, 41, 13, 617, DateTimeKind.Local).AddTicks(2068), "Mozilla Co.", "www.Mozilla.com" },
                    { 9, new DateTime(2022, 1, 31, 16, 41, 13, 617, DateTimeKind.Local).AddTicks(2075), "Blizzard Co.", "www.Blizzard.com" },
                    { 10, new DateTime(2022, 1, 31, 16, 41, 13, 617, DateTimeKind.Local).AddTicks(2083), "Activision Co.", "www.Activision.com" }
                });

            migrationBuilder.InsertData(
                table: "Donate",
                columns: new[] { "DonateID", "DonatorName", "FKSiteID", "Value" },
                values: new object[,]
                {
                    { 1, "Feredrick B ", 1, 20m },
                    { 30, "George K Harris", 10, 50.5m },
                    { 29, "Joanna E Merritt", 10, 159m },
                    { 28, "Emily P Aultman", 7, 90m },
                    { 27, "Roderick B French", 7, 28m },
                    { 26, "Lisa H Dudley", 7, 22m },
                    { 25, "Joel A McDougal", 6, 66m },
                    { 24, "Keith J Spencer", 5, 44m },
                    { 23, "Sandra M Miles", 4, 19m },
                    { 22, "Walter C Wright", 4, 42m },
                    { 21, "Graham S Rhodes", 3, 48m },
                    { 20, "Todd L Rodriquez", 3, 36m },
                    { 19, "Ernest V Stocking", 3, 35m },
                    { 18, "Josephine M Delarosa", 2, 78m },
                    { 17, "Nickolas D Steiner", 2, 85m },
                    { 16, "Martha J Wright", 2, 85m },
                    { 15, "Mary R Delvalle", 2, 69m },
                    { 14, "Kam R Northington", 2, 52m },
                    { 13, "Dennis A Schultz", 2, 47m },
                    { 12, "Corey K Bryson", 2, 500m },
                    { 11, "Chris K Thomas", 2, 80m },
                    { 10, "Louis N Leon", 2, 30m },
                    { 9, "Monte L Mosher", 2, 60m },
                    { 8, "Zandra N Sweeney", 2, 70m },
                    { 7, "Grace R Square", 2, 50m },
                    { 6, "William P Young", 1, 10m },
                    { 5, "Matt S Moore", 1, 40m },
                    { 4, "Alma J Peterson", 1, 14.5m },
                    { 3, "Edwin E Walker", 1, 34m },
                    { 2, "Kristopher E Smith", 1, 20m },
                    { 31, "Bart T Aguilar", 10, 74m },
                    { 32, "Charles E Bowles", 10, 70m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donate_FKSiteID",
                table: "Donate",
                column: "FKSiteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donate");

            migrationBuilder.DropTable(
                name: "Site");
        }
    }
}

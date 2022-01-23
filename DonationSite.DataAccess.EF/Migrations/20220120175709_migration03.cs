using Microsoft.EntityFrameworkCore.Migrations;

namespace DonationSite.DataAccess.EF.Migrations
{
    public partial class migration03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donate_Seit_SitesSiteID",
                table: "Donate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seit",
                table: "Seit");

            migrationBuilder.RenameTable(
                name: "Seit",
                newName: "Site");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Site",
                table: "Site",
                column: "SiteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Donate_Site_SitesSiteID",
                table: "Donate",
                column: "SitesSiteID",
                principalTable: "Site",
                principalColumn: "SiteID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donate_Site_SitesSiteID",
                table: "Donate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Site",
                table: "Site");

            migrationBuilder.RenameTable(
                name: "Site",
                newName: "Seit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seit",
                table: "Seit",
                column: "SiteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Donate_Seit_SitesSiteID",
                table: "Donate",
                column: "SitesSiteID",
                principalTable: "Seit",
                principalColumn: "SiteID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DonationSite.DataAccess.EF.Migrations
{
    public partial class changefield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donate_Site_SitesSiteID",
                table: "Donate");

            migrationBuilder.DropIndex(
                name: "IX_Donate_SitesSiteID",
                table: "Donate");

            migrationBuilder.DropColumn(
                name: "SitesSiteID",
                table: "Donate");

            migrationBuilder.AlterColumn<string>(
                name: "URL",
                table: "Site",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Site",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Site",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 24, 1, 26, 9, 682, DateTimeKind.Local).AddTicks(7572),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "DonatorName",
                table: "Donate",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FKSiteID",
                table: "Donate",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Donate_FKSiteID",
                table: "Donate",
                column: "FKSiteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Donate_Site_FKSiteID",
                table: "Donate",
                column: "FKSiteID",
                principalTable: "Site",
                principalColumn: "SiteID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donate_Site_FKSiteID",
                table: "Donate");

            migrationBuilder.DropIndex(
                name: "IX_Donate_FKSiteID",
                table: "Donate");

            migrationBuilder.DropColumn(
                name: "FKSiteID",
                table: "Donate");

            migrationBuilder.AlterColumn<string>(
                name: "URL",
                table: "Site",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Site",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Site",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 1, 24, 1, 26, 9, 682, DateTimeKind.Local).AddTicks(7572));

            migrationBuilder.AlterColumn<string>(
                name: "DonatorName",
                table: "Donate",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "SitesSiteID",
                table: "Donate",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donate_SitesSiteID",
                table: "Donate",
                column: "SitesSiteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Donate_Site_SitesSiteID",
                table: "Donate",
                column: "SitesSiteID",
                principalTable: "Site",
                principalColumn: "SiteID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

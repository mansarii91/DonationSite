using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DonationSite.DataAccess.EF.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Site",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 24, 1, 33, 38, 716, DateTimeKind.Local).AddTicks(9970),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 1, 24, 1, 26, 9, 682, DateTimeKind.Local).AddTicks(7572));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Site",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 24, 1, 26, 9, 682, DateTimeKind.Local).AddTicks(7572),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 1, 24, 1, 33, 38, 716, DateTimeKind.Local).AddTicks(9970));
        }
    }
}

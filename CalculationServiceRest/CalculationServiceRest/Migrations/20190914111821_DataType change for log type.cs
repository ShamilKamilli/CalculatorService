using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CalculationServiceRest.Migrations
{
    public partial class DataTypechangeforlogtype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VALUE",
                table: "Logs",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "binary(50)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "VALUE",
                table: "Logs",
                type: "binary(50)",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}

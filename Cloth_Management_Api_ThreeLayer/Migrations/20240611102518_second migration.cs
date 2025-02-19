﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cloth_Management_Api_ThreeLayer.Migrations
{
    public partial class secondmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cloth_price",
                table: "StockTable",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "StockTable",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cloth_price",
                table: "StockTable");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "StockTable");
        }
    }
}

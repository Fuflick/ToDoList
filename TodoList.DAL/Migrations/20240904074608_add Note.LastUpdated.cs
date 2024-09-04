using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoList.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addNoteLastUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "Notes",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "Notes");
        }
    }
}

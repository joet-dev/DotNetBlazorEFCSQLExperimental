using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotNetBlazorEFCSQLExperimental.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Todo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Due = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Completed = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todo", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Todo",
                columns: new[] { "Id", "Completed", "Created", "Due", "Duration", "IsDone", "Note", "Priority", "Title" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 6, 19, 12, 18, 21, 704, DateTimeKind.Local).AddTicks(4358), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 60, false, null, 5, "Todo Example" },
                    { 2, null, new DateTime(2023, 6, 19, 12, 18, 21, 704, DateTimeKind.Local).AddTicks(4364), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2400, false, null, 2, "Todo Example 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todo");
        }
    }
}

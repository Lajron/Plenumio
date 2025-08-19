using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Plenumio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateTagTableAndSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayedName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCanonical = table.Column<bool>(type: "bit", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_Tags_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "DisplayedName", "IsCanonical", "Name", "ParentId", "createdAt" },
                values: new object[,]
                {
                    { 1, "Technology", true, "technology", null, new DateTime(2025, 8, 19, 23, 43, 31, 328, DateTimeKind.Utc).AddTicks(5306) },
                    { 2, "Life", true, "life", null, new DateTime(2025, 8, 19, 23, 43, 31, 328, DateTimeKind.Utc).AddTicks(5309) },
                    { 3, "Science", true, "science", null, new DateTime(2025, 8, 19, 23, 43, 31, 328, DateTimeKind.Utc).AddTicks(5311) },
                    { 4, "Art", true, "art", null, new DateTime(2025, 8, 19, 23, 43, 31, 328, DateTimeKind.Utc).AddTicks(5312) },
                    { 5, "Gaming", true, "gaming", null, new DateTime(2025, 8, 19, 23, 43, 31, 328, DateTimeKind.Utc).AddTicks(5314) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ParentId",
                table: "Tags",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}

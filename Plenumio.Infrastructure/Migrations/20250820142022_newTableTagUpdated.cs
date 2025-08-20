using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Plenumio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newTableTagUpdated : Migration
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
                    Type = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                columns: new[] { "Id", "CreatedAt", "DisplayedName", "IsDeleted", "Name", "ParentId", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 8, 20, 14, 20, 21, 139, DateTimeKind.Unspecified).AddTicks(9457), new TimeSpan(0, 0, 0, 0, 0)), "Technology", false, "technology", null, 0, new DateTimeOffset(new DateTime(2025, 8, 20, 14, 20, 21, 139, DateTimeKind.Unspecified).AddTicks(9458), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2025, 8, 20, 14, 20, 21, 139, DateTimeKind.Unspecified).AddTicks(9461), new TimeSpan(0, 0, 0, 0, 0)), "Life", false, "life", null, 0, new DateTimeOffset(new DateTime(2025, 8, 20, 14, 20, 21, 139, DateTimeKind.Unspecified).AddTicks(9461), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2025, 8, 20, 14, 20, 21, 139, DateTimeKind.Unspecified).AddTicks(9464), new TimeSpan(0, 0, 0, 0, 0)), "Science", false, "science", null, 0, new DateTimeOffset(new DateTime(2025, 8, 20, 14, 20, 21, 139, DateTimeKind.Unspecified).AddTicks(9464), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 4, new DateTimeOffset(new DateTime(2025, 8, 20, 14, 20, 21, 139, DateTimeKind.Unspecified).AddTicks(9467), new TimeSpan(0, 0, 0, 0, 0)), "Art", false, "art", null, 0, new DateTimeOffset(new DateTime(2025, 8, 20, 14, 20, 21, 139, DateTimeKind.Unspecified).AddTicks(9467), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 5, new DateTimeOffset(new DateTime(2025, 8, 20, 14, 20, 21, 139, DateTimeKind.Unspecified).AddTicks(9469), new TimeSpan(0, 0, 0, 0, 0)), "Gaming", false, "gaming", null, 0, new DateTimeOffset(new DateTime(2025, 8, 20, 14, 20, 21, 139, DateTimeKind.Unspecified).AddTicks(9470), new TimeSpan(0, 0, 0, 0, 0)) }
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

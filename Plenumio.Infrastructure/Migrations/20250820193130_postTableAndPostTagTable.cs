using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plenumio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class postTableAndPostTagTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrivacyType = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostTag",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTag", x => new { x.PostId, x.TagId });
                    table.ForeignKey(
                        name: "FK_PostTag_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTag_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 8, 20, 19, 31, 29, 281, DateTimeKind.Unspecified).AddTicks(6379), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 8, 20, 19, 31, 29, 281, DateTimeKind.Unspecified).AddTicks(6380), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 8, 20, 19, 31, 29, 281, DateTimeKind.Unspecified).AddTicks(6384), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 8, 20, 19, 31, 29, 281, DateTimeKind.Unspecified).AddTicks(6384), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 8, 20, 19, 31, 29, 281, DateTimeKind.Unspecified).AddTicks(6387), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 8, 20, 19, 31, 29, 281, DateTimeKind.Unspecified).AddTicks(6388), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 8, 20, 19, 31, 29, 281, DateTimeKind.Unspecified).AddTicks(6390), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 8, 20, 19, 31, 29, 281, DateTimeKind.Unspecified).AddTicks(6391), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 8, 20, 19, 31, 29, 281, DateTimeKind.Unspecified).AddTicks(6394), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 8, 20, 19, 31, 29, 281, DateTimeKind.Unspecified).AddTicks(6394), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_PostTag_TagId",
                table: "PostTag",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostTag");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 8, 20, 14, 20, 21, 139, DateTimeKind.Unspecified).AddTicks(9457), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 8, 20, 14, 20, 21, 139, DateTimeKind.Unspecified).AddTicks(9458), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 8, 20, 14, 20, 21, 139, DateTimeKind.Unspecified).AddTicks(9461), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 8, 20, 14, 20, 21, 139, DateTimeKind.Unspecified).AddTicks(9461), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 8, 20, 14, 20, 21, 139, DateTimeKind.Unspecified).AddTicks(9464), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 8, 20, 14, 20, 21, 139, DateTimeKind.Unspecified).AddTicks(9464), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 8, 20, 14, 20, 21, 139, DateTimeKind.Unspecified).AddTicks(9467), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 8, 20, 14, 20, 21, 139, DateTimeKind.Unspecified).AddTicks(9467), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 8, 20, 14, 20, 21, 139, DateTimeKind.Unspecified).AddTicks(9469), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 8, 20, 14, 20, 21, 139, DateTimeKind.Unspecified).AddTicks(9470), new TimeSpan(0, 0, 0, 0, 0)) });
        }
    }
}

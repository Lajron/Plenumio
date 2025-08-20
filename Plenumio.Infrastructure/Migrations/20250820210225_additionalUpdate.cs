using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plenumio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class additionalUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTag_Post_PostId",
                table: "PostTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post",
                table: "Post");

            migrationBuilder.RenameTable(
                name: "Post",
                newName: "Posts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 8, 20, 21, 2, 24, 700, DateTimeKind.Unspecified).AddTicks(5766), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 8, 20, 21, 2, 24, 700, DateTimeKind.Unspecified).AddTicks(5767), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 8, 20, 21, 2, 24, 700, DateTimeKind.Unspecified).AddTicks(5294), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 8, 20, 21, 2, 24, 700, DateTimeKind.Unspecified).AddTicks(5295), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 8, 20, 21, 2, 24, 700, DateTimeKind.Unspecified).AddTicks(5298), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 8, 20, 21, 2, 24, 700, DateTimeKind.Unspecified).AddTicks(5299), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 8, 20, 21, 2, 24, 700, DateTimeKind.Unspecified).AddTicks(5302), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 8, 20, 21, 2, 24, 700, DateTimeKind.Unspecified).AddTicks(5303), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 8, 20, 21, 2, 24, 700, DateTimeKind.Unspecified).AddTicks(5431), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 8, 20, 21, 2, 24, 700, DateTimeKind.Unspecified).AddTicks(5432), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 8, 20, 21, 2, 24, 700, DateTimeKind.Unspecified).AddTicks(5435), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 8, 20, 21, 2, 24, 700, DateTimeKind.Unspecified).AddTicks(5436), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.AddForeignKey(
                name: "FK_PostTag_Posts_PostId",
                table: "PostTag",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTag_Posts_PostId",
                table: "PostTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "Post");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post",
                table: "Post",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 8, 20, 19, 45, 55, 802, DateTimeKind.Unspecified).AddTicks(4172), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 8, 20, 19, 45, 55, 802, DateTimeKind.Unspecified).AddTicks(4173), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 8, 20, 19, 45, 55, 802, DateTimeKind.Unspecified).AddTicks(3862), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 8, 20, 19, 45, 55, 802, DateTimeKind.Unspecified).AddTicks(3862), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 8, 20, 19, 45, 55, 802, DateTimeKind.Unspecified).AddTicks(3866), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 8, 20, 19, 45, 55, 802, DateTimeKind.Unspecified).AddTicks(3866), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 8, 20, 19, 45, 55, 802, DateTimeKind.Unspecified).AddTicks(3869), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 8, 20, 19, 45, 55, 802, DateTimeKind.Unspecified).AddTicks(3869), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 8, 20, 19, 45, 55, 802, DateTimeKind.Unspecified).AddTicks(3872), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 8, 20, 19, 45, 55, 802, DateTimeKind.Unspecified).AddTicks(3873), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 8, 20, 19, 45, 55, 802, DateTimeKind.Unspecified).AddTicks(3875), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 8, 20, 19, 45, 55, 802, DateTimeKind.Unspecified).AddTicks(3876), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.AddForeignKey(
                name: "FK_PostTag_Post_PostId",
                table: "PostTag",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Plenumio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class firstPostTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "CreatedAt", "Description", "IsDeleted", "PrivacyType", "Slug", "UpdatedAt" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2025, 8, 20, 19, 45, 55, 802, DateTimeKind.Unspecified).AddTicks(4172), new TimeSpan(0, 0, 0, 0, 0)), "Ovo je moj prvi post na Plenumio-u! Veoma sam uzbuđen što sam ovde.", false, 0, "prvi-post-na-plenumio", new DateTimeOffset(new DateTime(2025, 8, 20, 19, 45, 55, 802, DateTimeKind.Unspecified).AddTicks(4173), new TimeSpan(0, 0, 0, 0, 0)) });

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

            migrationBuilder.InsertData(
                table: "PostTag",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PostTag",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PostTag",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "PostTag",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 1);

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
        }
    }
}

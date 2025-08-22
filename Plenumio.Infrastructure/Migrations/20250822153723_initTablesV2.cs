using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plenumio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initTablesV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Test",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 8, 22, 15, 37, 22, 90, DateTimeKind.Unspecified).AddTicks(6940), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 8, 22, 15, 37, 22, 90, DateTimeKind.Unspecified).AddTicks(6941), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 8, 22, 15, 37, 22, 90, DateTimeKind.Unspecified).AddTicks(6944), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 8, 22, 15, 37, 22, 90, DateTimeKind.Unspecified).AddTicks(6945), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 8, 22, 15, 37, 22, 90, DateTimeKind.Unspecified).AddTicks(6948), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 8, 22, 15, 37, 22, 90, DateTimeKind.Unspecified).AddTicks(6948), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 8, 22, 15, 37, 22, 90, DateTimeKind.Unspecified).AddTicks(6951), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 8, 22, 15, 37, 22, 90, DateTimeKind.Unspecified).AddTicks(6951), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 8, 22, 15, 37, 22, 90, DateTimeKind.Unspecified).AddTicks(6954), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 8, 22, 15, 37, 22, 90, DateTimeKind.Unspecified).AddTicks(6954), new TimeSpan(0, 0, 0, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Test",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreatedAt", "Description", "IsDeleted", "PrivacyType", "Slug", "UpdatedAt" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2025, 8, 22, 15, 3, 50, 118, DateTimeKind.Unspecified).AddTicks(5277), new TimeSpan(0, 0, 0, 0, 0)), "Ovo je moj prvi post na Plenumio-u! Veoma sam uzbuđen što sam ovde.", false, 0, "prvi-post-na-plenumio", new DateTimeOffset(new DateTime(2025, 8, 22, 15, 3, 50, 118, DateTimeKind.Unspecified).AddTicks(5277), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 8, 22, 15, 3, 50, 118, DateTimeKind.Unspecified).AddTicks(4979), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 8, 22, 15, 3, 50, 118, DateTimeKind.Unspecified).AddTicks(4980), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 8, 22, 15, 3, 50, 118, DateTimeKind.Unspecified).AddTicks(4983), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 8, 22, 15, 3, 50, 118, DateTimeKind.Unspecified).AddTicks(4983), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 8, 22, 15, 3, 50, 118, DateTimeKind.Unspecified).AddTicks(4986), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 8, 22, 15, 3, 50, 118, DateTimeKind.Unspecified).AddTicks(4987), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 8, 22, 15, 3, 50, 118, DateTimeKind.Unspecified).AddTicks(4989), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 8, 22, 15, 3, 50, 118, DateTimeKind.Unspecified).AddTicks(4990), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 8, 22, 15, 3, 50, 118, DateTimeKind.Unspecified).AddTicks(4992), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 8, 22, 15, 3, 50, 118, DateTimeKind.Unspecified).AddTicks(4993), new TimeSpan(0, 0, 0, 0, 0)) });
        }
    }
}

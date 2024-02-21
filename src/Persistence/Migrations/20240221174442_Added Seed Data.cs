using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserAccounts",
                columns: new[] { "Id", "Balance", "Currency" },
                values: new object[,]
                {
                    { new Guid("6751304e-0eea-443c-ad6a-dfbbf53731fe"), 700.0, "AED" },
                    { new Guid("b136cf3d-766b-45ae-aa84-ac7f10c5a090"), 5000.0, "AED" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: new Guid("6751304e-0eea-443c-ad6a-dfbbf53731fe"));

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: new Guid("b136cf3d-766b-45ae-aa84-ac7f10c5a090"));
        }
    }
}

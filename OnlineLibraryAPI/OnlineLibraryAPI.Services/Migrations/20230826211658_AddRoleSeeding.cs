using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineLibraryAPI.Services.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4832250f-0b8e-4675-bba6-9badc22de7c9"), "Admin" },
                    { new Guid("5ff13486-f325-40a6-a41c-555259379dfb"), "SuperManager" },
                    { new Guid("6bfd5453-fb0e-435c-bf54-638e994bdaf5"), "Manager" },
                    { new Guid("73859e47-aa89-43ee-aada-f9794040cacf"), "User" },
                    { new Guid("af485b12-a0e4-4c45-89e8-4110f340160f"), "Root" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4832250f-0b8e-4675-bba6-9badc22de7c9"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5ff13486-f325-40a6-a41c-555259379dfb"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6bfd5453-fb0e-435c-bf54-638e994bdaf5"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("73859e47-aa89-43ee-aada-f9794040cacf"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("af485b12-a0e4-4c45-89e8-4110f340160f"));
        }
    }
}

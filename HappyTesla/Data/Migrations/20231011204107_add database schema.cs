using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HappyTesla.Data.Migrations
{
    /// <inheritdoc />
    public partial class adddatabaseschema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Country = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Adress = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LocationId = table.Column<int>(type: "INTEGER", nullable: false),
                    CarId = table.Column<int>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cbf3e9c9-40bc-451a-86e2-9fde61e88627", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d05ff009-f6ae-4355-8d55-823c0f43c635", 0, "41cef9ea-89ec-4b4e-bba1-a92bc2b9da81", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEB1yf/WTsSmemU2ASov5Cc473nf4bLzpc2JnwAGG4SD7tf0PImrv4ULyOYKDA96RYg==", null, false, "dac3c781-b04d-4938-8453-e27b23cdd381", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Color", "Model", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Black", "Model S Plaid", "Tesla", 89.99m },
                    { 2, "Black", "Model S", "Tesla", 74.99m },
                    { 3, "Red", "Model 3 Performance", "Tesla", 50.99m },
                    { 4, "Red", "Model 3 Long Range", "Tesla", 45.99m },
                    { 5, "Red", "Model 3 Rear-Wheel Drive", "Tesla", 38.99m },
                    { 6, "White", "Model X Plaid", "Tesla", 89.99m },
                    { 7, "White", "Model X", "Tesla", 79.99m },
                    { 8, "Blue", "Model Y Performance", "Tesla", 52.49m },
                    { 9, "Blue", "Model Y Long Range", "Tesla", 48.49m },
                    { 10, "Blue", "Model Y Rear-Wheel Drive", "Tesla", 43.99m }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Adress", "City", "Country" },
                values: new object[,]
                {
                    { 1, "Palma Airport", "Palma de Mallorca", "Spain" },
                    { 2, "Palma City Center", "Palma de Mallorca", "Spain" },
                    { 3, "Alcúdia", "Alcúdia", "Spain" },
                    { 4, "Manacor", "Manacor", "Spain" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cbf3e9c9-40bc-451a-86e2-9fde61e88627", "d05ff009-f6ae-4355-8d55-823c0f43c635" });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CarId",
                table: "Reservations",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_LocationId",
                table: "Reservations",
                column: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cbf3e9c9-40bc-451a-86e2-9fde61e88627", "d05ff009-f6ae-4355-8d55-823c0f43c635" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbf3e9c9-40bc-451a-86e2-9fde61e88627");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d05ff009-f6ae-4355-8d55-823c0f43c635");
        }
    }
}

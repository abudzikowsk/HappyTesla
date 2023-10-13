using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyTesla.Data.Migrations
{
    /// <inheritdoc />
    public partial class addendLocationtoreservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Locations_LocationId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Reservations",
                newName: "StartLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_LocationId",
                table: "Reservations",
                newName: "IX_Reservations_StartLocationId");

            migrationBuilder.AddColumn<int>(
                name: "EndLocationId",
                table: "Reservations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id", 
                keyValue: "d05ff009-f6ae-4355-8d55-823c0f43c635",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9b38a99d-0b16-4081-bc61-3bd478c4b206", "431ff965-8e75-447f-ade5-adb1fae63dc7" });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_EndLocationId",
                table: "Reservations",
                column: "EndLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Locations_EndLocationId",
                table: "Reservations",
                column: "EndLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Locations_StartLocationId",
                table: "Reservations",
                column: "StartLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Locations_EndLocationId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Locations_StartLocationId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_EndLocationId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "EndLocationId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "StartLocationId",
                table: "Reservations",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_StartLocationId",
                table: "Reservations",
                newName: "IX_Reservations_LocationId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d05ff009-f6ae-4355-8d55-823c0f43c635",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "41cef9ea-89ec-4b4e-bba1-a92bc2b9da81", "dac3c781-b04d-4938-8453-e27b23cdd381" });

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Locations_LocationId",
                table: "Reservations",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

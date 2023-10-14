using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyTesla.Data.Migrations
{
    /// <inheritdoc />
    public partial class namechangeforaddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Locations",
                newName: "Address");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d05ff009-f6ae-4355-8d55-823c0f43c635",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8926cd0f-bb8a-4942-801b-539e54634e01", "4b5a8341-9c5f-42c1-9e52-321ac543007a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Locations",
                newName: "Adress");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d05ff009-f6ae-4355-8d55-823c0f43c635",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9b38a99d-0b16-4081-bc61-3bd478c4b206", "431ff965-8e75-447f-ade5-adb1fae63dc7" });
        }
    }
}

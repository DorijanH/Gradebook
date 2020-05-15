using Microsoft.EntityFrameworkCore.Migrations;

namespace GradebookSqlServerDAL.Migrations
{
    public partial class AddedUlogaSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Uloga",
                columns: new[] { "IdUloga", "NazivUloga" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Nastavnik" },
                    { 3, "Razrednik" },
                    { 4, "Učenik" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Uloga",
                keyColumn: "IdUloga",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Uloga",
                keyColumn: "IdUloga",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Uloga",
                keyColumn: "IdUloga",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Uloga",
                keyColumn: "IdUloga",
                keyValue: 4);
        }
    }
}

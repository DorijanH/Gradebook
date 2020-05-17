using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GradebookSqlServerDAL.Migrations
{
    public partial class AddedSeedDataForAlmostAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrojGodine",
                table: "GodinaRazreda");

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Provjera",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Datum",
                table: "Provjera",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Godina",
                table: "GodinaRazreda",
                nullable: true);

            migrationBuilder.InsertData(
                table: "GodinaRazreda",
                columns: new[] { "IdGodRazreda", "Godina" },
                values: new object[,]
                {
                    { 1, "1" },
                    { 2, "2" },
                    { 3, "3" },
                    { 4, "4" }
                });

            migrationBuilder.InsertData(
                table: "KriterijOcjenjivanja",
                columns: new[] { "IdKriterij", "Kriterij1", "Kriterij2", "Kriterij3", "Kriterij4" },
                values: new object[,]
                {
                    { 1, "Teorija", "Zadaci", "Zadaća", "Labosi" },
                    { 2, "Aktivnost", "Zalaganje", "Prisutnost", "Seminar" },
                    { 3, "Praksa", "Usmeno", null, null }
                });

            migrationBuilder.InsertData(
                table: "Predmet",
                columns: new[] { "IdPredmet", "GodinaRazreda", "Naziv", "Opis" },
                values: new object[,]
                {
                    { 1, 1, "Matematika 1", "Opis nastavnog plana i programa" },
                    { 16, 4, "Geografija 4", "Opis nastavnog plana i programa" },
                    { 12, 4, "Biologija 4", "Opis nastavnog plana i programa" },
                    { 8, 4, "Povijest 4", "Opis nastavnog plana i programa" },
                    { 4, 4, "Matematika 4", "Opis nastavnog plana i programa" },
                    { 23, 3, "Fizika 3", "Opis nastavnog plana i programa" },
                    { 19, 3, "Logika 3", "Opis nastavnog plana i programa" },
                    { 18, 3, "Psihologija 3", "Opis nastavnog plana i programa" },
                    { 15, 3, "Geografija 3", "Opis nastavnog plana i programa" },
                    { 11, 3, "Biologija 3", "Opis nastavnog plana i programa" },
                    { 7, 3, "Povijest 3", "Opis nastavnog plana i programa" },
                    { 3, 3, "Matematika 3", "Opis nastavnog plana i programa" },
                    { 22, 2, "Fizika 2", "Opis nastavnog plana i programa" },
                    { 17, 2, "Psihologija 2", "Opis nastavnog plana i programa" },
                    { 14, 2, "Geografija 2", "Opis nastavnog plana i programa" },
                    { 10, 2, "Biologija 2", "Opis nastavnog plana i programa" },
                    { 6, 2, "Povijest 2", "Opis nastavnog plana i programa" },
                    { 2, 2, "Matematika 2", "Opis nastavnog plana i programa" },
                    { 21, 1, "Fizika 1", "Opis nastavnog plana i programa" },
                    { 13, 1, "Geografija 1", "Opis nastavnog plana i programa" },
                    { 9, 1, "Biologija 1", "Opis nastavnog plana i programa" },
                    { 5, 1, "Povijest 1", "Opis nastavnog plana i programa" },
                    { 20, 4, "Filozofija 4", "Opis nastavnog plana i programa" },
                    { 24, 4, "Fizika 4", "Opis nastavnog plana i programa" }
                });

            migrationBuilder.InsertData(
                table: "Provjera",
                columns: new[] { "IdProvjera", "Datum", "IdPredmet", "Naziv", "Opis" },
                values: new object[] { 1, new DateTime(2020, 5, 28, 13, 30, 0, 0, DateTimeKind.Unspecified), 1, "Kvadratne jednadžbe", "U provjeri ćemo provjeravati znanje kvadratnih jednadžbi. Provjera će se sastojati od 10 zadataka i nositi 50 bodova" });

            migrationBuilder.InsertData(
                table: "Provjera",
                columns: new[] { "IdProvjera", "Datum", "IdPredmet", "Naziv", "Opis" },
                values: new object[] { 3, new DateTime(2020, 5, 24, 8, 30, 0, 0, DateTimeKind.Unspecified), 5, "Drevni Egipat", "Pišemo provjeru iz cjelokupnog gradiva koji se odnosi na stari Egipat." });

            migrationBuilder.InsertData(
                table: "Provjera",
                columns: new[] { "IdProvjera", "Datum", "IdPredmet", "Naziv", "Opis" },
                values: new object[] { 2, new DateTime(2020, 5, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), 23, "Njihala, valovi i zvuk", "Pisat ćemo sve što smo radili o njihalima, valovima i zvukovima. Uključujući i Dopplerov učinak. Sretno svima!" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "KriterijOcjenjivanja",
                keyColumn: "IdKriterij",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "KriterijOcjenjivanja",
                keyColumn: "IdKriterij",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "KriterijOcjenjivanja",
                keyColumn: "IdKriterij",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Predmet",
                keyColumn: "IdPredmet",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Predmet",
                keyColumn: "IdPredmet",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Predmet",
                keyColumn: "IdPredmet",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Predmet",
                keyColumn: "IdPredmet",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Predmet",
                keyColumn: "IdPredmet",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Predmet",
                keyColumn: "IdPredmet",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Predmet",
                keyColumn: "IdPredmet",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Predmet",
                keyColumn: "IdPredmet",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Predmet",
                keyColumn: "IdPredmet",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Predmet",
                keyColumn: "IdPredmet",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Predmet",
                keyColumn: "IdPredmet",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Predmet",
                keyColumn: "IdPredmet",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Predmet",
                keyColumn: "IdPredmet",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Predmet",
                keyColumn: "IdPredmet",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Predmet",
                keyColumn: "IdPredmet",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Predmet",
                keyColumn: "IdPredmet",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Predmet",
                keyColumn: "IdPredmet",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Predmet",
                keyColumn: "IdPredmet",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Predmet",
                keyColumn: "IdPredmet",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Predmet",
                keyColumn: "IdPredmet",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Predmet",
                keyColumn: "IdPredmet",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Provjera",
                keyColumn: "IdProvjera",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Provjera",
                keyColumn: "IdProvjera",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Provjera",
                keyColumn: "IdProvjera",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GodinaRazreda",
                keyColumn: "IdGodRazreda",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GodinaRazreda",
                keyColumn: "IdGodRazreda",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Predmet",
                keyColumn: "IdPredmet",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Predmet",
                keyColumn: "IdPredmet",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Predmet",
                keyColumn: "IdPredmet",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "GodinaRazreda",
                keyColumn: "IdGodRazreda",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GodinaRazreda",
                keyColumn: "IdGodRazreda",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Godina",
                table: "GodinaRazreda");

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Provjera",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Datum",
                table: "Provjera",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<short>(
                name: "BrojGodine",
                table: "GodinaRazreda",
                type: "smallint",
                nullable: true);
        }
    }
}

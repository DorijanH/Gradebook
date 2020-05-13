using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GradebookSqlServerDAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GodinaRazreda",
                columns: table => new
                {
                    IdGodRazreda = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojGodine = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__GodinaRa__934B60D72E70C534", x => x.IdGodRazreda);
                });

            migrationBuilder.CreateTable(
                name: "KriterijOcjenjivanja",
                columns: table => new
                {
                    IdKriterij = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kriterij1 = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Kriterij2 = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Kriterij3 = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Kriterij4 = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Kriterij__8E19A28AE229E69B", x => x.IdKriterij);
                });

            migrationBuilder.CreateTable(
                name: "Uloga",
                columns: table => new
                {
                    IdUloga = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivUloga = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Uloga__D87E58942704DEB0", x => x.IdUloga);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Predmet",
                columns: table => new
                {
                    IdPredmet = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Opis = table.Column<string>(unicode: false, nullable: true),
                    GodinaRazreda = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Predmet__0D27FFBA207D6AC8", x => x.IdPredmet);
                    table.ForeignKey(
                        name: "FK__Predmet__GodinaR__5AEE82B9",
                        column: x => x.GodinaRazreda,
                        principalTable: "GodinaRazreda",
                        principalColumn: "IdGodRazreda",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Provjera",
                columns: table => new
                {
                    IdProvjera = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Opis = table.Column<string>(unicode: false, nullable: true),
                    Datum = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdPredmet = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Provjera__157DDFD44CCE7E78", x => x.IdProvjera);
                    table.ForeignKey(
                        name: "FK__Provjera__IdPred__5DCAEF64",
                        column: x => x.IdPredmet,
                        principalTable: "Predmet",
                        principalColumn: "IdPredmet",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    IdKorisnik = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Prezime = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Spol = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    EmailAdresa = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    DatumRođenja = table.Column<DateTime>(unicode: false, maxLength: 50, nullable: false),
                    IdRazred = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Korisnik__58FE570EEAF3FFC1", x => x.IdKorisnik);
                    table.ForeignKey(
                        name: "FK_Korisnik_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bilješka",
                columns: table => new
                {
                    IdBilješka = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opis = table.Column<string>(unicode: false, nullable: true),
                    Datum = table.Column<DateTime>(type: "datetime", nullable: true),
                    ZabilježioKorisnik = table.Column<int>(nullable: false),
                    IdUčenik = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Bilješka__516F1AAA586134E9", x => x.IdBilješka);
                    table.ForeignKey(
                        name: "FK__Bilješka__IdUčen__5812160E",
                        column: x => x.IdUčenik,
                        principalTable: "Korisnik",
                        principalColumn: "IdKorisnik",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Bilješka__Zabilj__571DF1D5",
                        column: x => x.ZabilježioKorisnik,
                        principalTable: "Korisnik",
                        principalColumn: "IdKorisnik",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KorisnikUloga",
                columns: table => new
                {
                    IdKorisnik = table.Column<int>(nullable: false),
                    IdUloga = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnikUloga", x => new { x.IdKorisnik, x.IdUloga });
                    table.ForeignKey(
                        name: "FK__KorisnikU__IdKor__534D60F1",
                        column: x => x.IdKorisnik,
                        principalTable: "Korisnik",
                        principalColumn: "IdKorisnik",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__KorisnikU__IdUlo__5441852A",
                        column: x => x.IdUloga,
                        principalTable: "Uloga",
                        principalColumn: "IdUloga",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NastavnikPredaje",
                columns: table => new
                {
                    IdNastavnik = table.Column<int>(nullable: false),
                    IdPredmet = table.Column<int>(nullable: false),
                    IdKriterij = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NastavnikPredaje", x => new { x.IdNastavnik, x.IdPredmet, x.IdKriterij });
                    table.ForeignKey(
                        name: "FK__Nastavnik__IdKri__68487DD7",
                        column: x => x.IdKriterij,
                        principalTable: "KriterijOcjenjivanja",
                        principalColumn: "IdKriterij",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Nastavnik__IdNas__66603565",
                        column: x => x.IdNastavnik,
                        principalTable: "Korisnik",
                        principalColumn: "IdKorisnik",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Nastavnik__IdPre__6754599E",
                        column: x => x.IdPredmet,
                        principalTable: "Predmet",
                        principalColumn: "IdPredmet",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ocjena",
                columns: table => new
                {
                    IdOcjena = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bilješka = table.Column<string>(unicode: false, nullable: true),
                    OstvareniBodovi = table.Column<int>(nullable: true),
                    Ocjena = table.Column<int>(nullable: false),
                    IdProvjera = table.Column<int>(nullable: false),
                    IdUčenik = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ocjena__B11E3475EE439EA7", x => x.IdOcjena);
                    table.ForeignKey(
                        name: "FK__Ocjena__IdProvje__60A75C0F",
                        column: x => x.IdProvjera,
                        principalTable: "Provjera",
                        principalColumn: "IdProvjera",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Ocjena__IdUčenik__619B8048",
                        column: x => x.IdUčenik,
                        principalTable: "Korisnik",
                        principalColumn: "IdKorisnik",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Razred",
                columns: table => new
                {
                    IdRazred = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KraticaOdjel = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    IdRazrednik = table.Column<int>(nullable: false),
                    GodinaRazreda = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Razred__09B6F50C180414F8", x => x.IdRazred);
                    table.ForeignKey(
                        name: "FK__Razred__GodinaRa__4D94879B",
                        column: x => x.GodinaRazreda,
                        principalTable: "GodinaRazreda",
                        principalColumn: "IdGodRazreda",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Razred_Razrednik",
                        column: x => x.IdRazrednik,
                        principalTable: "Korisnik",
                        principalColumn: "IdKorisnik",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bilješka_IdUčenik",
                table: "Bilješka",
                column: "IdUčenik");

            migrationBuilder.CreateIndex(
                name: "IX_Bilješka_ZabilježioKorisnik",
                table: "Bilješka",
                column: "ZabilježioKorisnik");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_IdRazred",
                table: "Korisnik",
                column: "IdRazred");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_UserId",
                table: "Korisnik",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikUloga_IdUloga",
                table: "KorisnikUloga",
                column: "IdUloga");

            migrationBuilder.CreateIndex(
                name: "IX_NastavnikPredaje_IdKriterij",
                table: "NastavnikPredaje",
                column: "IdKriterij");

            migrationBuilder.CreateIndex(
                name: "IX_NastavnikPredaje_IdPredmet",
                table: "NastavnikPredaje",
                column: "IdPredmet");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjena_IdProvjera",
                table: "Ocjena",
                column: "IdProvjera");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjena_IdUčenik",
                table: "Ocjena",
                column: "IdUčenik");

            migrationBuilder.CreateIndex(
                name: "IX_Predmet_GodinaRazreda",
                table: "Predmet",
                column: "GodinaRazreda");

            migrationBuilder.CreateIndex(
                name: "IX_Provjera_IdPredmet",
                table: "Provjera",
                column: "IdPredmet");

            migrationBuilder.CreateIndex(
                name: "IX_Razred_GodinaRazreda",
                table: "Razred",
                column: "GodinaRazreda");

            migrationBuilder.CreateIndex(
                name: "IX_Razred_IdRazrednik",
                table: "Razred",
                column: "IdRazrednik");

            migrationBuilder.AddForeignKey(
                name: "FK__Korisnik__IdRazr__5070F446",
                table: "Korisnik",
                column: "IdRazred",
                principalTable: "Razred",
                principalColumn: "IdRazred",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Korisnik_AspNetUsers_UserId",
                table: "Korisnik");

            migrationBuilder.DropForeignKey(
                name: "FK_Razred_Razrednik",
                table: "Razred");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bilješka");

            migrationBuilder.DropTable(
                name: "KorisnikUloga");

            migrationBuilder.DropTable(
                name: "NastavnikPredaje");

            migrationBuilder.DropTable(
                name: "Ocjena");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Uloga");

            migrationBuilder.DropTable(
                name: "KriterijOcjenjivanja");

            migrationBuilder.DropTable(
                name: "Provjera");

            migrationBuilder.DropTable(
                name: "Predmet");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Razred");

            migrationBuilder.DropTable(
                name: "GodinaRazreda");
        }
    }
}

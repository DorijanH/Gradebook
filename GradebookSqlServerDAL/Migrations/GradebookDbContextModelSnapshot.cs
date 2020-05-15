﻿// <auto-generated />
using System;
using GradebookSqlServerDAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GradebookSqlServerDAL.Migrations
{
    [DbContext(typeof(GradebookDbContext))]
    partial class GradebookDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GradebookBLL.DomainModels.Bilješka", b =>
                {
                    b.Property<int>("IdBilješka")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Datum")
                        .HasColumnType("datetime");

                    b.Property<int>("IdUčenik")
                        .HasColumnType("int");

                    b.Property<string>("Opis")
                        .HasColumnType("varchar(max)")
                        .IsUnicode(false);

                    b.Property<int>("ZabilježioKorisnik")
                        .HasColumnType("int");

                    b.HasKey("IdBilješka")
                        .HasName("PK__Bilješka__516F1AAA586134E9");

                    b.HasIndex("IdUčenik");

                    b.HasIndex("ZabilježioKorisnik");

                    b.ToTable("Bilješka");
                });

            modelBuilder.Entity("GradebookBLL.DomainModels.GodinaRazreda", b =>
                {
                    b.Property<int>("IdGodRazreda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short?>("BrojGodine")
                        .HasColumnType("smallint");

                    b.HasKey("IdGodRazreda")
                        .HasName("PK__GodinaRa__934B60D72E70C534");

                    b.ToTable("GodinaRazreda");
                });

            modelBuilder.Entity("GradebookBLL.DomainModels.Korisnik", b =>
                {
                    b.Property<int>("IdKorisnik")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumRođenja")
                        .HasColumnType("datetime2")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("EmailAdresa")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int?>("IdRazred")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Prezime")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Spol")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdKorisnik")
                        .HasName("PK__Korisnik__58FE570EEAF3FFC1");

                    b.HasIndex("IdRazred");

                    b.HasIndex("UserId");

                    b.ToTable("Korisnik");
                });

            modelBuilder.Entity("GradebookBLL.DomainModels.KorisnikUloga", b =>
                {
                    b.Property<int>("IdKorisnik")
                        .HasColumnType("int");

                    b.Property<int>("IdUloga")
                        .HasColumnType("int");

                    b.HasKey("IdKorisnik", "IdUloga");

                    b.HasIndex("IdUloga");

                    b.ToTable("KorisnikUloga");
                });

            modelBuilder.Entity("GradebookBLL.DomainModels.KriterijOcjenjivanja", b =>
                {
                    b.Property<int>("IdKriterij")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Kriterij1")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Kriterij2")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Kriterij3")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Kriterij4")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("IdKriterij")
                        .HasName("PK__Kriterij__8E19A28AE229E69B");

                    b.ToTable("KriterijOcjenjivanja");
                });

            modelBuilder.Entity("GradebookBLL.DomainModels.NastavnikPredaje", b =>
                {
                    b.Property<int>("IdNastavnik")
                        .HasColumnType("int");

                    b.Property<int>("IdPredmet")
                        .HasColumnType("int");

                    b.Property<int>("IdKriterij")
                        .HasColumnType("int");

                    b.HasKey("IdNastavnik", "IdPredmet", "IdKriterij");

                    b.HasIndex("IdKriterij");

                    b.HasIndex("IdPredmet");

                    b.ToTable("NastavnikPredaje");
                });

            modelBuilder.Entity("GradebookBLL.DomainModels.Ocjena", b =>
                {
                    b.Property<int>("IdOcjena")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bilješka")
                        .HasColumnType("varchar(max)")
                        .IsUnicode(false);

                    b.Property<int>("IdProvjera")
                        .HasColumnType("int");

                    b.Property<int>("IdUčenik")
                        .HasColumnType("int");

                    b.Property<int>("Ocjena1")
                        .HasColumnName("Ocjena")
                        .HasColumnType("int");

                    b.Property<int?>("OstvareniBodovi")
                        .HasColumnType("int");

                    b.HasKey("IdOcjena")
                        .HasName("PK__Ocjena__B11E3475EE439EA7");

                    b.HasIndex("IdProvjera");

                    b.HasIndex("IdUčenik");

                    b.ToTable("Ocjena");
                });

            modelBuilder.Entity("GradebookBLL.DomainModels.Predmet", b =>
                {
                    b.Property<int>("IdPredmet")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GodinaRazreda")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Opis")
                        .HasColumnType("varchar(max)")
                        .IsUnicode(false);

                    b.HasKey("IdPredmet")
                        .HasName("PK__Predmet__0D27FFBA207D6AC8");

                    b.HasIndex("GodinaRazreda");

                    b.ToTable("Predmet");
                });

            modelBuilder.Entity("GradebookBLL.DomainModels.Provjera", b =>
                {
                    b.Property<int>("IdProvjera")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Datum")
                        .HasColumnType("datetime");

                    b.Property<int>("IdPredmet")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Opis")
                        .HasColumnType("varchar(max)")
                        .IsUnicode(false);

                    b.HasKey("IdProvjera")
                        .HasName("PK__Provjera__157DDFD44CCE7E78");

                    b.HasIndex("IdPredmet");

                    b.ToTable("Provjera");
                });

            modelBuilder.Entity("GradebookBLL.DomainModels.Razred", b =>
                {
                    b.Property<int>("IdRazred")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GodinaRazreda")
                        .HasColumnType("int");

                    b.Property<int>("IdRazrednik")
                        .HasColumnType("int");

                    b.Property<string>("KraticaOdjel")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("IdRazred")
                        .HasName("PK__Razred__09B6F50C180414F8");

                    b.HasIndex("GodinaRazreda");

                    b.HasIndex("IdRazrednik");

                    b.ToTable("Razred");
                });

            modelBuilder.Entity("GradebookBLL.DomainModels.Uloga", b =>
                {
                    b.Property<int>("IdUloga")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NazivUloga")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("IdUloga")
                        .HasName("PK__Uloga__D87E58942704DEB0");

                    b.ToTable("Uloga");

                    b.HasData(
                        new
                        {
                            IdUloga = 1,
                            NazivUloga = "Admin"
                        },
                        new
                        {
                            IdUloga = 2,
                            NazivUloga = "Nastavnik"
                        },
                        new
                        {
                            IdUloga = 3,
                            NazivUloga = "Razrednik"
                        },
                        new
                        {
                            IdUloga = 4,
                            NazivUloga = "Učenik"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("GradebookBLL.DomainModels.Bilješka", b =>
                {
                    b.HasOne("GradebookBLL.DomainModels.Korisnik", "IdUčenikNavigation")
                        .WithMany("BilješkaIdUčenikNavigation")
                        .HasForeignKey("IdUčenik")
                        .HasConstraintName("FK__Bilješka__IdUčen__5812160E")
                        .IsRequired();

                    b.HasOne("GradebookBLL.DomainModels.Korisnik", "ZabilježioKorisnikNavigation")
                        .WithMany("BilješkaZabilježioKorisnikNavigation")
                        .HasForeignKey("ZabilježioKorisnik")
                        .HasConstraintName("FK__Bilješka__Zabilj__571DF1D5")
                        .IsRequired();
                });

            modelBuilder.Entity("GradebookBLL.DomainModels.Korisnik", b =>
                {
                    b.HasOne("GradebookBLL.DomainModels.Razred", "IdRazredNavigation")
                        .WithMany("Korisnik")
                        .HasForeignKey("IdRazred")
                        .HasConstraintName("FK__Korisnik__IdRazr__5070F446");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GradebookBLL.DomainModels.KorisnikUloga", b =>
                {
                    b.HasOne("GradebookBLL.DomainModels.Korisnik", "IdKorisnikNavigation")
                        .WithMany("KorisnikUloga")
                        .HasForeignKey("IdKorisnik")
                        .HasConstraintName("FK__KorisnikU__IdKor__534D60F1")
                        .IsRequired();

                    b.HasOne("GradebookBLL.DomainModels.Uloga", "IdUlogaNavigation")
                        .WithMany("KorisnikUloga")
                        .HasForeignKey("IdUloga")
                        .HasConstraintName("FK__KorisnikU__IdUlo__5441852A")
                        .IsRequired();
                });

            modelBuilder.Entity("GradebookBLL.DomainModels.NastavnikPredaje", b =>
                {
                    b.HasOne("GradebookBLL.DomainModels.KriterijOcjenjivanja", "IdKriterijNavigation")
                        .WithMany("NastavnikPredaje")
                        .HasForeignKey("IdKriterij")
                        .HasConstraintName("FK__Nastavnik__IdKri__68487DD7")
                        .IsRequired();

                    b.HasOne("GradebookBLL.DomainModels.Korisnik", "IdNastavnikNavigation")
                        .WithMany("NastavnikPredaje")
                        .HasForeignKey("IdNastavnik")
                        .HasConstraintName("FK__Nastavnik__IdNas__66603565")
                        .IsRequired();

                    b.HasOne("GradebookBLL.DomainModels.Predmet", "IdPredmetNavigation")
                        .WithMany("NastavnikPredaje")
                        .HasForeignKey("IdPredmet")
                        .HasConstraintName("FK__Nastavnik__IdPre__6754599E")
                        .IsRequired();
                });

            modelBuilder.Entity("GradebookBLL.DomainModels.Ocjena", b =>
                {
                    b.HasOne("GradebookBLL.DomainModels.Provjera", "IdProvjeraNavigation")
                        .WithMany("Ocjena")
                        .HasForeignKey("IdProvjera")
                        .HasConstraintName("FK__Ocjena__IdProvje__60A75C0F")
                        .IsRequired();

                    b.HasOne("GradebookBLL.DomainModels.Korisnik", "IdUčenikNavigation")
                        .WithMany("Ocjena")
                        .HasForeignKey("IdUčenik")
                        .HasConstraintName("FK__Ocjena__IdUčenik__619B8048")
                        .IsRequired();
                });

            modelBuilder.Entity("GradebookBLL.DomainModels.Predmet", b =>
                {
                    b.HasOne("GradebookBLL.DomainModels.GodinaRazreda", "GodinaRazredaNavigation")
                        .WithMany("Predmet")
                        .HasForeignKey("GodinaRazreda")
                        .HasConstraintName("FK__Predmet__GodinaR__5AEE82B9")
                        .IsRequired();
                });

            modelBuilder.Entity("GradebookBLL.DomainModels.Provjera", b =>
                {
                    b.HasOne("GradebookBLL.DomainModels.Predmet", "IdPredmetNavigation")
                        .WithMany("Provjera")
                        .HasForeignKey("IdPredmet")
                        .HasConstraintName("FK__Provjera__IdPred__5DCAEF64")
                        .IsRequired();
                });

            modelBuilder.Entity("GradebookBLL.DomainModels.Razred", b =>
                {
                    b.HasOne("GradebookBLL.DomainModels.GodinaRazreda", "GodinaRazredaNavigation")
                        .WithMany("Razred")
                        .HasForeignKey("GodinaRazreda")
                        .HasConstraintName("FK__Razred__GodinaRa__4D94879B")
                        .IsRequired();

                    b.HasOne("GradebookBLL.DomainModels.Korisnik", "IdRazrednikNavigation")
                        .WithMany("Razred")
                        .HasForeignKey("IdRazrednik")
                        .HasConstraintName("FK_Razred_Razrednik")
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

using System;
using GradebookBLL.DomainModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GradebookSqlServerDAL
{
    public partial class GradebookDbContext : IdentityDbContext
    {
        public GradebookDbContext(DbContextOptions<GradebookDbContext> options) : base(options) { }

        public virtual DbSet<Biljeska> Bilješka { get; set; }
        public virtual DbSet<GodinaRazreda> GodinaRazreda { get; set; }
        public virtual DbSet<Korisnik> Korisnik { get; set; }
        public virtual DbSet<KorisnikUloga> KorisnikUloga { get; set; }
        public virtual DbSet<KriterijOcjenjivanja> KriterijOcjenjivanja { get; set; }
        public virtual DbSet<NastavnikPredaje> NastavnikPredaje { get; set; }
        public virtual DbSet<Ocjena> Ocjena { get; set; }
        public virtual DbSet<Predmet> Predmet { get; set; }
        public virtual DbSet<Provjera> Provjera { get; set; }
        public virtual DbSet<Razred> Razred { get; set; }
        public virtual DbSet<Uloga> Uloga { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Biljeska>(entity =>
            {
                entity.HasKey(e => e.IdBilješka)
                    .HasName("PK__Bilješka__516F1AAA586134E9");

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.Opis).IsUnicode(false);

                entity.HasOne(d => d.IdUčenikNavigation)
                    .WithMany(p => p.BilješkaIdUčenikNavigation)
                    .HasForeignKey(d => d.IdUčenik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bilješka__IdUčen__5812160E");

                entity.HasOne(d => d.ZabilježioKorisnikNavigation)
                    .WithMany(p => p.BilješkaZabilježioKorisnikNavigation)
                    .HasForeignKey(d => d.ZabilježioKorisnik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bilješka__Zabilj__571DF1D5");
            });

            modelBuilder.Entity<GodinaRazreda>(entity =>
            {
                entity.HasKey(e => e.IdGodRazreda)
                    .HasName("PK__GodinaRa__934B60D72E70C534");
            });

            modelBuilder.Entity<Korisnik>(entity =>
            {
                entity.HasKey(e => e.IdKorisnik)
                    .HasName("PK__Korisnik__58FE570EEAF3FFC1");

                entity.Property(e => e.DatumRođenja)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailAdresa)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Prezime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Spol)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRazredNavigation)
                    .WithMany(p => p.Korisnik)
                    .HasForeignKey(d => d.IdRazred)
                    .HasConstraintName("FK__Korisnik__IdRazr__5070F446");
            });

            modelBuilder.Entity<KorisnikUloga>(entity =>
            {
                entity.HasKey(e => new { e.IdKorisnik, e.IdUloga });

                entity.HasOne(d => d.IdKorisnikNavigation)
                    .WithMany(p => p.KorisnikUloga)
                    .HasForeignKey(d => d.IdKorisnik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KorisnikU__IdKor__534D60F1");

                entity.HasOne(d => d.IdUlogaNavigation)
                    .WithMany(p => p.KorisnikUloga)
                    .HasForeignKey(d => d.IdUloga)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KorisnikU__IdUlo__5441852A");
            });

            modelBuilder.Entity<KriterijOcjenjivanja>(entity =>
            {
                entity.HasKey(e => e.IdKriterij)
                    .HasName("PK__Kriterij__8E19A28AE229E69B");

                entity.Property(e => e.Kriterij1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Kriterij2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Kriterij3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Kriterij4)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NastavnikPredaje>(entity =>
            {
                entity.HasKey(e => new { e.IdNastavnik, e.IdPredmet, e.IdKriterij });

                entity.HasOne(d => d.IdKriterijNavigation)
                    .WithMany(p => p.NastavnikPredaje)
                    .HasForeignKey(d => d.IdKriterij)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Nastavnik__IdKri__68487DD7");

                entity.HasOne(d => d.IdNastavnikNavigation)
                    .WithMany(p => p.NastavnikPredaje)
                    .HasForeignKey(d => d.IdNastavnik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Nastavnik__IdNas__66603565");

                entity.HasOne(d => d.IdPredmetNavigation)
                    .WithMany(p => p.NastavnikPredaje)
                    .HasForeignKey(d => d.IdPredmet)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Nastavnik__IdPre__6754599E");
            });

            modelBuilder.Entity<Ocjena>(entity =>
            {
                entity.HasKey(e => e.IdOcjena)
                    .HasName("PK__Ocjena__B11E3475EE439EA7");

                entity.Property(e => e.Bilješka).IsUnicode(false);

                entity.Property(e => e.Ocjena1).HasColumnName("Ocjena");

                entity.HasOne(d => d.IdProvjeraNavigation)
                    .WithMany(p => p.Ocjena)
                    .HasForeignKey(d => d.IdProvjera)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Ocjena__IdProvje__60A75C0F");

                entity.HasOne(d => d.IdUčenikNavigation)
                    .WithMany(p => p.Ocjena)
                    .HasForeignKey(d => d.IdUčenik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ocjena__IdUčenik__619B8048");
            });

            modelBuilder.Entity<Predmet>(entity =>
            {
                entity.HasKey(e => e.IdPredmet)
                    .HasName("PK__Predmet__0D27FFBA207D6AC8");

                entity.Property(e => e.Naziv)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Opis).IsUnicode(false);

                entity.HasOne(d => d.GodinaRazredaNavigation)
                    .WithMany(p => p.Predmet)
                    .HasForeignKey(d => d.GodinaRazreda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Predmet__GodinaR__5AEE82B9");
            });

            modelBuilder.Entity<Provjera>(entity =>
            {
                entity.HasKey(e => e.IdProvjera)
                    .HasName("PK__Provjera__157DDFD44CCE7E78");

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.Naziv)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Opis).IsUnicode(false);

                entity.HasOne(d => d.IdPredmetNavigation)
                    .WithMany(p => p.Provjera)
                    .HasForeignKey(d => d.IdPredmet)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Provjera__IdPred__5DCAEF64");
            });

            modelBuilder.Entity<Razred>(entity =>
            {
                entity.HasKey(e => e.IdRazred)
                    .HasName("PK__Razred__09B6F50C180414F8");

                entity.Property(e => e.KraticaOdjel)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.GodinaRazredaNavigation)
                    .WithMany(p => p.Razred)
                    .HasForeignKey(d => d.GodinaRazreda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Razred__GodinaRa__4D94879B");

                entity.HasOne(d => d.IdRazrednikNavigation)
                    .WithMany(p => p.Razred)
                    .HasForeignKey(d => d.IdRazrednik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Razred_Razrednik");
            });

            modelBuilder.Entity<Uloga>(entity =>
            {
                entity.HasKey(e => e.IdUloga)
                    .HasName("PK__Uloga__D87E58942704DEB0");

                entity.Property(e => e.NazivUloga)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Uloga>().HasData(
                new Uloga {IdUloga = 1, NazivUloga = "Admin"},
                new Uloga {IdUloga = 2, NazivUloga = "Nastavnik"},
                new Uloga {IdUloga = 3, NazivUloga = "Razrednik"},
                new Uloga {IdUloga = 4, NazivUloga = "Učenik"});

            modelBuilder.Entity<GodinaRazreda>().HasData(
                new GodinaRazreda {IdGodRazreda = 1, Godina = "1"},
                new GodinaRazreda {IdGodRazreda = 2, Godina = "2"},
                new GodinaRazreda {IdGodRazreda = 3, Godina = "3"},
                new GodinaRazreda {IdGodRazreda = 4, Godina = "4"}
            );

            modelBuilder.Entity<KriterijOcjenjivanja>().HasData(
                new KriterijOcjenjivanja { IdKriterij = 1, Kriterij1 = "Teorija", Kriterij2 = "Zadaci", Kriterij3 = "Zadaća", Kriterij4 = "Labosi" },
                new KriterijOcjenjivanja { IdKriterij = 2, Kriterij1 = "Aktivnost", Kriterij2 = "Zalaganje", Kriterij3 = "Prisutnost", Kriterij4 = "Seminar" },
                new KriterijOcjenjivanja { IdKriterij = 3, Kriterij1 = "Praksa", Kriterij2 = "Usmeno" }
                );

            modelBuilder.Entity<Predmet>().HasData(
                new Predmet { IdPredmet = 1, Naziv = "Matematika 1", Opis = "Opis nastavnog plana i programa", GodinaRazreda = 1 },
                new Predmet { IdPredmet = 2, Naziv = "Matematika 2", Opis = "Opis nastavnog plana i programa", GodinaRazreda = 2 },
                new Predmet { IdPredmet = 3, Naziv = "Matematika 3", Opis = "Opis nastavnog plana i programa", GodinaRazreda = 3 },
                new Predmet { IdPredmet = 4, Naziv = "Matematika 4", Opis = "Opis nastavnog plana i programa", GodinaRazreda = 4 },
                new Predmet { IdPredmet = 5, Naziv = "Povijest 1", Opis = "Opis nastavnog plana i programa", GodinaRazreda = 1 },
                new Predmet { IdPredmet = 6, Naziv = "Povijest 2", Opis = "Opis nastavnog plana i programa", GodinaRazreda = 2 },
                new Predmet { IdPredmet = 7, Naziv = "Povijest 3", Opis = "Opis nastavnog plana i programa", GodinaRazreda = 3 },
                new Predmet { IdPredmet = 8, Naziv = "Povijest 4", Opis = "Opis nastavnog plana i programa", GodinaRazreda = 4 },
                new Predmet { IdPredmet = 9, Naziv = "Biologija 1", Opis = "Opis nastavnog plana i programa", GodinaRazreda = 1 },
                new Predmet { IdPredmet = 10, Naziv = "Biologija 2", Opis = "Opis nastavnog plana i programa", GodinaRazreda = 2 },
                new Predmet { IdPredmet = 11, Naziv = "Biologija 3", Opis = "Opis nastavnog plana i programa", GodinaRazreda = 3 },
                new Predmet { IdPredmet = 12, Naziv = "Biologija 4", Opis = "Opis nastavnog plana i programa", GodinaRazreda = 4 },
                new Predmet { IdPredmet = 13, Naziv = "Geografija 1", Opis = "Opis nastavnog plana i programa", GodinaRazreda = 1 },
                new Predmet { IdPredmet = 14, Naziv = "Geografija 2", Opis = "Opis nastavnog plana i programa", GodinaRazreda = 2 },
                new Predmet { IdPredmet = 15, Naziv = "Geografija 3", Opis = "Opis nastavnog plana i programa", GodinaRazreda = 3 },
                new Predmet { IdPredmet = 16, Naziv = "Geografija 4", Opis = "Opis nastavnog plana i programa", GodinaRazreda = 4 },
                new Predmet { IdPredmet = 17, Naziv = "Psihologija 2", Opis = "Opis nastavnog plana i programa", GodinaRazreda = 2 },
                new Predmet { IdPredmet = 18, Naziv = "Psihologija 3", Opis = "Opis nastavnog plana i programa", GodinaRazreda = 3 },
                new Predmet { IdPredmet = 19, Naziv = "Logika 3", Opis = "Opis nastavnog plana i programa", GodinaRazreda = 3 },
                new Predmet { IdPredmet = 20, Naziv = "Filozofija 4", Opis = "Opis nastavnog plana i programa", GodinaRazreda = 4 },
                new Predmet { IdPredmet = 21, Naziv = "Fizika 1", Opis = "Opis nastavnog plana i programa", GodinaRazreda = 1 },
                new Predmet { IdPredmet = 22, Naziv = "Fizika 2", Opis = "Opis nastavnog plana i programa", GodinaRazreda = 2 },
                new Predmet { IdPredmet = 23, Naziv = "Fizika 3", Opis = "Opis nastavnog plana i programa", GodinaRazreda = 3 },
                new Predmet { IdPredmet = 24, Naziv = "Fizika 4", Opis = "Opis nastavnog plana i programa", GodinaRazreda = 4 }
                );

            modelBuilder.Entity<Provjera>().HasData(
                new Provjera { IdProvjera = 1, Naziv = "Kvadratne jednadžbe", IdPredmet = 1, Datum = new DateTime(2020, 5, 28, 13, 30, 0), Opis = "U provjeri ćemo provjeravati znanje kvadratnih jednadžbi. Provjera će se sastojati od 10 zadataka i nositi 50 bodova"},
                new Provjera { IdProvjera = 2, Naziv = "Njihala, valovi i zvuk", IdPredmet = 23, Datum = new DateTime(2020, 5, 19, 9, 0, 0), Opis = "Pisat ćemo sve što smo radili o njihalima, valovima i zvukovima. Uključujući i Dopplerov učinak. Sretno svima!"},
                new Provjera { IdProvjera = 3, Naziv = "Drevni Egipat", IdPredmet = 5, Datum = new DateTime(2020, 5, 24, 8, 30, 0), Opis = "Pišemo provjeru iz cjelokupnog gradiva koji se odnosi na stari Egipat."}
                );
        }
    }
}
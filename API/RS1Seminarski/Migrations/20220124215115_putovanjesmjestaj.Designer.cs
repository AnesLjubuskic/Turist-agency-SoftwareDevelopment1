﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RS1Seminarski.Data;

namespace RS1Seminarski.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220124215115_putovanjesmjestaj")]
    partial class putovanjesmjestaj
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RS1Seminarski.Modul.Models.AplikacijaPosao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CV")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zanimanje")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AplikacijaPosao");
                });

            modelBuilder.Entity("RS1Seminarski.Modul.Models.Racun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumIzdavanja")
                        .HasColumnType("datetime2");

                    b.Property<double>("Iznos")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Racun");
                });

            modelBuilder.Entity("RS1Seminarski.ModulAutentifikacija.Models.AutentifikacijaToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IpAdresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KorisnickiNalogId")
                        .HasColumnType("int");

                    b.Property<string>("Vrijednost")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("VrijemeEvidentiranja")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("KorisnickiNalogId");

                    b.ToTable("AutentifikacijaToken");
                });

            modelBuilder.Entity("RS1Seminarski.ModulAutentifikacija.Models.KorisnickiNalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KorisnickoIme")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lozinka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slika")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("isVodic")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("KorisnickiNalog");
                });

            modelBuilder.Entity("RS1Seminarski.Modul_Smjestaj.Models.Drzava", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Oznaka")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Drzave");
                });

            modelBuilder.Entity("RS1Seminarski.Modul_Smjestaj.Models.Grad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DrzavaId")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostanskiBroj")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DrzavaId");

                    b.ToTable("Gradovi");
                });

            modelBuilder.Entity("RS1Seminarski.Modul_Smjestaj.Models.Putovanje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojPutnika")
                        .HasColumnType("int");

                    b.Property<double>("Cijena")
                        .HasColumnType("float");

                    b.Property<DateTime>("DatumDo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumOd")
                        .HasColumnType("datetime2");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipPutovanja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Trajanje")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Putovanje");
                });

            modelBuilder.Entity("RS1Seminarski.Modul_Smjestaj.Models.PutovanjePrevoznoSredstvo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PrevoznoSredstvoId")
                        .HasColumnType("int");

                    b.Property<int>("PutovanjeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PrevoznoSredstvoId");

                    b.HasIndex("PutovanjeId");

                    b.ToTable("PutovanjePrevoznoSredstvo");
                });

            modelBuilder.Entity("RS1Seminarski.Modul_Smjestaj.Models.PutovanjeSmjestaj", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PutovanjeId")
                        .HasColumnType("int");

                    b.Property<int>("SmjestajId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PutovanjeId");

                    b.HasIndex("SmjestajId");

                    b.ToTable("PutovanjeSmjestaj");
                });

            modelBuilder.Entity("RS1Seminarski.Modul_Smjestaj.Models.Smjestaj", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GradId")
                        .HasColumnType("int");

                    b.Property<int>("Kapacitet")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GradId");

                    b.ToTable("Smjestaj");
                });

            modelBuilder.Entity("RS1Seminarski.Prevoz.Models.PrevoznoSredstvo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Kapacitet")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PrevoznoSredstvo");

                    b.HasDiscriminator<string>("Discriminator").HasValue("PrevoznoSredstvo");
                });

            modelBuilder.Entity("RS1Seminarski.Modul.Models.Admin", b =>
                {
                    b.HasBaseType("RS1Seminarski.ModulAutentifikacija.Models.KorisnickiNalog");

                    b.Property<string>("BrojTelefona")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumZaposlenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("RS1Seminarski.Modul.Models.Vodic", b =>
                {
                    b.HasBaseType("RS1Seminarski.ModulAutentifikacija.Models.KorisnickiNalog");

                    b.Property<string>("BrojTelefona")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumZaposlenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Vodic");
                });

            modelBuilder.Entity("RS1Seminarski.Prevoz.Models.Autobus", b =>
                {
                    b.HasBaseType("RS1Seminarski.Prevoz.Models.PrevoznoSredstvo");

                    b.Property<bool>("Klima")
                        .HasColumnType("bit");

                    b.Property<bool>("WiFi")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("Autobus");
                });

            modelBuilder.Entity("RS1Seminarski.Prevoz.Models.Aviokompanija", b =>
                {
                    b.HasBaseType("RS1Seminarski.Prevoz.Models.PrevoznoSredstvo");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Aviokompanija");
                });

            modelBuilder.Entity("RS1Seminarski.ModulAutentifikacija.Models.AutentifikacijaToken", b =>
                {
                    b.HasOne("RS1Seminarski.ModulAutentifikacija.Models.KorisnickiNalog", "KorisnickiNalog")
                        .WithMany()
                        .HasForeignKey("KorisnickiNalogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KorisnickiNalog");
                });

            modelBuilder.Entity("RS1Seminarski.Modul_Smjestaj.Models.Grad", b =>
                {
                    b.HasOne("RS1Seminarski.Modul_Smjestaj.Models.Drzava", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drzava");
                });

            modelBuilder.Entity("RS1Seminarski.Modul_Smjestaj.Models.PutovanjePrevoznoSredstvo", b =>
                {
                    b.HasOne("RS1Seminarski.Prevoz.Models.PrevoznoSredstvo", "PrevoznoSredstvo")
                        .WithMany()
                        .HasForeignKey("PrevoznoSredstvoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RS1Seminarski.Modul_Smjestaj.Models.Putovanje", "Putovanje")
                        .WithMany()
                        .HasForeignKey("PutovanjeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PrevoznoSredstvo");

                    b.Navigation("Putovanje");
                });

            modelBuilder.Entity("RS1Seminarski.Modul_Smjestaj.Models.PutovanjeSmjestaj", b =>
                {
                    b.HasOne("RS1Seminarski.Modul_Smjestaj.Models.Putovanje", "Putovanje")
                        .WithMany()
                        .HasForeignKey("PutovanjeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RS1Seminarski.Modul_Smjestaj.Models.Smjestaj", "Smjestaj")
                        .WithMany()
                        .HasForeignKey("SmjestajId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Putovanje");

                    b.Navigation("Smjestaj");
                });

            modelBuilder.Entity("RS1Seminarski.Modul_Smjestaj.Models.Smjestaj", b =>
                {
                    b.HasOne("RS1Seminarski.Modul_Smjestaj.Models.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grad");
                });

            modelBuilder.Entity("RS1Seminarski.Modul.Models.Admin", b =>
                {
                    b.HasOne("RS1Seminarski.ModulAutentifikacija.Models.KorisnickiNalog", null)
                        .WithOne()
                        .HasForeignKey("RS1Seminarski.Modul.Models.Admin", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RS1Seminarski.Modul.Models.Vodic", b =>
                {
                    b.HasOne("RS1Seminarski.ModulAutentifikacija.Models.KorisnickiNalog", null)
                        .WithOne()
                        .HasForeignKey("RS1Seminarski.Modul.Models.Vodic", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

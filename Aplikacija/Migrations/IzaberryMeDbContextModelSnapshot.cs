﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

#nullable disable

namespace Aplikacija.Migrations
{
    [DbContext(typeof(IzaberryMeDbContext))]
    partial class IzaberryMeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.3.23174.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Models.Datum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("OznacenDatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Poruka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("kalendarId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("kalendarId");

                    b.ToTable("Datumi");
                });

            modelBuilder.Entity("Models.Kalendar", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Kalendari");
                });

            modelBuilder.Entity("Models.Komentar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PredmetId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PredmetId");

                    b.HasIndex("StudentId");

                    b.ToTable("Komentari");
                });

            modelBuilder.Entity("Models.Literatura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("MentorId")
                        .HasColumnType("int");

                    b.Property<int?>("PredmetId")
                        .HasColumnType("int");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.Property<string>("filePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MentorId");

                    b.HasIndex("PredmetId");

                    b.HasIndex("StudentId");

                    b.ToTable("Literatura");
                });

            modelBuilder.Entity("Models.MentorRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("IndeksPhoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PredmetId")
                        .HasColumnType("int");

                    b.Property<string>("PredmetPhoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PredmetId");

                    b.HasIndex("StudentId");

                    b.ToTable("MentorRequests");
                });

            modelBuilder.Entity("Models.Modul", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Moduli");
                });

            modelBuilder.Entity("Models.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("doneVisible")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Note");
                });

            modelBuilder.Entity("Models.Ocena", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AngazovanjeProfesora")
                        .HasColumnType("int");

                    b.Property<int>("DostupnostMaterijala")
                        .HasColumnType("int");

                    b.Property<int>("LaboratorijskeVezbe")
                        .HasColumnType("int");

                    b.Property<int>("PrakticnoZnanje")
                        .HasColumnType("int");

                    b.Property<int?>("PredmetId")
                        .HasColumnType("int");

                    b.Property<int>("TezinaPredmeta")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PredmetId");

                    b.ToTable("Ocene");
                });

            modelBuilder.Entity("Models.Predmet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ESPB")
                        .HasColumnType("int");

                    b.Property<int?>("MentorId")
                        .HasColumnType("int");

                    b.Property<int?>("ModulId")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Semestar")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MentorId");

                    b.HasIndex("ModulId");

                    b.ToTable("Predmeti");
                });

            modelBuilder.Entity("Models.Preference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Ocena")
                        .HasColumnType("int");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TagId");

                    b.ToTable("Preference");
                });

            modelBuilder.Entity("Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<int?>("ModulId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<int>("Privilegije")
                        .HasColumnType("int");

                    b.Property<string>("ProfileImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Semestar")
                        .HasColumnType("int")
                        .HasColumnName("semestar");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.HasIndex("ModulId");

                    b.ToTable("Student");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tagovi");
                });

            modelBuilder.Entity("Models.Zahtev", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("MentorId")
                        .HasColumnType("int");

                    b.Property<bool>("Odobren")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("MentorId");

                    b.ToTable("Zahtev");
                });

            modelBuilder.Entity("PredmetTag", b =>
                {
                    b.Property<int>("PredmetiId")
                        .HasColumnType("int");

                    b.Property<int>("TagoviId")
                        .HasColumnType("int");

                    b.HasKey("PredmetiId", "TagoviId");

                    b.HasIndex("TagoviId");

                    b.ToTable("PredmetTag");
                });

            modelBuilder.Entity("Models.Mentor", b =>
                {
                    b.HasBaseType("Models.Student");

                    b.ToTable("Mentor");
                });

            modelBuilder.Entity("Models.Admin", b =>
                {
                    b.HasBaseType("Models.Mentor");

                    b.ToTable("Administrator");
                });

            modelBuilder.Entity("Models.Datum", b =>
                {
                    b.HasOne("Models.Kalendar", "kalendar")
                        .WithMany("MarkiraniDatumi")
                        .HasForeignKey("kalendarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("kalendar");
                });

            modelBuilder.Entity("Models.Kalendar", b =>
                {
                    b.HasOne("Models.Student", "Student")
                        .WithOne("Kalendar")
                        .HasForeignKey("Models.Kalendar", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Models.Komentar", b =>
                {
                    b.HasOne("Models.Predmet", "Predmet")
                        .WithMany("Komentari")
                        .HasForeignKey("PredmetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Student", "Student")
                        .WithMany("Komentari")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Predmet");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Models.Literatura", b =>
                {
                    b.HasOne("Models.Mentor", "Mentor")
                        .WithMany()
                        .HasForeignKey("MentorId");

                    b.HasOne("Models.Predmet", "Predmet")
                        .WithMany("Literature")
                        .HasForeignKey("PredmetId");

                    b.HasOne("Models.Student", "Student")
                        .WithMany("Literatura")
                        .HasForeignKey("StudentId");

                    b.Navigation("Mentor");

                    b.Navigation("Predmet");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Models.MentorRequest", b =>
                {
                    b.HasOne("Models.Predmet", "Predmet")
                        .WithMany()
                        .HasForeignKey("PredmetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Predmet");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Models.Note", b =>
                {
                    b.HasOne("Models.Student", "Student")
                        .WithMany("Notes")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Models.Ocena", b =>
                {
                    b.HasOne("Models.Predmet", null)
                        .WithMany("Ocene")
                        .HasForeignKey("PredmetId");
                });

            modelBuilder.Entity("Models.Predmet", b =>
                {
                    b.HasOne("Models.Mentor", null)
                        .WithMany("Predmeti")
                        .HasForeignKey("MentorId");

                    b.HasOne("Models.Modul", "Modul")
                        .WithMany()
                        .HasForeignKey("ModulId");

                    b.Navigation("Modul");
                });

            modelBuilder.Entity("Models.Preference", b =>
                {
                    b.HasOne("Models.Student", "Student")
                        .WithMany("Preference")
                        .HasForeignKey("StudentId");

                    b.HasOne("Models.Tag", "Tag")
                        .WithMany("Preference")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Models.Student", b =>
                {
                    b.HasOne("Models.Modul", "Modul")
                        .WithMany()
                        .HasForeignKey("ModulId");

                    b.Navigation("Modul");
                });

            modelBuilder.Entity("Models.Zahtev", b =>
                {
                    b.HasOne("Models.Literatura", "Literatura")
                        .WithOne("Zahtev")
                        .HasForeignKey("Models.Zahtev", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Mentor", "Mentor")
                        .WithMany("Zahtevi")
                        .HasForeignKey("MentorId");

                    b.Navigation("Literatura");

                    b.Navigation("Mentor");
                });

            modelBuilder.Entity("PredmetTag", b =>
                {
                    b.HasOne("Models.Predmet", null)
                        .WithMany()
                        .HasForeignKey("PredmetiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagoviId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Mentor", b =>
                {
                    b.HasOne("Models.Student", null)
                        .WithOne()
                        .HasForeignKey("Models.Mentor", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Admin", b =>
                {
                    b.HasOne("Models.Mentor", null)
                        .WithOne()
                        .HasForeignKey("Models.Admin", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Kalendar", b =>
                {
                    b.Navigation("MarkiraniDatumi");
                });

            modelBuilder.Entity("Models.Literatura", b =>
                {
                    b.Navigation("Zahtev");
                });

            modelBuilder.Entity("Models.Predmet", b =>
                {
                    b.Navigation("Komentari");

                    b.Navigation("Literature");

                    b.Navigation("Ocene");
                });

            modelBuilder.Entity("Models.Student", b =>
                {
                    b.Navigation("Kalendar")
                        .IsRequired();

                    b.Navigation("Komentari");

                    b.Navigation("Literatura");

                    b.Navigation("Notes");

                    b.Navigation("Preference");
                });

            modelBuilder.Entity("Models.Tag", b =>
                {
                    b.Navigation("Preference");
                });

            modelBuilder.Entity("Models.Mentor", b =>
                {
                    b.Navigation("Predmeti");

                    b.Navigation("Zahtevi");
                });
#pragma warning restore 612, 618
        }
    }
}

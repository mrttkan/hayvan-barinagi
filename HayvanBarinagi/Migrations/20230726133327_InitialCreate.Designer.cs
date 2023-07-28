﻿// <auto-generated />
using System;
using HayvanBarinagi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HayvanBarinagi.Migrations
{
    [DbContext(typeof(HayvanBarinagiContext))]
    [Migration("20230726133327_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HayvanBarinagi.Models.Hayvan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResimUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Sahiplendirildi")
                        .HasColumnType("bit");

                    b.Property<string>("Tur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hayvans");
                });

            modelBuilder.Entity("HayvanBarinagi.Models.SahiplendirmeBasvurusu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BasvuranKisi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BasvuruTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Durum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HayvanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HayvanId");

                    b.ToTable("SahiplendirmeBasvurusus");
                });

            modelBuilder.Entity("HayvanBarinagi.Models.SahiplendirmeBasvurusu", b =>
                {
                    b.HasOne("HayvanBarinagi.Models.Hayvan", "Hayvan")
                        .WithMany()
                        .HasForeignKey("HayvanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hayvan");
                });
#pragma warning restore 612, 618
        }
    }
}

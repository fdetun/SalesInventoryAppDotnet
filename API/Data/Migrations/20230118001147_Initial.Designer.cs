﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230118001147_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

            modelBuilder.Entity("API.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("BLOB");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("API.Entities.Article", b =>
                {
                    b.Property<int>("NumArticle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Libelle")
                        .HasColumnType("TEXT");

                    b.Property<double>("PrixUnitaire")
                        .HasColumnType("REAL");

                    b.Property<int>("QteStock")
                        .HasColumnType("INTEGER");

                    b.HasKey("NumArticle");

                    b.ToTable("Article");
                });

            modelBuilder.Entity("API.Entities.Client", b =>
                {
                    b.Property<int>("CIN")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adress")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nom")
                        .HasColumnType("TEXT");

                    b.Property<int>("Tel")
                        .HasColumnType("INTEGER");

                    b.HasKey("CIN");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("API.Entities.Devis", b =>
                {
                    b.Property<int>("NumDevis")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.HasKey("NumDevis");

                    b.ToTable("Devis");
                });

            modelBuilder.Entity("ArticleDevis", b =>
                {
                    b.Property<int>("ArticlesNumArticle")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DevissNumDevis")
                        .HasColumnType("INTEGER");

                    b.HasKey("ArticlesNumArticle", "DevissNumDevis");

                    b.HasIndex("DevissNumDevis");

                    b.ToTable("ArticleDevis");
                });

            modelBuilder.Entity("ArticleDevis", b =>
                {
                    b.HasOne("API.Entities.Article", null)
                        .WithMany()
                        .HasForeignKey("ArticlesNumArticle")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Devis", null)
                        .WithMany()
                        .HasForeignKey("DevissNumDevis")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

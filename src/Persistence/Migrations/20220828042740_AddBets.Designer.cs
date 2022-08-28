﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Smashup.Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(SmashupDbContext))]
    [Migration("20220828042740_AddBets")]
    partial class AddBets
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.8");

            modelBuilder.Entity("Smashup.Domain.Modules.Bets.Bet", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("amount")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("roundid")
                        .HasColumnType("uuid");

                    b.Property<int>("status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("userid")
                        .HasColumnType("uuid");

                    b.HasKey("id");

                    b.HasIndex("roundid");

                    b.HasIndex("userid");

                    b.ToTable("Bet");
                });

            modelBuilder.Entity("Smashup.Domain.Modules.Colors.Color", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("meta")
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Color");
                });

            modelBuilder.Entity("Smashup.Domain.Modules.Rounds.Round", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("colorid")
                        .IsRequired()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("seed")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("colorid");

                    b.ToTable("Round");
                });

            modelBuilder.Entity("Smashup.Domain.Modules.Users.User", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Smashup.Domain.Modules.Bets.Bet", b =>
                {
                    b.HasOne("Smashup.Domain.Modules.Rounds.Round", "round")
                        .WithMany()
                        .HasForeignKey("roundid");

                    b.HasOne("Smashup.Domain.Modules.Users.User", "user")
                        .WithMany()
                        .HasForeignKey("userid");

                    b.Navigation("round");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Smashup.Domain.Modules.Rounds.Round", b =>
                {
                    b.HasOne("Smashup.Domain.Modules.Colors.Color", "color")
                        .WithMany()
                        .HasForeignKey("colorid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("color");
                });
#pragma warning restore 612, 618
        }
    }
}

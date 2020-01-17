﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rankings.EntityFramework;

namespace Rankings.EntityFramework.Migrations
{
    [DbContext(typeof(RankingsContext))]
    [Migration("20200117140402_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1");

            modelBuilder.Entity("Rankings.EntityFramework.Entities.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RankingId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("ItemId");

                    b.HasIndex("RankingId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Rankings.EntityFramework.Entities.Ranking", b =>
                {
                    b.Property<int>("RankingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("RankingId");

                    b.ToTable("Rankings");
                });

            modelBuilder.Entity("Rankings.EntityFramework.Entities.Item", b =>
                {
                    b.HasOne("Rankings.EntityFramework.Entities.Ranking", "Ranking")
                        .WithMany("Items")
                        .HasForeignKey("RankingId");
                });
#pragma warning restore 612, 618
        }
    }
}
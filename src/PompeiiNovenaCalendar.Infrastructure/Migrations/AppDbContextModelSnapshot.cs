﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PompeiiNovenaCalendar.Infrastructure.Database;

#nullable disable

namespace PompeiiNovenaCalendar.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.13");

            modelBuilder.Entity("PompeiiNovenaCalendar.Domain.Database.Entities.DayRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("DayRecords", (string)null);
                });

            modelBuilder.Entity("PompeiiNovenaCalendar.Domain.Database.Entities.RosarySelection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DayRecordId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RosaryTypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DayRecordId");

                    b.HasIndex("RosaryTypeId");

                    b.ToTable("RosarySelections", (string)null);
                });

            modelBuilder.Entity("PompeiiNovenaCalendar.Domain.Database.Entities.RosaryType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("RosaryTypes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Key = "JoyfulMysteries"
                        },
                        new
                        {
                            Id = 2,
                            Key = "SorrowfulMysteries"
                        },
                        new
                        {
                            Id = 3,
                            Key = "GloriousMysteries"
                        },
                        new
                        {
                            Id = 4,
                            Key = "LuminousMysteries"
                        });
                });

            modelBuilder.Entity("PompeiiNovenaCalendar.Domain.Database.Entities.RosaryTypeLocalization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("RosaryTypeLocalizations", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Key = "JoyfulMysteries",
                            Language = "pl",
                            Name = "Tajemnice radosne"
                        },
                        new
                        {
                            Id = 2,
                            Key = "SorrowfulMysteries",
                            Language = "pl",
                            Name = "Tajemnice bolesne"
                        },
                        new
                        {
                            Id = 3,
                            Key = "GloriousMysteries",
                            Language = "pl",
                            Name = "Tajemnice chwalebne"
                        },
                        new
                        {
                            Id = 4,
                            Key = "LuminousMysteries",
                            Language = "pl",
                            Name = "Tajemnice światła"
                        },
                        new
                        {
                            Id = 5,
                            Key = "JoyfulMysteries",
                            Language = "en",
                            Name = "Joyful Mysteries"
                        },
                        new
                        {
                            Id = 6,
                            Key = "SorrowfulMysteries",
                            Language = "en",
                            Name = "Sorrowful Mysteries"
                        },
                        new
                        {
                            Id = 7,
                            Key = "GloriousMysteries",
                            Language = "en",
                            Name = "Glorious Mysteries"
                        },
                        new
                        {
                            Id = 8,
                            Key = "LuminousMysteries",
                            Language = "en",
                            Name = "Luminous Mysteries"
                        });
                });

            modelBuilder.Entity("PompeiiNovenaCalendar.Domain.Database.Entities.RosarySelection", b =>
                {
                    b.HasOne("PompeiiNovenaCalendar.Domain.Database.Entities.DayRecord", null)
                        .WithMany("RosarySelections")
                        .HasForeignKey("DayRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PompeiiNovenaCalendar.Domain.Database.Entities.RosaryType", null)
                        .WithMany()
                        .HasForeignKey("RosaryTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PompeiiNovenaCalendar.Domain.Database.Entities.DayRecord", b =>
                {
                    b.Navigation("RosarySelections");
                });
#pragma warning restore 612, 618
        }
    }
}

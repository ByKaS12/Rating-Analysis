﻿// <auto-generated />
using System;
using DiplomMag.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DiplomMag.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240708204746_MigFix-v13")]
    partial class MigFixv13
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("DiplomMag.Models.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("DiplomMag.models.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("GameDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TournamentId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("DiplomMag.models.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("GameId")
                        .HasColumnType("TEXT");

                    b.Property<double>("Height")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("TEXT");

                    b.Property<string>("PlayerPosition")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("TEXT");

                    b.Property<double>("Weight")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("DiplomMag.models.Rebound", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("AllReb")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RebOfAlien")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RebOfOwn")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("StatisticId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("StatisticId")
                        .IsUnique();

                    b.ToTable("Rebounds");
                });

            modelBuilder.Entity("DiplomMag.models.Shoot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("FieldGoalsAllPoints")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FieldGoalsScoredPoints")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FreeThrowsAllPoints")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FreeThrowsScoredPoints")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("StatisticId")
                        .HasColumnType("TEXT");

                    b.Property<int>("ThreePointAllPoints")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ThreePointScoredPoints")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TwoPointAllPoints")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TwoPointScoredPoints")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("StatisticId")
                        .IsUnique();

                    b.ToTable("Shoots");
                });

            modelBuilder.Entity("DiplomMag.models.Statistic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Assists")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Blockshots")
                        .HasColumnType("INTEGER");

                    b.Property<double>("CalcDefRating")
                        .HasColumnType("REAL");

                    b.Property<double>("CalcEFGProcent")
                        .HasColumnType("REAL");

                    b.Property<double>("CalcHollinger")
                        .HasColumnType("REAL");

                    b.Property<double>("CalcOffRating")
                        .HasColumnType("REAL");

                    b.Property<double>("CalcPace")
                        .HasColumnType("REAL");

                    b.Property<double>("CalcTPA")
                        .HasColumnType("REAL");

                    b.Property<double>("CalcTSProcent")
                        .HasColumnType("REAL");

                    b.Property<double>("CalcUPer")
                        .HasColumnType("REAL");

                    b.Property<int>("Fouls")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FoulsOfEnemy")
                        .HasColumnType("INTEGER");

                    b.Property<int>("KPI")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Losses")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("TEXT");

                    b.Property<int>("PlusMinus")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Points")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Steals")
                        .HasColumnType("INTEGER");

                    b.Property<TimeOnly>("TimePlayed")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId")
                        .IsUnique();

                    b.ToTable("Statistics");
                });

            modelBuilder.Entity("DiplomMag.models.Tournament", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("DiplomMag.models.Game", b =>
                {
                    b.HasOne("DiplomMag.models.Tournament", "Tournament")
                        .WithMany("Games")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("DiplomMag.models.Player", b =>
                {
                    b.HasOne("DiplomMag.models.Game", "Game")
                        .WithMany("Players")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiplomMag.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("DiplomMag.models.Rebound", b =>
                {
                    b.HasOne("DiplomMag.models.Statistic", "Statistic")
                        .WithOne("Rebounds")
                        .HasForeignKey("DiplomMag.models.Rebound", "StatisticId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Statistic");
                });

            modelBuilder.Entity("DiplomMag.models.Shoot", b =>
                {
                    b.HasOne("DiplomMag.models.Statistic", "Statistic")
                        .WithOne("Shoots")
                        .HasForeignKey("DiplomMag.models.Shoot", "StatisticId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Statistic");
                });

            modelBuilder.Entity("DiplomMag.models.Statistic", b =>
                {
                    b.HasOne("DiplomMag.models.Player", "Player")
                        .WithOne("Statistic")
                        .HasForeignKey("DiplomMag.models.Statistic", "PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("DiplomMag.Models.Team", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("DiplomMag.models.Game", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("DiplomMag.models.Player", b =>
                {
                    b.Navigation("Statistic")
                        .IsRequired();
                });

            modelBuilder.Entity("DiplomMag.models.Statistic", b =>
                {
                    b.Navigation("Rebounds");

                    b.Navigation("Shoots");
                });

            modelBuilder.Entity("DiplomMag.models.Tournament", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}

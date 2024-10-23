﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _2024_25_Süper_Lig_Kit.WebApi.Context;

#nullable disable

namespace _2024_25_Süper_Lig_Kit.WebApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("_2024_25_Süper_Lig_Kit.WebApi.Entities.Jersey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsKeeper")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Jerseys");
                });

            modelBuilder.Entity("_2024_25_Süper_Lig_Kit.WebApi.Entities.JerseyImage", b =>
                {
                    b.Property<int>("JerseyImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JerseyImageId"));

                    b.Property<string>("ImgPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JerseyId")
                        .HasColumnType("int");

                    b.HasKey("JerseyImageId");

                    b.HasIndex("JerseyId");

                    b.ToTable("JerseyImages");
                });

            modelBuilder.Entity("_2024_25_Süper_Lig_Kit.WebApi.Entities.Match", b =>
                {
                    b.Property<int>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MatchId"));

                    b.Property<int?>("AwayMS")
                        .HasColumnType("int");

                    b.Property<int>("AwayTeamId")
                        .HasColumnType("int");

                    b.Property<int>("AwayTeamJerseyImageGKId")
                        .HasColumnType("int");

                    b.Property<int>("AwayTeamJerseyImageId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HomeMS")
                        .HasColumnType("int");

                    b.Property<int>("HomeTeamId")
                        .HasColumnType("int");

                    b.Property<int>("HomeTeamJerseyImageGKId")
                        .HasColumnType("int");

                    b.Property<int>("HomeTeamJerseyImageId")
                        .HasColumnType("int");

                    b.Property<int>("MainId")
                        .HasColumnType("int");

                    b.Property<int?>("Maçkolik")
                        .HasColumnType("int");

                    b.Property<int>("RefereeId")
                        .HasColumnType("int");

                    b.Property<int>("RefereeJerseyImageId")
                        .HasColumnType("int");

                    b.Property<int>("Week")
                        .HasColumnType("int");

                    b.HasKey("MatchId");

                    b.HasIndex("AwayTeamId");

                    b.HasIndex("AwayTeamJerseyImageGKId");

                    b.HasIndex("AwayTeamJerseyImageId");

                    b.HasIndex("HomeTeamId");

                    b.HasIndex("HomeTeamJerseyImageGKId");

                    b.HasIndex("HomeTeamJerseyImageId");

                    b.HasIndex("RefereeId");

                    b.HasIndex("RefereeJerseyImageId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("_2024_25_Süper_Lig_Kit.WebApi.Entities.Referee", b =>
                {
                    b.Property<int>("RefereeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RefereeId"));

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsFifa")
                        .HasColumnType("bit");

                    b.Property<string>("RefereeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RefereeId");

                    b.ToTable("Referees");
                });

            modelBuilder.Entity("_2024_25_Süper_Lig_Kit.WebApi.Entities.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamId"));

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("_2024_25_Süper_Lig_Kit.WebApi.Entities.Jersey", b =>
                {
                    b.HasOne("_2024_25_Süper_Lig_Kit.WebApi.Entities.Team", "Team")
                        .WithMany("Jerseys")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("_2024_25_Süper_Lig_Kit.WebApi.Entities.JerseyImage", b =>
                {
                    b.HasOne("_2024_25_Süper_Lig_Kit.WebApi.Entities.Jersey", "Jersey")
                        .WithMany("JerseyImages")
                        .HasForeignKey("JerseyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Jersey");
                });

            modelBuilder.Entity("_2024_25_Süper_Lig_Kit.WebApi.Entities.Match", b =>
                {
                    b.HasOne("_2024_25_Süper_Lig_Kit.WebApi.Entities.Team", "AwayTeam")
                        .WithMany("AwayMatches")
                        .HasForeignKey("AwayTeamId")
                        .IsRequired();

                    b.HasOne("_2024_25_Süper_Lig_Kit.WebApi.Entities.JerseyImage", "AwayTeamJerseyImageGK")
                        .WithMany("AwayTeamJerseyImageGKMatches")
                        .HasForeignKey("AwayTeamJerseyImageGKId")
                        .IsRequired();

                    b.HasOne("_2024_25_Süper_Lig_Kit.WebApi.Entities.JerseyImage", "AwayTeamJerseyImage")
                        .WithMany("AwayTeamJerseyImageMatches")
                        .HasForeignKey("AwayTeamJerseyImageId")
                        .IsRequired();

                    b.HasOne("_2024_25_Süper_Lig_Kit.WebApi.Entities.Team", "HomeTeam")
                        .WithMany("HomeMatches")
                        .HasForeignKey("HomeTeamId")
                        .IsRequired();

                    b.HasOne("_2024_25_Süper_Lig_Kit.WebApi.Entities.JerseyImage", "HomeTeamJerseyImageGK")
                        .WithMany("HomeTeamJerseyImageGKMatches")
                        .HasForeignKey("HomeTeamJerseyImageGKId")
                        .IsRequired();

                    b.HasOne("_2024_25_Süper_Lig_Kit.WebApi.Entities.JerseyImage", "HomeTeamJerseyImage")
                        .WithMany("HomeTeamJerseyImageMatches")
                        .HasForeignKey("HomeTeamJerseyImageId")
                        .IsRequired();

                    b.HasOne("_2024_25_Süper_Lig_Kit.WebApi.Entities.Referee", "Referee")
                        .WithMany("Match")
                        .HasForeignKey("RefereeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_2024_25_Süper_Lig_Kit.WebApi.Entities.JerseyImage", "RefereeJerseyImage")
                        .WithMany("RefereeJerseyImageMatches")
                        .HasForeignKey("RefereeJerseyImageId")
                        .IsRequired();

                    b.Navigation("AwayTeam");

                    b.Navigation("AwayTeamJerseyImage");

                    b.Navigation("AwayTeamJerseyImageGK");

                    b.Navigation("HomeTeam");

                    b.Navigation("HomeTeamJerseyImage");

                    b.Navigation("HomeTeamJerseyImageGK");

                    b.Navigation("Referee");

                    b.Navigation("RefereeJerseyImage");
                });

            modelBuilder.Entity("_2024_25_Süper_Lig_Kit.WebApi.Entities.Jersey", b =>
                {
                    b.Navigation("JerseyImages");
                });

            modelBuilder.Entity("_2024_25_Süper_Lig_Kit.WebApi.Entities.JerseyImage", b =>
                {
                    b.Navigation("AwayTeamJerseyImageGKMatches");

                    b.Navigation("AwayTeamJerseyImageMatches");

                    b.Navigation("HomeTeamJerseyImageGKMatches");

                    b.Navigation("HomeTeamJerseyImageMatches");

                    b.Navigation("RefereeJerseyImageMatches");
                });

            modelBuilder.Entity("_2024_25_Süper_Lig_Kit.WebApi.Entities.Referee", b =>
                {
                    b.Navigation("Match");
                });

            modelBuilder.Entity("_2024_25_Süper_Lig_Kit.WebApi.Entities.Team", b =>
                {
                    b.Navigation("AwayMatches");

                    b.Navigation("HomeMatches");

                    b.Navigation("Jerseys");
                });
#pragma warning restore 612, 618
        }
    }
}

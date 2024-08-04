﻿// <auto-generated />
using System;
using EntityFramework.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EntityFramework.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240726174457_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EntityFramework.Models.Nation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("nations");
                });

            modelBuilder.Entity("EntityFramework.Models.NationPoints", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("NationId")
                        .HasColumnType("integer")
                        .HasColumnName("nation_id");

                    b.Property<int>("Points")
                        .HasColumnType("integer")
                        .HasColumnName("points");

                    b.HasKey("Id");

                    b.HasIndex("NationId");

                    b.ToTable("nation_points");
                });

            modelBuilder.Entity("EntityFramework.Models.NationRankingEachYear", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("NationId")
                        .HasColumnType("integer")
                        .HasColumnName("nation_id");

                    b.Property<int>("NumberOfResults")
                        .HasColumnType("integer")
                        .HasColumnName("number_of_results");

                    b.Property<int?>("Placement")
                        .HasColumnType("integer")
                        .HasColumnName("placement");

                    b.Property<int?>("Points")
                        .HasColumnType("integer")
                        .HasColumnName("points");

                    b.Property<int>("Year")
                        .HasColumnType("integer")
                        .HasColumnName("year");

                    b.HasKey("Id");

                    b.HasIndex("NationId");

                    b.ToTable("nation_rankings_each_year");
                });

            modelBuilder.Entity("EntityFramework.Models.NationRankingEachYearAccumulated", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("NationId")
                        .HasColumnType("integer")
                        .HasColumnName("nation_id");

                    b.Property<int>("NumberOfResults")
                        .HasColumnType("integer")
                        .HasColumnName("number_of_results");

                    b.Property<int?>("Placement")
                        .HasColumnType("integer")
                        .HasColumnName("placement");

                    b.Property<int?>("Points")
                        .HasColumnType("integer")
                        .HasColumnName("points");

                    b.Property<int>("Year")
                        .HasColumnType("integer")
                        .HasColumnName("year");

                    b.HasKey("Id");

                    b.HasIndex("NationId");

                    b.ToTable("nation_rankings_each_year_accumulated");
                });

            modelBuilder.Entity("EntityFramework.Models.PointSystem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Points")
                        .HasColumnType("integer")
                        .HasColumnName("points");

                    b.Property<int>("RaceClassificationId")
                        .HasColumnType("integer")
                        .HasColumnName("race_classification_id");

                    b.Property<string>("ResultType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("result_type");

                    b.HasKey("Id");

                    b.HasIndex("RaceClassificationId");

                    b.ToTable("point_system");
                });

            modelBuilder.Entity("EntityFramework.Models.PreviousNationalities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("EndYear")
                        .HasMaxLength(4)
                        .HasColumnType("integer")
                        .HasColumnName("end_year");

                    b.Property<int>("NationId")
                        .HasColumnType("integer")
                        .HasColumnName("nation_id");

                    b.Property<int>("RiderId")
                        .HasColumnType("integer")
                        .HasColumnName("rider_id");

                    b.Property<int?>("StartYear")
                        .HasMaxLength(4)
                        .HasColumnType("integer")
                        .HasColumnName("start_year");

                    b.HasKey("Id");

                    b.HasIndex("NationId");

                    b.HasIndex("RiderId");

                    b.ToTable("previous_nationalities");
                });

            modelBuilder.Entity("EntityFramework.Models.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean")
                        .HasColumnName("active");

                    b.Property<string>("ActiveSpan")
                        .HasColumnType("text")
                        .HasColumnName("active_span");

                    b.Property<string>("ColorHex")
                        .HasMaxLength(6)
                        .HasColumnType("character varying(6)")
                        .HasColumnName("color_hex");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int?>("NationId")
                        .HasColumnType("integer")
                        .HasColumnName("nation_id");

                    b.Property<int>("RaceClassificationId")
                        .HasColumnType("integer")
                        .HasColumnName("race_classification_id");

                    b.HasKey("Id");

                    b.HasIndex("NationId");

                    b.HasIndex("RaceClassificationId");

                    b.ToTable("races");
                });

            modelBuilder.Entity("EntityFramework.Models.RaceCalendar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end_date");

                    b.Property<int>("RaceId")
                        .HasColumnType("integer")
                        .HasColumnName("race_id");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_date");

                    b.HasKey("Id");

                    b.HasIndex("RaceId");

                    b.ToTable("race_calendar");
                });

            modelBuilder.Entity("EntityFramework.Models.RaceClassification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("race_classifications");
                });

            modelBuilder.Entity("EntityFramework.Models.RaceDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date");

                    b.Property<int>("RaceId")
                        .HasColumnType("integer")
                        .HasColumnName("race_id");

                    b.Property<int?>("Stage")
                        .HasColumnType("integer")
                        .HasColumnName("stage");

                    b.HasKey("Id");

                    b.HasIndex("RaceId");

                    b.ToTable("race_dates");
                });

            modelBuilder.Entity("EntityFramework.Models.Result", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("Placement")
                        .HasColumnType("integer")
                        .HasColumnName("placement");

                    b.Property<int?>("RaceDateId")
                        .HasColumnType("integer")
                        .HasColumnName("race_date_id");

                    b.Property<int>("RaceId")
                        .HasColumnType("integer")
                        .HasColumnName("race_id");

                    b.Property<string>("ResultType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("result_type");

                    b.Property<int>("RiderId")
                        .HasColumnType("integer")
                        .HasColumnName("rider_id");

                    b.HasKey("Id");

                    b.HasIndex("RaceDateId");

                    b.HasIndex("RaceId");

                    b.HasIndex("RiderId");

                    b.ToTable("results");
                });

            modelBuilder.Entity("EntityFramework.Models.Rider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean")
                        .HasColumnName("active");

                    b.Property<int?>("BirthYear")
                        .HasColumnType("integer")
                        .HasColumnName("birth_year");

                    b.Property<string>("FirstName")
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<int>("NationId")
                        .HasColumnType("integer")
                        .HasColumnName("nation_id");

                    b.Property<int?>("TeamId")
                        .HasColumnType("integer")
                        .HasColumnName("team_id");

                    b.HasKey("Id");

                    b.HasIndex("NationId");

                    b.HasIndex("TeamId");

                    b.ToTable("riders");
                });

            modelBuilder.Entity("EntityFramework.Models.RiderPoints", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Points")
                        .HasColumnType("integer")
                        .HasColumnName("points");

                    b.Property<int>("RiderId")
                        .HasColumnType("integer")
                        .HasColumnName("rider_id");

                    b.HasKey("Id");

                    b.HasIndex("RiderId");

                    b.ToTable("rider_points");
                });

            modelBuilder.Entity("EntityFramework.Models.RiderRanking3YearSpan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("EndYear")
                        .HasColumnType("integer")
                        .HasColumnName("end_year");

                    b.Property<int?>("Placement")
                        .HasColumnType("integer")
                        .HasColumnName("placement");

                    b.Property<int?>("Points")
                        .HasColumnType("integer")
                        .HasColumnName("points");

                    b.Property<int>("RiderId")
                        .HasColumnType("integer")
                        .HasColumnName("rider_id");

                    b.Property<int>("StartYear")
                        .HasColumnType("integer")
                        .HasColumnName("start_year");

                    b.HasKey("Id");

                    b.HasIndex("RiderId");

                    b.ToTable("rider_rankings_3_year_span");
                });

            modelBuilder.Entity("EntityFramework.Models.RiderRankingEachDecade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Decade")
                        .HasColumnType("integer")
                        .HasColumnName("decade");

                    b.Property<int?>("Placement")
                        .HasColumnType("integer")
                        .HasColumnName("placement");

                    b.Property<int?>("Points")
                        .HasColumnType("integer")
                        .HasColumnName("points");

                    b.Property<int>("RiderId")
                        .HasColumnType("integer")
                        .HasColumnName("rider_id");

                    b.HasKey("Id");

                    b.HasIndex("RiderId");

                    b.ToTable("rider_rankings_each_decade");
                });

            modelBuilder.Entity("EntityFramework.Models.RiderRankingEachYear", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("Placement")
                        .HasColumnType("integer")
                        .HasColumnName("placement");

                    b.Property<int?>("Points")
                        .HasColumnType("integer")
                        .HasColumnName("points");

                    b.Property<int>("RiderId")
                        .HasColumnType("integer")
                        .HasColumnName("rider_id");

                    b.Property<int>("Year")
                        .HasColumnType("integer")
                        .HasColumnName("year");

                    b.HasKey("Id");

                    b.HasIndex("RiderId");

                    b.ToTable("rider_rankings_each_year");
                });

            modelBuilder.Entity("EntityFramework.Models.RiderRankingEachYearAccumulated", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("Placement")
                        .HasColumnType("integer")
                        .HasColumnName("placement");

                    b.Property<int>("Points")
                        .HasColumnType("integer")
                        .HasColumnName("points");

                    b.Property<int>("RiderId")
                        .HasColumnType("integer")
                        .HasColumnName("rider_id");

                    b.Property<int>("Year")
                        .HasColumnType("integer")
                        .HasColumnName("year");

                    b.HasKey("Id");

                    b.HasIndex("RiderId");

                    b.ToTable("rider_rankings_each_year_accumulated");
                });

            modelBuilder.Entity("EntityFramework.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("teams");
                });

            modelBuilder.Entity("EntityFramework.Models.NationPoints", b =>
                {
                    b.HasOne("EntityFramework.Models.Nation", "Nation")
                        .WithMany()
                        .HasForeignKey("NationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nation");
                });

            modelBuilder.Entity("EntityFramework.Models.NationRankingEachYear", b =>
                {
                    b.HasOne("EntityFramework.Models.Nation", "Nation")
                        .WithMany()
                        .HasForeignKey("NationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nation");
                });

            modelBuilder.Entity("EntityFramework.Models.NationRankingEachYearAccumulated", b =>
                {
                    b.HasOne("EntityFramework.Models.Nation", "Nation")
                        .WithMany()
                        .HasForeignKey("NationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nation");
                });

            modelBuilder.Entity("EntityFramework.Models.PointSystem", b =>
                {
                    b.HasOne("EntityFramework.Models.RaceClassification", "RaceClassification")
                        .WithMany()
                        .HasForeignKey("RaceClassificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RaceClassification");
                });

            modelBuilder.Entity("EntityFramework.Models.PreviousNationalities", b =>
                {
                    b.HasOne("EntityFramework.Models.Nation", "Nation")
                        .WithMany()
                        .HasForeignKey("NationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFramework.Models.Rider", "Rider")
                        .WithMany()
                        .HasForeignKey("RiderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nation");

                    b.Navigation("Rider");
                });

            modelBuilder.Entity("EntityFramework.Models.Race", b =>
                {
                    b.HasOne("EntityFramework.Models.Nation", "Nation")
                        .WithMany()
                        .HasForeignKey("NationId");

                    b.HasOne("EntityFramework.Models.RaceClassification", "RaceClassification")
                        .WithMany()
                        .HasForeignKey("RaceClassificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nation");

                    b.Navigation("RaceClassification");
                });

            modelBuilder.Entity("EntityFramework.Models.RaceCalendar", b =>
                {
                    b.HasOne("EntityFramework.Models.Race", "Race")
                        .WithMany()
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Race");
                });

            modelBuilder.Entity("EntityFramework.Models.RaceDate", b =>
                {
                    b.HasOne("EntityFramework.Models.Race", "Race")
                        .WithMany()
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Race");
                });

            modelBuilder.Entity("EntityFramework.Models.Result", b =>
                {
                    b.HasOne("EntityFramework.Models.RaceDate", "RaceDate")
                        .WithMany()
                        .HasForeignKey("RaceDateId");

                    b.HasOne("EntityFramework.Models.Race", "Race")
                        .WithMany()
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFramework.Models.Rider", "Rider")
                        .WithMany()
                        .HasForeignKey("RiderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Race");

                    b.Navigation("RaceDate");

                    b.Navigation("Rider");
                });

            modelBuilder.Entity("EntityFramework.Models.Rider", b =>
                {
                    b.HasOne("EntityFramework.Models.Nation", "Nation")
                        .WithMany()
                        .HasForeignKey("NationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFramework.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId");

                    b.Navigation("Nation");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("EntityFramework.Models.RiderPoints", b =>
                {
                    b.HasOne("EntityFramework.Models.Rider", "Rider")
                        .WithMany()
                        .HasForeignKey("RiderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rider");
                });

            modelBuilder.Entity("EntityFramework.Models.RiderRanking3YearSpan", b =>
                {
                    b.HasOne("EntityFramework.Models.Rider", "Rider")
                        .WithMany()
                        .HasForeignKey("RiderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rider");
                });

            modelBuilder.Entity("EntityFramework.Models.RiderRankingEachDecade", b =>
                {
                    b.HasOne("EntityFramework.Models.Rider", "Rider")
                        .WithMany()
                        .HasForeignKey("RiderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rider");
                });

            modelBuilder.Entity("EntityFramework.Models.RiderRankingEachYear", b =>
                {
                    b.HasOne("EntityFramework.Models.Rider", "Rider")
                        .WithMany()
                        .HasForeignKey("RiderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rider");
                });

            modelBuilder.Entity("EntityFramework.Models.RiderRankingEachYearAccumulated", b =>
                {
                    b.HasOne("EntityFramework.Models.Rider", "Rider")
                        .WithMany()
                        .HasForeignKey("RiderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rider");
                });
#pragma warning restore 612, 618
        }
    }
}
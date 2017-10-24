﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Regions.WebApi.Infrastructure;
using System;

namespace Regions.WebApi.Migrations
{
    [DbContext(typeof(RegionsContext))]
    [Migration("20171018203659_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("Regions.WebApi.Models.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("area_id");

                    b.Property<string>("Name")
                        .HasColumnName("area_name")
                        .HasMaxLength(30);

                    b.Property<int>("RegionId")
                        .HasColumnName("region_id");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("areas");
                });

            modelBuilder.Entity("Regions.WebApi.Models.Locality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("locality_id");

                    b.Property<int>("AreaId")
                        .HasColumnName("area_id");

                    b.Property<string>("Name")
                        .HasColumnName("locality_name")
                        .HasMaxLength(30);

                    b.Property<int>("Population")
                        .HasColumnName("locality_population");

                    b.Property<string>("Type")
                        .HasColumnName("locality_type")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.ToTable("localities");
                });

            modelBuilder.Entity("Regions.WebApi.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("region_id");

                    b.Property<string>("Capital")
                        .IsRequired()
                        .HasColumnName("region_capital")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("region_name")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("regions");
                });

            modelBuilder.Entity("Regions.WebApi.Models.Area", b =>
                {
                    b.HasOne("Regions.WebApi.Models.Region", "Region")
                        .WithMany("Areas")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Regions.WebApi.Models.Locality", b =>
                {
                    b.HasOne("Regions.WebApi.Models.Area", "Area")
                        .WithMany("Localities")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
﻿// <auto-generated />
using System;
using GunDetection.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GunDetection.Data.Migrations
{
    [DbContext(typeof(GunDbContext))]
    [Migration("20210603212542_siete")]
    partial class siete
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GunDetection.Models.Camera", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdLocation")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdSubLocation")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdLocation");

                    b.HasIndex("IdSubLocation");

                    b.ToTable("Cameras");
                });

            modelBuilder.Entity("GunDetection.Models.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("GunDetection.Models.SubLocation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdLocation")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdLocation");

                    b.ToTable("SubLocations");
                });

            modelBuilder.Entity("GunDetection.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Activate")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GunDetection.Models.Camera", b =>
                {
                    b.HasOne("GunDetection.Models.Location", null)
                        .WithMany("Cameras")
                        .HasForeignKey("IdLocation")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GunDetection.Models.SubLocation", null)
                        .WithMany("Cameras")
                        .HasForeignKey("IdSubLocation")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GunDetection.Models.Location", b =>
                {
                    b.HasOne("GunDetection.Models.User", null)
                        .WithMany("Locations")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GunDetection.Models.SubLocation", b =>
                {
                    b.HasOne("GunDetection.Models.Location", null)
                        .WithMany("SubLocations")
                        .HasForeignKey("IdLocation")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GunDetection.Models.Location", b =>
                {
                    b.Navigation("Cameras");

                    b.Navigation("SubLocations");
                });

            modelBuilder.Entity("GunDetection.Models.SubLocation", b =>
                {
                    b.Navigation("Cameras");
                });

            modelBuilder.Entity("GunDetection.Models.User", b =>
                {
                    b.Navigation("Locations");
                });
#pragma warning restore 612, 618
        }
    }
}

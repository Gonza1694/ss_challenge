﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpeedSolutionsChallenge.Data.DBContext;

#nullable disable

namespace SpeedSolutionsChallenge.Data.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20240131220451_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SpeedSolutionsChallenge.Data.Models.Dispenser", b =>
                {
                    b.Property<int>("DispenserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DispenserId"));

                    b.Property<int>("HoseCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DispenserId");

                    b.ToTable("Dispensers");
                });

            modelBuilder.Entity("SpeedSolutionsChallenge.Data.Models.Hose", b =>
                {
                    b.Property<int>("HoseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HoseId"));

                    b.Property<int>("DispenserId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("HoseId");

                    b.HasIndex("DispenserId");

                    b.HasIndex("ProductId");

                    b.ToTable("Hoses");
                });

            modelBuilder.Entity("SpeedSolutionsChallenge.Data.Models.Price", b =>
                {
                    b.Property<int>("PriceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PriceId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PriceId");

                    b.HasIndex("ProductId");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("SpeedSolutionsChallenge.Data.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("DispenserId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("Unit")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("DispenserId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SpeedSolutionsChallenge.Data.Models.Hose", b =>
                {
                    b.HasOne("SpeedSolutionsChallenge.Data.Models.Dispenser", "Dispenser")
                        .WithMany("Hoses")
                        .HasForeignKey("DispenserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SpeedSolutionsChallenge.Data.Models.Product", "Product")
                        .WithMany("Hoses")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Dispenser");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SpeedSolutionsChallenge.Data.Models.Price", b =>
                {
                    b.HasOne("SpeedSolutionsChallenge.Data.Models.Product", "Product")
                        .WithMany("Prices")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SpeedSolutionsChallenge.Data.Models.Product", b =>
                {
                    b.HasOne("SpeedSolutionsChallenge.Data.Models.Dispenser", "Dispenser")
                        .WithMany()
                        .HasForeignKey("DispenserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dispenser");
                });

            modelBuilder.Entity("SpeedSolutionsChallenge.Data.Models.Dispenser", b =>
                {
                    b.Navigation("Hoses");
                });

            modelBuilder.Entity("SpeedSolutionsChallenge.Data.Models.Product", b =>
                {
                    b.Navigation("Hoses");

                    b.Navigation("Prices");
                });
#pragma warning restore 612, 618
        }
    }
}

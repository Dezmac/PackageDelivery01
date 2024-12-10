﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PackageDelivery01.Data;


#nullable disable

namespace PackageDelivery01.Migrations
{
    [DbContext(typeof(PackageDeliveryContext))]
    [Migration("20241209170757_FixCustomerTableName")]
    partial class FixCustomerTableName
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("PackageDelivery01.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CustomerID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("PackageDelivery01.Models.Package", b =>
                {
                    b.Property<int>("PackageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("PackageID"));

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<int?>("ServiceID")
                        .HasColumnType("int");

                    b.Property<string>("ServiceType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("TruckID")
                        .HasColumnType("int");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("PackageID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("ServiceID");

                    b.HasIndex("TruckID");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("PackageDelivery01.Models.Services", b =>
                {
                    b.Property<int>("ServiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ServiceID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<decimal>("PricePerKg")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("ServiceType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("ServiceID");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("PackageDelivery01.Models.Tracking", b =>
                {
                    b.Property<int>("TrackingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("TrackingID"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("PackageID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("TruckID")
                        .HasColumnType("int");

                    b.Property<int?>("TruckID1")
                        .HasColumnType("int");

                    b.HasKey("TrackingID");

                    b.HasIndex("PackageID");

                    b.HasIndex("TruckID");

                    b.HasIndex("TruckID1");

                    b.ToTable("Trackings");
                });

            modelBuilder.Entity("PackageDelivery01.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("TransactionID"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<int>("PackageID")
                        .HasColumnType("int");

                    b.HasKey("TransactionID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("PackageID");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("PackageDelivery01.Models.Truck", b =>
                {
                    b.Property<int>("TruckID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("TruckID"));

                    b.Property<decimal>("Capacity")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("DriverName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("TruckID");

                    b.ToTable("Trucks");
                });

            modelBuilder.Entity("PackageDelivery01.Models.Package", b =>
                {
                    b.HasOne("PackageDelivery01.Models.Customer", "Customer")
                        .WithMany("Packages")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PackageDelivery01.Models.Services", "Services")
                        .WithMany("Packages")
                        .HasForeignKey("ServiceID");

                    b.HasOne("PackageDelivery01.Models.Truck", "Truck")
                        .WithMany()
                        .HasForeignKey("TruckID");

                    b.Navigation("Customer");

                    b.Navigation("Services");

                    b.Navigation("Truck");
                });

            modelBuilder.Entity("PackageDelivery01.Models.Tracking", b =>
                {
                    b.HasOne("PackageDelivery01.Models.Package", "Package")
                        .WithMany("Trackings")
                        .HasForeignKey("PackageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PackageDelivery01.Models.Truck", "Truck")
                        .WithMany()
                        .HasForeignKey("TruckID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("PackageDelivery01.Models.Truck", null)
                        .WithMany("Trackings")
                        .HasForeignKey("TruckID1");

                    b.Navigation("Package");

                    b.Navigation("Truck");
                });

            modelBuilder.Entity("PackageDelivery01.Models.Transaction", b =>
                {
                    b.HasOne("PackageDelivery01.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PackageDelivery01.Models.Package", "Package")
                        .WithMany()
                        .HasForeignKey("PackageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Package");
                });

            modelBuilder.Entity("PackageDelivery01.Models.Customer", b =>
                {
                    b.Navigation("Packages");
                });

            modelBuilder.Entity("PackageDelivery01.Models.Package", b =>
                {
                    b.Navigation("Trackings");
                });

            modelBuilder.Entity("PackageDelivery01.Models.Services", b =>
                {
                    b.Navigation("Packages");
                });

            modelBuilder.Entity("PackageDelivery01.Models.Truck", b =>
                {
                    b.Navigation("Trackings");
                });
#pragma warning restore 612, 618
        }
    }
}
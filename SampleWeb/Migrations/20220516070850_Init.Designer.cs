﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace SampleWeb.Migrations
{
    [DbContext(typeof(SampleDbContext))]
    [Migration("20220516070850_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Company", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Employee", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Employee", b =>
                {
                    b.HasOne("Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("OrderDetail", b =>
                {
                    b.OwnsOne("StreetAddress", "BillingAddress", b1 =>
                        {
                            b1.Property<int>("OrderDetailId")
                                .HasColumnType("int");

                            b1.Property<string>("AddressLine1")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("AddressLine2")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("AreaCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("OrderDetailId");

                            b1.ToTable("OrderDetails");

                            b1.WithOwner()
                                .HasForeignKey("OrderDetailId");
                        });

                    b.OwnsOne("StreetAddress", "ShippingAddress", b1 =>
                        {
                            b1.Property<int>("OrderDetailId")
                                .HasColumnType("int");

                            b1.Property<string>("AddressLine1")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("AddressLine2")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("AreaCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("OrderDetailId");

                            b1.ToTable("OrderDetails");

                            b1.WithOwner()
                                .HasForeignKey("OrderDetailId");
                        });

                    b.Navigation("BillingAddress")
                        .IsRequired();

                    b.Navigation("ShippingAddress")
                        .IsRequired();
                });

            modelBuilder.Entity("Company", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}

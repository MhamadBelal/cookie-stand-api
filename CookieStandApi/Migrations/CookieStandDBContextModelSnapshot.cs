﻿// <auto-generated />
using CookieStandApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CookieStandApi.Migrations
{
    [DbContext(typeof(CookieStandDBContext))]
    partial class CookieStandDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CookieStandApi.Models.CookieStand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("AverageCookiesPerSale")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaximumCustomersPerHour")
                        .HasColumnType("int");

                    b.Property<int>("MinimumCustomersPerHour")
                        .HasColumnType("int");

                    b.Property<string>("Owner")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CookieStands");
                });

            modelBuilder.Entity("CookieStandApi.Models.HourlySale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CookieStandId")
                        .HasColumnType("int");

                    b.Property<int>("SaleValue")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CookieStandId");

                    b.ToTable("hourlySales");
                });

            modelBuilder.Entity("CookieStandApi.Models.HourlySale", b =>
                {
                    b.HasOne("CookieStandApi.Models.CookieStand", "CookieStand")
                        .WithMany("hourlySale")
                        .HasForeignKey("CookieStandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CookieStand");
                });

            modelBuilder.Entity("CookieStandApi.Models.CookieStand", b =>
                {
                    b.Navigation("hourlySale");
                });
#pragma warning restore 612, 618
        }
    }
}
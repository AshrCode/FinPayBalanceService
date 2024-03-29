﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.DatabaseSchema;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(FinPayBalanceDbContext))]
    [Migration("20240221174442_Added Seed Data")]
    partial class AddedSeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.UserAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("UserAccounts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b136cf3d-766b-45ae-aa84-ac7f10c5a090"),
                            Balance = 5000.0,
                            Currency = "AED"
                        },
                        new
                        {
                            Id = new Guid("6751304e-0eea-443c-ad6a-dfbbf53731fe"),
                            Balance = 700.0,
                            Currency = "AED"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

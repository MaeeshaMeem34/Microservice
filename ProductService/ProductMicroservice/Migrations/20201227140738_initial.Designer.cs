﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductMicroservice.Database;

namespace ProductMicroservice.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20201227140738_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("ProductMicroservice.Database.Entities.Category", b =>
                {
                    b.Property<Guid>("categoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("categoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("categoryId");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("ProductMicroservice.Database.Entities.Product", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("averageRating")
                        .HasColumnType("real");

                    b.Property<Guid>("categoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("categoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("numberOfRaters")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("name")
                        .IsUnique()
                        .HasFilter("[name] IS NOT NULL");

                    b.ToTable("products");
                });
#pragma warning restore 612, 618
        }
    }
}
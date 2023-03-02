﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using XTI_CopiaDB;

#nullable disable

namespace XTI_CopiaDB.SqlServer.Migrations
{
    [DbContext(typeof(CopiaDbContext))]
    [Migration("20221022173316_Initial02")]
    partial class Initial02
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("XTI_CopiaDB.PortfolioEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("PortfolioName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTimeOffset>("TimeAdded")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("ID");

                    b.ToTable("Portfolios", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
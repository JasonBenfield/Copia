﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using XTI_CopiaDB;

#nullable disable

namespace XTICopiaDB.SqlServer.Migrations
{
    [DbContext(typeof(CopiaDbContext))]
    partial class CopiaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("XTI_CopiaDB.AccountEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("AccountType")
                        .HasColumnType("int");

                    b.Property<int>("PortfolioID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PortfolioID");

                    b.ToTable("Accounts", (string)null);
                });

            modelBuilder.Entity("XTI_CopiaDB.ActivityTemplateEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ActivityNameTemplateStringID")
                        .HasColumnType("int");

                    b.Property<int>("PortfolioID")
                        .HasColumnType("int");

                    b.Property<string>("TemplateName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.HasIndex("PortfolioID");

                    b.ToTable("ActivityTemplates", (string)null);
                });

            modelBuilder.Entity("XTI_CopiaDB.ActivityTemplateFieldEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Accessibility")
                        .HasColumnType("int");

                    b.Property<string>("FieldCaption")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("FieldType")
                        .HasColumnType("int");

                    b.Property<int>("TemplateID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TemplateID");

                    b.ToTable("ActivityTemplateFields", (string)null);
                });

            modelBuilder.Entity("XTI_CopiaDB.CounterpartyEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("DisplayText")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("PortfolioID")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("ID");

                    b.HasIndex("PortfolioID");

                    b.ToTable("Couterparties", (string)null);
                });

            modelBuilder.Entity("XTI_CopiaDB.PortfolioEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("PortfolioName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTimeOffset>("TimeAdded")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("ID");

                    b.ToTable("Portfolios", (string)null);
                });

            modelBuilder.Entity("XTI_CopiaDB.TemplateStringEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("CanEdit")
                        .HasColumnType("bit");

                    b.Property<int>("DataType")
                        .HasColumnType("int");

                    b.Property<int>("PortfolioID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PortfolioID");

                    b.ToTable("TemplateStrings", (string)null);
                });

            modelBuilder.Entity("XTI_CopiaDB.TemplateStringPartEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ArrayIndex")
                        .HasColumnType("int");

                    b.Property<int>("ArrayType")
                        .HasColumnType("int");

                    b.Property<int>("FieldType")
                        .HasColumnType("int");

                    b.Property<string>("FixedText")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("PartType")
                        .HasColumnType("int");

                    b.Property<int>("Sequence")
                        .HasColumnType("int");

                    b.Property<int>("TemplateStringID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TemplateStringID", "Sequence")
                        .IsUnique();

                    b.ToTable("TemplateStringParts", (string)null);
                });

            modelBuilder.Entity("XTI_CopiaDB.AccountEntity", b =>
                {
                    b.HasOne("XTI_CopiaDB.PortfolioEntity", null)
                        .WithMany()
                        .HasForeignKey("PortfolioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("XTI_CopiaDB.ActivityTemplateEntity", b =>
                {
                    b.HasOne("XTI_CopiaDB.PortfolioEntity", null)
                        .WithMany()
                        .HasForeignKey("PortfolioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("XTI_CopiaDB.ActivityTemplateFieldEntity", b =>
                {
                    b.HasOne("XTI_CopiaDB.ActivityTemplateEntity", null)
                        .WithMany()
                        .HasForeignKey("TemplateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("XTI_CopiaDB.CounterpartyEntity", b =>
                {
                    b.HasOne("XTI_CopiaDB.PortfolioEntity", null)
                        .WithMany()
                        .HasForeignKey("PortfolioID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("XTI_CopiaDB.TemplateStringEntity", b =>
                {
                    b.HasOne("XTI_CopiaDB.PortfolioEntity", null)
                        .WithMany()
                        .HasForeignKey("PortfolioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("XTI_CopiaDB.TemplateStringPartEntity", b =>
                {
                    b.HasOne("XTI_CopiaDB.TemplateStringEntity", null)
                        .WithMany()
                        .HasForeignKey("TemplateStringID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

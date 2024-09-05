﻿// <auto-generated />
using System;
using JournalScrapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JournalScrapper.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240827002536_addFixJournals")]
    partial class addFixJournals
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JournalScrapper.Entity+Atricles", b =>
                {
                    b.Property<int>("Articles_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Articles_Id"));

                    b.Property<string>("Abstract_En")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Abstract_Fa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Issue_Id")
                        .HasColumnType("int");

                    b.Property<string>("Title_EN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title_Fa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Articles_Id");

                    b.ToTable("Atricles");
                });

            modelBuilder.Entity("JournalScrapper.Entity+Journal", b =>
                {
                    b.Property<int>("Journal_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Journal_id"));

                    b.Property<bool>("AzadJournal")
                        .HasColumnType("bit");

                    b.Property<string>("EISSN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HozeJournal")
                        .HasColumnType("bit");

                    b.Property<string>("ISSN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("MedicalJournal")
                        .HasColumnType("bit");

                    b.Property<bool>("Msrt")
                        .HasColumnType("bit");

                    b.Property<int>("SubGroupId")
                        .HasColumnType("int");

                    b.Property<string>("SubGroupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title_EN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title_Fa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Journal_id");

                    b.ToTable("Journals");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MonsterHunterBE.Data;

#nullable disable

namespace MonsterHunterBE.Migrations
{
    [DbContext(typeof(MonsterHunterContex))]
    [Migration("20230619080431_New-Migration")]
    partial class NewMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MonsterHunterBE.Model.Monster.Monster", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrls")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Monsters");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Monster");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("MonsterHunterBE.Model.MonsterDrop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DropRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("MonsterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MonsterId");

                    b.ToTable("MonsterDrops");
                });

            modelBuilder.Entity("MonsterHunterBE.Model.MonsterWeakness", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MonsterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("WeaknessPerc")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("MonsterId");

                    b.ToTable("MonsterWeaknesses");
                });

            modelBuilder.Entity("MonsterHunterBE.Model.Monster.RareSpecies", b =>
                {
                    b.HasBaseType("MonsterHunterBE.Model.Monster.Monster");

                    b.Property<string>("RareDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RareImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RareName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("RareSpecies");
                });

            modelBuilder.Entity("MonsterHunterBE.Model.Monster.SubSpecies", b =>
                {
                    b.HasBaseType("MonsterHunterBE.Model.Monster.Monster");

                    b.Property<string>("SubDescriptiion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("SubSpecies");
                });

            modelBuilder.Entity("MonsterHunterBE.Model.MonsterDrop", b =>
                {
                    b.HasOne("MonsterHunterBE.Model.Monster.Monster", null)
                        .WithMany("Drop")
                        .HasForeignKey("MonsterId");
                });

            modelBuilder.Entity("MonsterHunterBE.Model.MonsterWeakness", b =>
                {
                    b.HasOne("MonsterHunterBE.Model.Monster.Monster", null)
                        .WithMany("Weakness")
                        .HasForeignKey("MonsterId");
                });

            modelBuilder.Entity("MonsterHunterBE.Model.Monster.Monster", b =>
                {
                    b.Navigation("Drop");

                    b.Navigation("Weakness");
                });
#pragma warning restore 612, 618
        }
    }
}

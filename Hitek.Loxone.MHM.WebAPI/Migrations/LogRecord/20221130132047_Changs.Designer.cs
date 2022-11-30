﻿// <auto-generated />
using System;
using Hitek.Loxone.MHM.WebAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hitek.Loxone.MHM.WebAPI.Migrations.LogRecord
{
    [DbContext(typeof(LogRecordContext))]
    [Migration("20221130132047_Changs")]
    partial class Changs
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hitek.Loxone.MHM.Shared.Models.LogRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmployeeID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LogType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("LogRecords");
                });
#pragma warning restore 612, 618
        }
    }
}

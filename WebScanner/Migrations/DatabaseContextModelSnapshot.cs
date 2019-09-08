﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebScanner.Models.Database;

namespace WebScanner.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("WebScanner.Models.HtmlOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("Frequency")
                        .HasColumnName("frequency");

                    b.Property<string>("SubjectOfQuestion")
                        .HasColumnName("subject_of_question");

                    b.Property<string>("TargetAddress")
                        .HasColumnName("target_address");

                    b.HasKey("Id")
                        .HasName("pk_html_orders");

                    b.ToTable("html_orders");
                });

            modelBuilder.Entity("WebScanner.Models.Response", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Content")
                        .HasColumnName("content");

                    b.Property<DateTime>("Date")
                        .HasColumnName("date");

                    b.Property<int>("OrderId")
                        .HasColumnName("order_id");

                    b.Property<string>("Type")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("pk_responses");

                    b.ToTable("responses");
                });

            modelBuilder.Entity("WebScanner.Models.ServerOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("Frequency")
                        .HasColumnName("frequency");

                    b.Property<string>("Question")
                        .HasColumnName("question");

                    b.Property<string>("TargetAddress")
                        .HasColumnName("target_address");

                    b.HasKey("Id")
                        .HasName("pk_server_orders");

                    b.ToTable("server_orders");
                });
#pragma warning restore 612, 618
        }
    }
}

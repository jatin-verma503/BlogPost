﻿// <auto-generated />
using System;
using BlogPostApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlogPostApp.Migrations
{
    [DbContext(typeof(BlogPostAppDbContext))]
    partial class BlogPostAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlogPostApp.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 0,
                            Name = "Test"
                        },
                        new
                        {
                            Id = 2,
                            Age = 0,
                            Name = "Jeffery Achher"
                        },
                        new
                        {
                            Id = 3,
                            Age = 0,
                            Name = "Chetan Bhagat"
                        },
                        new
                        {
                            Id = 4,
                            Age = 0,
                            Name = "Jane Doe"
                        },
                        new
                        {
                            Id = 5,
                            Age = 0,
                            Name = "John Smith"
                        },
                        new
                        {
                            Id = 6,
                            Age = 0,
                            Name = "Emily Johnson"
                        },
                        new
                        {
                            Id = 7,
                            Age = 0,
                            Name = "Michael Brown"
                        },
                        new
                        {
                            Id = 8,
                            Age = 0,
                            Name = "Sophia Williams"
                        },
                        new
                        {
                            Id = 9,
                            Age = 0,
                            Name = "William Jones"
                        },
                        new
                        {
                            Id = 10,
                            Age = 0,
                            Name = "Olivia Garcia"
                        });
                });

            modelBuilder.Entity("BlogPostApp.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Test Category"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Drama"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Romance"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Science Fiction"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Mystery"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Thriller"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Horror"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Comedy"
                        });
                });

            modelBuilder.Entity("BlogPostApp.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            CategoryId = 1,
                            CreatedOn = new DateTime(2024, 4, 23, 20, 35, 48, 494, DateTimeKind.Local).AddTicks(5018),
                            Description = "This is an introduction.",
                            Title = "Introduction"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 2,
                            CategoryId = 1,
                            CreatedOn = new DateTime(2024, 4, 23, 20, 35, 48, 494, DateTimeKind.Local).AddTicks(5038),
                            Description = "This is an experiment.",
                            Title = "Experiment"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 3,
                            CategoryId = 2,
                            CreatedOn = new DateTime(2024, 4, 23, 20, 35, 48, 494, DateTimeKind.Local).AddTicks(5041),
                            Description = "This is an exploration.",
                            Title = "Exploration"
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 4,
                            CategoryId = 3,
                            CreatedOn = new DateTime(2024, 4, 23, 20, 35, 48, 494, DateTimeKind.Local).AddTicks(5044),
                            Description = "This is an illustration.",
                            Title = "Illustration"
                        },
                        new
                        {
                            Id = 5,
                            AuthorId = 5,
                            CategoryId = 4,
                            CreatedOn = new DateTime(2024, 4, 23, 20, 35, 48, 494, DateTimeKind.Local).AddTicks(5047),
                            Description = "This is a demonstration.",
                            Title = "Demonstration"
                        });
                });

            modelBuilder.Entity("BlogPostApp.Models.Post", b =>
                {
                    b.HasOne("BlogPostApp.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlogPostApp.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}

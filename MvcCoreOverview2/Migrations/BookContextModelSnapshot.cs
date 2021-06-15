﻿// <auto-generated />
using System;
using MVCEFCoreOverview.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MvcCoreOverview2.Migrations
{
    [DbContext(typeof(BookContext))]
    partial class BookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MvcCoreOverview2.Models.Authors", b =>
                {
                    b.Property<int>("Author_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Author_Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("MvcCoreOverview2.Models.Book", b =>
                {
                    b.Property<int>("Books_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Auther")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("AutherFirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("AutherLastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("BookDetailId")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("IsBestSeller")
                        .HasColumnType("bit");

                    b.Property<int>("Pages")
                        .HasColumnType("int");

                    b.Property<int?>("PublisherPubplisherId")
                        .HasColumnType("int");

                    b.Property<int>("PubplisherId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("YearPublished")
                        .HasColumnType("int");

                    b.HasKey("Books_Id");

                    b.HasIndex("BookDetailId")
                        .IsUnique();

                    b.HasIndex("PublisherPubplisherId");

                    b.ToTable("books");
                });

            modelBuilder.Entity("MvcCoreOverview2.Models.BookAuthor", b =>
                {
                    b.Property<int>("Books_Id")
                        .HasColumnType("int");

                    b.Property<int>("Author_Id")
                        .HasColumnType("int");

                    b.HasKey("Books_Id", "Author_Id");

                    b.HasIndex("Author_Id");

                    b.ToTable("BookAuthors");
                });

            modelBuilder.Entity("MvcCoreOverview2.Models.BookDetail", b =>
                {
                    b.Property<int>("BookDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("BookDetailId");

                    b.ToTable("details");
                });

            modelBuilder.Entity("MvcCoreOverview2.Models.Publisher", b =>
                {
                    b.Property<int>("PubplisherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PubplisherId");

                    b.ToTable("publishers");
                });

            modelBuilder.Entity("MvcCoreOverview2.Models.Book", b =>
                {
                    b.HasOne("MvcCoreOverview2.Models.BookDetail", "BookDetail")
                        .WithOne("Book")
                        .HasForeignKey("MvcCoreOverview2.Models.Book", "BookDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MvcCoreOverview2.Models.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherPubplisherId");

                    b.Navigation("BookDetail");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("MvcCoreOverview2.Models.BookAuthor", b =>
                {
                    b.HasOne("MvcCoreOverview2.Models.Authors", "Authors")
                        .WithMany("BookAuthors")
                        .HasForeignKey("Author_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MvcCoreOverview2.Models.Book", "Book")
                        .WithMany("BookAuthors")
                        .HasForeignKey("Books_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Authors");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("MvcCoreOverview2.Models.Authors", b =>
                {
                    b.Navigation("BookAuthors");
                });

            modelBuilder.Entity("MvcCoreOverview2.Models.Book", b =>
                {
                    b.Navigation("BookAuthors");
                });

            modelBuilder.Entity("MvcCoreOverview2.Models.BookDetail", b =>
                {
                    b.Navigation("Book");
                });

            modelBuilder.Entity("MvcCoreOverview2.Models.Publisher", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
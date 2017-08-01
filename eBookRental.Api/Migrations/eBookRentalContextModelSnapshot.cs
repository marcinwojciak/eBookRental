using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using eBookRental.Infrastructure.Entities;
using eBookRental.Core.Domain;

namespace eBookRental.Api.Migrations
{
    [DbContext(typeof(eBookRentalContext))]
    partial class eBookRentalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("eBookRental.Core.Domain.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000);

                    b.Property<Guid>("GenreId");

                    b.Property<string>("Image")
                        .IsRequired();

                    b.Property<byte>("NumberOfSets");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<byte>("Rating");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Writer")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("eBookRental.Core.Domain.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Name");

                    b.HasKey("Id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("eBookRental.Core.Domain.Rental", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("RentalDate");

                    b.Property<DateTime?>("ReturnedDate");

                    b.Property<Guid>("SetId");

                    b.Property<int>("Status")
                        .HasMaxLength(10);

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("SetId");

                    b.ToTable("Rental");
                });

            modelBuilder.Entity("eBookRental.Core.Domain.Set", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BookId");

                    b.Property<Guid?>("BookId1");

                    b.Property<bool>("IsAvailable");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("BookId1");

                    b.ToTable("Set");
                });

            modelBuilder.Entity("eBookRental.Core.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("IdentityCard")
                        .HasMaxLength(16);

                    b.Property<string>("Mobile")
                        .HasMaxLength(9);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Role");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("eBookRental.Core.Domain.Book", b =>
                {
                    b.HasOne("eBookRental.Core.Domain.Genre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eBookRental.Core.Domain.Rental", b =>
                {
                    b.HasOne("eBookRental.Core.Domain.Set", "Set")
                        .WithMany("Rentals")
                        .HasForeignKey("SetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eBookRental.Core.Domain.Set", b =>
                {
                    b.HasOne("eBookRental.Core.Domain.Book")
                        .WithMany("Sets")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eBookRental.Core.Domain.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId1");
                });
        }
    }
}

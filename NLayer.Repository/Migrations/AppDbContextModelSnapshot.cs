﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NLayer.Repository.Context;

#nullable disable

namespace NLayer.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NLayer.Core.Entity.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Kalemler"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Kitaplar"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Defterler"
                        });
                });

            modelBuilder.Entity("NLayer.Core.Entity.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2022, 8, 29, 13, 23, 35, 385, DateTimeKind.Local).AddTicks(5274),
                            Name = "Kurşun Kalem",
                            Price = 100m,
                            Stock = 100
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2022, 8, 29, 13, 23, 35, 385, DateTimeKind.Local).AddTicks(5288),
                            Name = "Tükenmez Kalem",
                            Price = 200m,
                            Stock = 200
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2022, 8, 29, 13, 23, 35, 385, DateTimeKind.Local).AddTicks(5290),
                            Name = "Dolma Kalem",
                            Price = 300m,
                            Stock = 300
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 3,
                            CreatedDate = new DateTime(2022, 8, 29, 13, 23, 35, 385, DateTimeKind.Local).AddTicks(5292),
                            Name = "Çizgili Defter",
                            Price = 100m,
                            Stock = 100
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            CreatedDate = new DateTime(2022, 8, 29, 13, 23, 35, 385, DateTimeKind.Local).AddTicks(5293),
                            Name = "Kareli Defter",
                            Price = 200m,
                            Stock = 200
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 3,
                            CreatedDate = new DateTime(2022, 8, 29, 13, 23, 35, 385, DateTimeKind.Local).AddTicks(5294),
                            Name = "Resim Defteri",
                            Price = 300m,
                            Stock = 300
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2022, 8, 29, 13, 23, 35, 385, DateTimeKind.Local).AddTicks(5296),
                            Name = "Tarih Kitabı",
                            Price = 100m,
                            Stock = 100
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2022, 8, 29, 13, 23, 35, 385, DateTimeKind.Local).AddTicks(5297),
                            Name = "Ders Kitabı",
                            Price = 200m,
                            Stock = 200
                        });
                });

            modelBuilder.Entity("NLayer.Core.Entity.ProductFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("ProductFeatures");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "Kırmızı",
                            Height = 10,
                            ProductId = 1,
                            Width = 10
                        },
                        new
                        {
                            Id = 2,
                            Color = "Mavi",
                            Height = 20,
                            ProductId = 2,
                            Width = 20
                        },
                        new
                        {
                            Id = 3,
                            Color = "Yeşil",
                            Height = 30,
                            ProductId = 3,
                            Width = 30
                        });
                });

            modelBuilder.Entity("NLayer.Core.Entity.Product", b =>
                {
                    b.HasOne("NLayer.Core.Entity.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("NLayer.Core.Entity.ProductFeature", b =>
                {
                    b.HasOne("NLayer.Core.Entity.Product", "Product")
                        .WithOne("ProductFeature")
                        .HasForeignKey("NLayer.Core.Entity.ProductFeature", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("NLayer.Core.Entity.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("NLayer.Core.Entity.Product", b =>
                {
                    b.Navigation("ProductFeature")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

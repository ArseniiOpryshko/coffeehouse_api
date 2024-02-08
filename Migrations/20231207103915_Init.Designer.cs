﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Museum.Data;

#nullable disable

namespace coffeehouse_api.Migrations
{
    [DbContext(typeof(CoffeeHouseContext))]
    [Migration("20231207103915_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("coffeehouse_api.Models.Compound", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Compounds");
                });

            modelBuilder.Entity("coffeehouse_api.Models.CompoundGrammProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Compoundid")
                        .HasColumnType("int");

                    b.Property<int>("Productid")
                        .HasColumnType("int");

                    b.Property<int>("Gramm")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Compoundid");

                    b.HasIndex("Productid");

                    b.ToTable("CompoundGrammProducts");
                });

            modelBuilder.Entity("coffeehouse_api.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Typeid")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("Typeid");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("coffeehouse_api.Models.Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("coffeehouse_api.Models.User.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("coffeehouse_api.Models.User.DeliveryData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DeliveryDatas");
                });

            modelBuilder.Entity("coffeehouse_api.Models.User.ProductInCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Cartid")
                        .HasColumnType("int");

                    b.Property<int>("Productid")
                        .HasColumnType("int");

                    b.Property<bool>("IsChosen")
                        .HasColumnType("bit");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("totalPrice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Cartid");

                    b.HasIndex("Productid");

                    b.ToTable("ProductInCarts");
                });

            modelBuilder.Entity("coffeehouse_api.Models.User.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cartid")
                        .HasColumnType("int");

                    b.Property<int>("deliveryDataid")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Cartid");

                    b.HasIndex("deliveryDataid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("coffeehouse_api.Models.CompoundGrammProduct", b =>
                {
                    b.HasOne("coffeehouse_api.Models.Compound", "Compound")
                        .WithMany()
                        .HasForeignKey("Compoundid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("coffeehouse_api.Models.Product", "Product")
                        .WithMany("Compounds")
                        .HasForeignKey("Productid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Compound");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("coffeehouse_api.Models.Product", b =>
                {
                    b.HasOne("coffeehouse_api.Models.Type", "Type")
                        .WithMany()
                        .HasForeignKey("Typeid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("coffeehouse_api.Models.User.ProductInCart", b =>
                {
                    b.HasOne("coffeehouse_api.Models.User.Cart", null)
                        .WithMany("ProductInCarts")
                        .HasForeignKey("Cartid");

                    b.HasOne("coffeehouse_api.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("Productid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("coffeehouse_api.Models.User.User", b =>
                {
                    b.HasOne("coffeehouse_api.Models.User.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("Cartid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("coffeehouse_api.Models.User.DeliveryData", "DeliveryData")
                        .WithMany()
                        .HasForeignKey("deliveryDataid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("DeliveryData");
                });

            modelBuilder.Entity("coffeehouse_api.Models.Product", b =>
                {
                    b.Navigation("Compounds");
                });

            modelBuilder.Entity("coffeehouse_api.Models.User.Cart", b =>
                {
                    b.Navigation("ProductInCarts");
                });
#pragma warning restore 612, 618
        }
    }
}

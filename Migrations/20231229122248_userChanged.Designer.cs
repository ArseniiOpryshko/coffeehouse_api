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
    [Migration("20231229122248_userChanged")]
    partial class userChanged
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CartProductInCart", b =>
                {
                    b.Property<int>("cartsid")
                        .HasColumnType("int");

                    b.Property<int>("productInCartsid")
                        .HasColumnType("int");

                    b.HasKey("cartsid", "productInCartsid");

                    b.HasIndex("productInCartsid");

                    b.ToTable("CartProductInCart");
                });

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

                    b.Property<int>("Productid")
                        .HasColumnType("int");

                    b.Property<bool>("IsChosen")
                        .HasColumnType("bit");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Productid");

                    b.ToTable("ProductInCarts");
                });

            modelBuilder.Entity("coffeehouse_api.Models.User.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("coffeehouse_api.Models.User.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Cartid")
                        .HasColumnType("int");

                    b.Property<int>("Roleid")
                        .HasColumnType("int");

                    b.Property<int?>("deliveryDataid")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("Cartid");

                    b.HasIndex("Roleid");

                    b.HasIndex("deliveryDataid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CartProductInCart", b =>
                {
                    b.HasOne("coffeehouse_api.Models.User.Cart", null)
                        .WithMany()
                        .HasForeignKey("cartsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("coffeehouse_api.Models.User.ProductInCart", null)
                        .WithMany()
                        .HasForeignKey("productInCartsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                        .HasForeignKey("Cartid");

                    b.HasOne("coffeehouse_api.Models.User.Role", "Role")
                        .WithMany()
                        .HasForeignKey("Roleid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("coffeehouse_api.Models.User.DeliveryData", "DeliveryData")
                        .WithMany()
                        .HasForeignKey("deliveryDataid");

                    b.Navigation("Cart");

                    b.Navigation("Role");

                    b.Navigation("DeliveryData");
                });

            modelBuilder.Entity("coffeehouse_api.Models.Product", b =>
                {
                    b.Navigation("Compounds");
                });
#pragma warning restore 612, 618
        }
    }
}

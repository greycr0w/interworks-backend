﻿// <auto-generated />
using System;
using Interworks.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Interworks.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Interworks.API.Entities.Part1.Category", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("createdAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("updatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("id");

                    b.ToTable("categories");

                    b.HasData(
                        new
                        {
                            id = new Guid("df17ae7f-6898-4358-9328-75d1df8ac9cb"),
                            createdAt = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            name = "Product Name"
                        });
                });

            modelBuilder.Entity("Interworks.API.Entities.Part1.Country", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("code")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("createdAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<decimal>("shippingCost")
                        .HasColumnType("numeric");

                    b.Property<DateTimeOffset?>("updatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("id");

                    b.HasIndex("code")
                        .IsUnique();

                    b.ToTable("countries");
                });

            modelBuilder.Entity("Interworks.API.Entities.Part1.Discount", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("amount")
                        .HasColumnType("numeric");

                    b.Property<string>("code")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("createdAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("expiresAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("isAutomaticallyApplied")
                        .HasColumnType("boolean");

                    b.Property<bool>("isFixed")
                        .HasColumnType("boolean");

                    b.Property<int?>("maxUses")
                        .HasColumnType("integer");

                    b.Property<int?>("maxUsesPerUser")
                        .HasColumnType("integer");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<int>("priority")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset?>("startsAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal?>("thresholdAmount")
                        .HasColumnType("numeric");

                    b.Property<DateTimeOffset?>("updatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("id");

                    b.ToTable("discounts");

                    b.HasData(
                        new
                        {
                            id = new Guid("54fbef96-0535-4ad0-bd85-421c2a4fc793"),
                            amount = 50m,
                            createdAt = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            description = "this is a sample discount",
                            expiresAt = new DateTimeOffset(new DateTime(2008, 5, 1, 8, 6, 32, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            isAutomaticallyApplied = true,
                            isFixed = true,
                            priority = 1
                        });
                });

            modelBuilder.Entity("Interworks.API.Entities.Part1.Order", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("Productid")
                        .HasColumnType("uuid");

                    b.Property<decimal>("amount")
                        .HasColumnType("numeric");

                    b.Property<DateTimeOffset>("createdAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("endsAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("monthsCycle")
                        .HasColumnType("integer");

                    b.Property<Guid>("productId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("startsAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("updatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("userId")
                        .HasColumnType("uuid");

                    b.Property<int>("validityDays")
                        .HasColumnType("integer");

                    b.Property<int>("validityMonths")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("Productid");

                    b.HasIndex("productId");

                    b.HasIndex("userId");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("Interworks.API.Entities.Part1.Product", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("categoryId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("createdAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("deletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.Property<bool>("isSubscription")
                        .HasColumnType("boolean");

                    b.Property<int>("monthsActive")
                        .HasColumnType("integer");

                    b.Property<int>("monthsCycle")
                        .HasColumnType("integer");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<decimal>("price")
                        .HasColumnType("numeric");

                    b.Property<DateTimeOffset?>("updatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("id");

                    b.HasIndex("categoryId");

                    b.ToTable("products");

                    b.HasData(
                        new
                        {
                            id = new Guid("8608cbbf-9c7e-4a7c-86bf-30cde97ed266"),
                            categoryId = new Guid("df17ae7f-6898-4358-9328-75d1df8ac9cb"),
                            createdAt = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            description = "This is a sample subscription product",
                            isSubscription = false,
                            monthsActive = 24,
                            monthsCycle = 6,
                            name = "Product Name",
                            price = 340m
                        });
                });

            modelBuilder.Entity("Interworks.API.Entities.Part1.ProductDiscount", b =>
                {
                    b.Property<Guid>("productId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("discountId")
                        .HasColumnType("uuid");

                    b.HasKey("productId", "discountId");

                    b.HasIndex("discountId");

                    b.ToTable("productDiscounts");
                });

            modelBuilder.Entity("Interworks.API.Entities.Part1.Template", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("body")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("createdAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("key")
                        .HasColumnType("text");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.Property<int>("type")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset?>("updatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("id");

                    b.ToTable("templates");
                });

            modelBuilder.Entity("Interworks.API.Entities.Part1.UsedDiscount", b =>
                {
                    b.Property<Guid>("userId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("discountId")
                        .HasColumnType("uuid");

                    b.HasKey("userId", "discountId");

                    b.HasIndex("discountId");

                    b.ToTable("usedDiscounts");
                });

            modelBuilder.Entity("Interworks.API.Entities.Part2.Data", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("createdAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("deletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("fieldId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("fieldOptionId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("fieldOptionid")
                        .HasColumnType("uuid");

                    b.Property<string>("imagePath")
                        .HasColumnType("text");

                    b.Property<string>("textbox")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("updatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("userId")
                        .HasColumnType("uuid");

                    b.HasKey("id");

                    b.HasIndex("fieldId");

                    b.HasIndex("fieldOptionId");

                    b.HasIndex("fieldOptionid");

                    b.HasIndex("userId");

                    b.ToTable("datum");
                });

            modelBuilder.Entity("Interworks.API.Entities.Part2.Field", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("createdAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<Guid>("pageId")
                        .HasColumnType("uuid");

                    b.Property<int>("type")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset?>("updatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("id");

                    b.HasIndex("pageId");

                    b.ToTable("fields");
                });

            modelBuilder.Entity("Interworks.API.Entities.Part2.FieldOption", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("createdAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("fieldId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("updatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("value")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("fieldId");

                    b.ToTable("fieldOptions");
                });

            modelBuilder.Entity("Interworks.API.Entities.Part2.Page", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("createdAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("updatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("id");

                    b.ToTable("pages");
                });

            modelBuilder.Entity("Interworks.API.Entities.User", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("address_line")
                        .HasColumnType("text");

                    b.Property<string>("city")
                        .HasColumnType("text");

                    b.Property<Guid?>("countryId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("createdAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("firstName")
                        .HasColumnType("text");

                    b.Property<string>("lastName")
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .HasColumnType("text");

                    b.Property<string>("phone")
                        .HasColumnType("text");

                    b.Property<string>("token")
                        .HasColumnType("text");

                    b.Property<int>("type")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset?>("updatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("username")
                        .HasColumnType("text");

                    b.Property<string>("zip_code")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("countryId");

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            id = new Guid("cc680d14-76ea-479c-8041-15b2073d45ac"),
                            createdAt = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            password = "test",
                            type = 0,
                            username = "test"
                        });
                });

            modelBuilder.Entity("Interworks.API.Entities.Part1.Order", b =>
                {
                    b.HasOne("Interworks.API.Entities.Part1.Product", null)
                        .WithMany("productOrders")
                        .HasForeignKey("Productid");

                    b.HasOne("Interworks.API.Entities.Part1.Product", "product")
                        .WithMany()
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Interworks.API.Entities.User", "user")
                        .WithMany("orders")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Interworks.API.Entities.Part1.Product", b =>
                {
                    b.HasOne("Interworks.API.Entities.Part1.Category", "category")
                        .WithMany("products")
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Interworks.API.Entities.Part1.ProductDiscount", b =>
                {
                    b.HasOne("Interworks.API.Entities.Part1.Discount", "discount")
                        .WithMany("productDiscounts")
                        .HasForeignKey("discountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Interworks.API.Entities.Part1.Product", "product")
                        .WithMany("productDiscounts")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Interworks.API.Entities.Part1.UsedDiscount", b =>
                {
                    b.HasOne("Interworks.API.Entities.Part1.Discount", "discount")
                        .WithMany("usedDiscounts")
                        .HasForeignKey("discountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Interworks.API.Entities.User", "user")
                        .WithMany("usedDiscounts")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Interworks.API.Entities.Part2.Data", b =>
                {
                    b.HasOne("Interworks.API.Entities.Part2.Field", "field")
                        .WithMany("datum")
                        .HasForeignKey("fieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Interworks.API.Entities.Part2.FieldOption", null)
                        .WithMany("datum")
                        .HasForeignKey("fieldOptionId");

                    b.HasOne("Interworks.API.Entities.Part2.FieldOption", "fieldOption")
                        .WithMany()
                        .HasForeignKey("fieldOptionid");

                    b.HasOne("Interworks.API.Entities.User", "user")
                        .WithMany("datum")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Interworks.API.Entities.Part2.Field", b =>
                {
                    b.HasOne("Interworks.API.Entities.Part2.Page", "page")
                        .WithMany("fields")
                        .HasForeignKey("pageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Interworks.API.Entities.Part2.FieldOption", b =>
                {
                    b.HasOne("Interworks.API.Entities.Part2.Field", "field")
                        .WithMany("fieldOptions")
                        .HasForeignKey("fieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Interworks.API.Entities.User", b =>
                {
                    b.HasOne("Interworks.API.Entities.Part1.Country", "country")
                        .WithMany()
                        .HasForeignKey("countryId");
                });
#pragma warning restore 612, 618
        }
    }
}

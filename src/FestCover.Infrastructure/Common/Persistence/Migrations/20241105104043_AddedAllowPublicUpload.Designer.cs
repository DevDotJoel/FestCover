﻿// <auto-generated />
using System;
using FestCover.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FestCover.Infrastructure.Migrations
{
    [DbContext(typeof(FestCoverDbContext))]
    [Migration("20241105104043_AddedAllowPublicUpload")]
    partial class AddedAllowPublicUpload
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FestCover.Domain.AlbumContents.AlbumContent", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AlbumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Pending")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AlbumContents", (string)null);
                });

            modelBuilder.Entity("FestCover.Domain.Albums.Album", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("AllowPublicUpload")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Albums", (string)null);
                });

            modelBuilder.Entity("FestCover.Infrastructure.Common.Persistence.Identity.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("d67c7fbd-69bb-4926-acb6-f393143c16b3"),
                            ConcurrencyStamp = "34a8bd40-92fe-4640-84d5-0da273563aa1",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = new Guid("e67c7fbd-69bb-4926-acb6-f393143c16b3"),
                            ConcurrencyStamp = "24a8bd40-92fe-4640-84d5-0da273563aa1",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("FestCover.Infrastructure.Common.Persistence.Identity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("f69b50aa-de02-423b-abc4-0ba2fb3eb64d"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "201bb950-f345-447c-bb2a-0b9bba687320",
                            Email = "j141996@hotmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "J141996@HOTMAIL.COM",
                            NormalizedUserName = "JOELFERREIRA",
                            PasswordHash = "AQAAAAIAAYagAAAAEAlpLhMBHSq1Z/SHylAGnJOfbVTo9bBrKTV4/45NWsAKGLb1r68UcmxdQUdk0MOO6Q==",
                            PhoneNumber = "+351960180464",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b909ffab-63dd-46ae-8e70-01b48f7f8256",
                            TwoFactorEnabled = false,
                            UserName = "JoelFerreira"
                        },
                        new
                        {
                            Id = new Guid("613de40e-809c-47c2-8f8b-005efffff05e"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6cb28543-2306-4c85-b375-cde945f45316",
                            Email = "mirandajp@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "MIRANDAJP@GMAIL.COM",
                            NormalizedUserName = "JOAOMIRANDA",
                            PasswordHash = "AQAAAAIAAYagAAAAELdFAeXILNzXPrgfPulQDv538Kl9CK6F6mqyS5x4Y42nnD9C1tp3KVvt3wWhCtWffg==",
                            PhoneNumber = "+351960180464",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "88c4568a-83bd-4c00-97f6-58c51c00696b",
                            TwoFactorEnabled = false,
                            UserName = "JoaoMiranda"
                        },
                        new
                        {
                            Id = new Guid("aa14ed43-7698-408e-8b35-3e556e79bd18"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "68ed53b5-46d4-44f5-92a5-708814b07cdd",
                            Email = "isabelkiala@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ISABELKIALA@GMAIL.COM",
                            NormalizedUserName = "ISABELKIALA",
                            PasswordHash = "AQAAAAIAAYagAAAAECLTxrk7qJhJEnPgTWG3yMfQ6VQI7NaBWJNIZVWRDg9GxtqQpGENyhLH5AGyY3PIYw==",
                            PhoneNumber = "+351960180464",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b67620be-d679-41d7-88e2-22f729e7d9f6",
                            TwoFactorEnabled = false,
                            UserName = "IsabelKiala"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RolesClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UsersClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UsersLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UsersRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("f69b50aa-de02-423b-abc4-0ba2fb3eb64d"),
                            RoleId = new Guid("d67c7fbd-69bb-4926-acb6-f393143c16b3")
                        },
                        new
                        {
                            UserId = new Guid("613de40e-809c-47c2-8f8b-005efffff05e"),
                            RoleId = new Guid("d67c7fbd-69bb-4926-acb6-f393143c16b3")
                        },
                        new
                        {
                            UserId = new Guid("aa14ed43-7698-408e-8b35-3e556e79bd18"),
                            RoleId = new Guid("d67c7fbd-69bb-4926-acb6-f393143c16b3")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UsersTokens", (string)null);
                });

            modelBuilder.Entity("FestCover.Domain.Albums.Album", b =>
                {
                    b.OwnsMany("FestCover.Domain.AlbumContents.ValueObjects.AlbumContentId", "AlbumContentIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("AlbumId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("AlbumContentId");

                            b1.HasKey("Id");

                            b1.HasIndex("AlbumId");

                            b1.ToTable("AlbumContentIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("AlbumId");
                        });

                    b.Navigation("AlbumContentIds");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("FestCover.Infrastructure.Common.Persistence.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("FestCover.Infrastructure.Common.Persistence.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("FestCover.Infrastructure.Common.Persistence.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("FestCover.Infrastructure.Common.Persistence.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FestCover.Infrastructure.Common.Persistence.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("FestCover.Infrastructure.Common.Persistence.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
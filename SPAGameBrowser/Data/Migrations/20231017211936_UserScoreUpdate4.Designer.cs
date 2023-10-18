﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SPAGameBrowser.Data;

#nullable disable

namespace SPAGameBrowser.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231017211936_UserScoreUpdate4")]
    partial class UserScoreUpdate4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.DeviceFlowCodes", b =>
                {
                    b.Property<string>("UserCode")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(50000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("DeviceCode")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("Expiration")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("SessionId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SubjectId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("UserCode");

                    b.HasIndex("DeviceCode")
                        .IsUnique();

                    b.HasIndex("Expiration");

                    b.ToTable("DeviceCodes", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.Key", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Algorithm")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DataProtected")
                        .HasColumnType("bit");

                    b.Property<bool>("IsX509Certificate")
                        .HasColumnType("bit");

                    b.Property<string>("Use")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Use");

                    b.ToTable("Keys");
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.PersistedGrant", b =>
                {
                    b.Property<string>("Key")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("ConsumedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(50000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("Expiration")
                        .HasColumnType("datetime2");

                    b.Property<string>("SessionId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SubjectId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Key");

                    b.HasIndex("ConsumedTime");

                    b.HasIndex("Expiration");

                    b.HasIndex("SubjectId", "ClientId", "Type");

                    b.HasIndex("SubjectId", "SessionId", "Type");

                    b.ToTable("PersistedGrants", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

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

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SPAGameBrowser.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

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

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

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

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("Nickname")
                        .IsUnique();

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("SPAGameBrowser.Models.Letter", b =>
                {
                    b.Property<int>("LetterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LetterId"), 1L, 1);

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("LetterId");

                    b.HasIndex("Key")
                        .IsUnique();

                    b.ToTable("Letters");

                    b.HasData(
                        new
                        {
                            LetterId = 1,
                            Key = "a"
                        },
                        new
                        {
                            LetterId = 2,
                            Key = "b"
                        },
                        new
                        {
                            LetterId = 3,
                            Key = "c"
                        },
                        new
                        {
                            LetterId = 4,
                            Key = "d"
                        },
                        new
                        {
                            LetterId = 5,
                            Key = "e"
                        },
                        new
                        {
                            LetterId = 6,
                            Key = "f"
                        },
                        new
                        {
                            LetterId = 7,
                            Key = "g"
                        },
                        new
                        {
                            LetterId = 8,
                            Key = "h"
                        },
                        new
                        {
                            LetterId = 9,
                            Key = "i"
                        },
                        new
                        {
                            LetterId = 10,
                            Key = "j"
                        },
                        new
                        {
                            LetterId = 11,
                            Key = "k"
                        },
                        new
                        {
                            LetterId = 12,
                            Key = "l"
                        },
                        new
                        {
                            LetterId = 13,
                            Key = "m"
                        },
                        new
                        {
                            LetterId = 14,
                            Key = "n"
                        },
                        new
                        {
                            LetterId = 15,
                            Key = "o"
                        },
                        new
                        {
                            LetterId = 16,
                            Key = "p"
                        },
                        new
                        {
                            LetterId = 17,
                            Key = "q"
                        },
                        new
                        {
                            LetterId = 18,
                            Key = "r"
                        },
                        new
                        {
                            LetterId = 19,
                            Key = "s"
                        },
                        new
                        {
                            LetterId = 20,
                            Key = "t"
                        },
                        new
                        {
                            LetterId = 21,
                            Key = "u"
                        },
                        new
                        {
                            LetterId = 22,
                            Key = "v"
                        },
                        new
                        {
                            LetterId = 23,
                            Key = "w"
                        },
                        new
                        {
                            LetterId = 24,
                            Key = "x"
                        },
                        new
                        {
                            LetterId = 25,
                            Key = "y"
                        },
                        new
                        {
                            LetterId = 26,
                            Key = "z"
                        });
                });

            modelBuilder.Entity("SPAGameBrowser.Models.UserScore", b =>
                {
                    b.Property<int>("UserScoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserScoreId"), 1L, 1);

                    b.Property<int>("Attempts")
                        .HasColumnType("int");

                    b.Property<string>("Finished_At")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FkUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("FkWordId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<bool>("IsGuessed")
                        .HasColumnType("bit");

                    b.Property<string>("Started_At")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserScoreId");

                    b.HasIndex("FkUserId");

                    b.HasIndex("FkWordId");

                    b.ToTable("UserScores");
                });

            modelBuilder.Entity("SPAGameBrowser.Models.Word", b =>
                {
                    b.Property<int>("WordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WordId"), 1L, 1);

                    b.Property<string>("WordName")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("WordId");

                    b.HasIndex("WordName")
                        .IsUnique();

                    b.ToTable("Words");

                    b.HasData(
                        new
                        {
                            WordId = 1,
                            WordName = "apple"
                        },
                        new
                        {
                            WordId = 2,
                            WordName = "chair"
                        },
                        new
                        {
                            WordId = 3,
                            WordName = "house"
                        },
                        new
                        {
                            WordId = 4,
                            WordName = "table"
                        },
                        new
                        {
                            WordId = 5,
                            WordName = "knife"
                        },
                        new
                        {
                            WordId = 6,
                            WordName = "books"
                        },
                        new
                        {
                            WordId = 7,
                            WordName = "paper"
                        },
                        new
                        {
                            WordId = 8,
                            WordName = "music"
                        },
                        new
                        {
                            WordId = 9,
                            WordName = "globe"
                        },
                        new
                        {
                            WordId = 10,
                            WordName = "stars"
                        },
                        new
                        {
                            WordId = 11,
                            WordName = "radio"
                        },
                        new
                        {
                            WordId = 12,
                            WordName = "queen"
                        },
                        new
                        {
                            WordId = 13,
                            WordName = "clock"
                        },
                        new
                        {
                            WordId = 14,
                            WordName = "watch"
                        },
                        new
                        {
                            WordId = 15,
                            WordName = "glass"
                        },
                        new
                        {
                            WordId = 16,
                            WordName = "water"
                        },
                        new
                        {
                            WordId = 17,
                            WordName = "plant"
                        },
                        new
                        {
                            WordId = 18,
                            WordName = "earth"
                        },
                        new
                        {
                            WordId = 19,
                            WordName = "grape"
                        },
                        new
                        {
                            WordId = 20,
                            WordName = "beach"
                        },
                        new
                        {
                            WordId = 21,
                            WordName = "candy"
                        },
                        new
                        {
                            WordId = 22,
                            WordName = "frost"
                        },
                        new
                        {
                            WordId = 23,
                            WordName = "crown"
                        },
                        new
                        {
                            WordId = 24,
                            WordName = "lions"
                        },
                        new
                        {
                            WordId = 25,
                            WordName = "heart"
                        },
                        new
                        {
                            WordId = 26,
                            WordName = "bells"
                        },
                        new
                        {
                            WordId = 27,
                            WordName = "peace"
                        },
                        new
                        {
                            WordId = 28,
                            WordName = "pride"
                        },
                        new
                        {
                            WordId = 29,
                            WordName = "raven"
                        },
                        new
                        {
                            WordId = 30,
                            WordName = "torch"
                        },
                        new
                        {
                            WordId = 31,
                            WordName = "smile"
                        },
                        new
                        {
                            WordId = 32,
                            WordName = "sushi"
                        },
                        new
                        {
                            WordId = 33,
                            WordName = "swiss"
                        },
                        new
                        {
                            WordId = 34,
                            WordName = "darts"
                        },
                        new
                        {
                            WordId = 35,
                            WordName = "horse"
                        },
                        new
                        {
                            WordId = 36,
                            WordName = "lamps"
                        },
                        new
                        {
                            WordId = 37,
                            WordName = "birds"
                        },
                        new
                        {
                            WordId = 38,
                            WordName = "magic"
                        },
                        new
                        {
                            WordId = 39,
                            WordName = "ocean"
                        },
                        new
                        {
                            WordId = 40,
                            WordName = "route"
                        },
                        new
                        {
                            WordId = 41,
                            WordName = "trout"
                        },
                        new
                        {
                            WordId = 42,
                            WordName = "flame"
                        },
                        new
                        {
                            WordId = 43,
                            WordName = "sugar"
                        },
                        new
                        {
                            WordId = 44,
                            WordName = "couch"
                        },
                        new
                        {
                            WordId = 45,
                            WordName = "spear"
                        },
                        new
                        {
                            WordId = 46,
                            WordName = "chess"
                        },
                        new
                        {
                            WordId = 47,
                            WordName = "piano"
                        },
                        new
                        {
                            WordId = 48,
                            WordName = "cigar"
                        },
                        new
                        {
                            WordId = 49,
                            WordName = "hills"
                        },
                        new
                        {
                            WordId = 50,
                            WordName = "fairy"
                        },
                        new
                        {
                            WordId = 51,
                            WordName = "wings"
                        },
                        new
                        {
                            WordId = 52,
                            WordName = "beard"
                        },
                        new
                        {
                            WordId = 53,
                            WordName = "flute"
                        },
                        new
                        {
                            WordId = 54,
                            WordName = "space"
                        },
                        new
                        {
                            WordId = 55,
                            WordName = "tiger"
                        },
                        new
                        {
                            WordId = 56,
                            WordName = "zebra"
                        },
                        new
                        {
                            WordId = 57,
                            WordName = "dolph"
                        },
                        new
                        {
                            WordId = 58,
                            WordName = "angel"
                        },
                        new
                        {
                            WordId = 59,
                            WordName = "panda"
                        },
                        new
                        {
                            WordId = 60,
                            WordName = "juice"
                        },
                        new
                        {
                            WordId = 61,
                            WordName = "honey"
                        },
                        new
                        {
                            WordId = 62,
                            WordName = "dream"
                        },
                        new
                        {
                            WordId = 63,
                            WordName = "happy"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SPAGameBrowser.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SPAGameBrowser.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SPAGameBrowser.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SPAGameBrowser.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SPAGameBrowser.Models.UserScore", b =>
                {
                    b.HasOne("SPAGameBrowser.Models.ApplicationUser", "ApplicationUsers")
                        .WithMany("UserScores")
                        .HasForeignKey("FkUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SPAGameBrowser.Models.Word", "Words")
                        .WithMany("UserScores")
                        .HasForeignKey("FkWordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUsers");

                    b.Navigation("Words");
                });

            modelBuilder.Entity("SPAGameBrowser.Models.ApplicationUser", b =>
                {
                    b.Navigation("UserScores");
                });

            modelBuilder.Entity("SPAGameBrowser.Models.Word", b =>
                {
                    b.Navigation("UserScores");
                });
#pragma warning restore 612, 618
        }
    }
}

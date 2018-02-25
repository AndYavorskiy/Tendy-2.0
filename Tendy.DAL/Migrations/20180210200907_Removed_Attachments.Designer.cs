﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using Tendy.DAL.EF;

namespace Tendy.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180210200907_Removed_Attachments")]
    partial class Removed_Attachments
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Tendy.DAL.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Tendy.DAL.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Tendy.DAL.Entities.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateOfCreation");

                    b.Property<string>("Extension");

                    b.Property<int>("IdeaId");

                    b.Property<bool>("IsPrivate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("Name");

                    b.Property<string>("SourceUrl");

                    b.HasKey("Id");

                    b.HasIndex("IdeaId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("Tendy.DAL.Entities.Idea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AcceptedPeopleGroupId");

                    b.Property<string>("AuthorId");

                    b.Property<DateTime?>("DateOfCreation");

                    b.Property<string>("Description");

                    b.Property<string>("GitHubLink");

                    b.Property<int?>("RequestedPeopleGroupId");

                    b.Property<string>("SubTitle");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("AcceptedPeopleGroupId")
                        .IsUnique()
                        .HasFilter("[AcceptedPeopleGroupId] IS NOT NULL");

                    b.HasIndex("AuthorId");

                    b.HasIndex("RequestedPeopleGroupId")
                        .IsUnique()
                        .HasFilter("[RequestedPeopleGroupId] IS NOT NULL");

                    b.ToTable("Ideas");
                });

            modelBuilder.Entity("Tendy.DAL.Entities.IdeaCategory", b =>
                {
                    b.Property<int>("IdeaId");

                    b.Property<int>("CategoryId");

                    b.HasKey("IdeaId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("IdeaCategory");
                });

            modelBuilder.Entity("Tendy.DAL.Entities.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateOfCreation");

                    b.Property<int>("IdeaId");

                    b.Property<bool>("IsPrivate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("IdeaId");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("Tendy.DAL.Entities.PeopleGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("PeopleGroups");
                });

            modelBuilder.Entity("Tendy.DAL.Entities.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<DateTime?>("DateOfJoining");

                    b.Property<int?>("PeopleGroupId");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("PeopleGroupId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("Tendy.DAL.Entities.UserProfile", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<DateTime?>("Birthday");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId")
                        .IsUnique()
                        .HasFilter("[ApplicationUserId] IS NOT NULL");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Tendy.DAL.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Tendy.DAL.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Tendy.DAL.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Tendy.DAL.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Tendy.DAL.Entities.File", b =>
                {
                    b.HasOne("Tendy.DAL.Entities.Idea", "Idea")
                        .WithMany("Files")
                        .HasForeignKey("IdeaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Tendy.DAL.Entities.Idea", b =>
                {
                    b.HasOne("Tendy.DAL.Entities.PeopleGroup", "AcceptedPeopleGroup")
                        .WithOne("IdeaAcceptedPeople")
                        .HasForeignKey("Tendy.DAL.Entities.Idea", "AcceptedPeopleGroupId");

                    b.HasOne("Tendy.DAL.Entities.ApplicationUser", "Author")
                        .WithMany("Ideas")
                        .HasForeignKey("AuthorId");

                    b.HasOne("Tendy.DAL.Entities.PeopleGroup", "RequestedPeopleGroup")
                        .WithOne("IdeaRequestedPeople")
                        .HasForeignKey("Tendy.DAL.Entities.Idea", "RequestedPeopleGroupId");
                });

            modelBuilder.Entity("Tendy.DAL.Entities.IdeaCategory", b =>
                {
                    b.HasOne("Tendy.DAL.Entities.Category", "Category")
                        .WithMany("IdeaCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Tendy.DAL.Entities.Idea", "Idea")
                        .WithMany("IdeaCategories")
                        .HasForeignKey("IdeaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Tendy.DAL.Entities.Link", b =>
                {
                    b.HasOne("Tendy.DAL.Entities.Idea", "Idea")
                        .WithMany("Links")
                        .HasForeignKey("IdeaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Tendy.DAL.Entities.Request", b =>
                {
                    b.HasOne("Tendy.DAL.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Tendy.DAL.Entities.PeopleGroup", "PeopleGroup")
                        .WithMany()
                        .HasForeignKey("PeopleGroupId");
                });

            modelBuilder.Entity("Tendy.DAL.Entities.UserProfile", b =>
                {
                    b.HasOne("Tendy.DAL.Entities.ApplicationUser", "ApplicationUser")
                        .WithOne("Profile")
                        .HasForeignKey("Tendy.DAL.Entities.UserProfile", "ApplicationUserId");
                });
#pragma warning restore 612, 618
        }
    }
}

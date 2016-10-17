﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Encounter.Entities;

namespace Encounter.Migrations
{
    [DbContext(typeof(EncounterDbContext))]
    [Migration("20161017225552_RmOldSets")]
    partial class RmOldSets
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Encounter.Entities.Ability", b =>
                {
                    b.Property<int>("AbilityId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CharHarm");

                    b.Property<int>("CharHeal");

                    b.Property<int>("CoolDownMiliSecs");

                    b.Property<int>("FoeHarm");

                    b.Property<int>("FoeHeal");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Name");

                    b.HasKey("AbilityId");

                    b.ToTable("Abilities");
                });

            modelBuilder.Entity("Encounter.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<bool>("Authorized");

                    b.Property<string>("AvatarUrl");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("PlayerName");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Encounter.Entities.Character", b =>
                {
                    b.Property<int>("CharacterId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Ability1AbilityId");

                    b.Property<int?>("Ability2AbilityId");

                    b.Property<int?>("Ability3AbilityId");

                    b.Property<string>("Class");

                    b.Property<int>("Health");

                    b.Property<string>("Name");

                    b.Property<string>("SpriteUrl");

                    b.HasKey("CharacterId");

                    b.HasIndex("Ability1AbilityId");

                    b.HasIndex("Ability2AbilityId");

                    b.HasIndex("Ability3AbilityId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("Encounter.Entities.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FoeId");

                    b.Property<int?>("GameId");

                    b.Property<string>("ImageUrl");

                    b.Property<int>("Level");

                    b.Property<string>("Name");

                    b.Property<int?>("ScenarioId");

                    b.HasKey("EventId");

                    b.HasIndex("FoeId");

                    b.HasIndex("GameId");

                    b.HasIndex("ScenarioId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Encounter.Entities.Foe", b =>
                {
                    b.Property<int>("FoeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Ability1AbilityId");

                    b.Property<int?>("Ability2AbilityId");

                    b.Property<int?>("Ability3AbilityId");

                    b.Property<int>("Health");

                    b.Property<int>("Level");

                    b.Property<string>("Name");

                    b.Property<int?>("ScenarioId");

                    b.Property<string>("SpriteUrl");

                    b.HasKey("FoeId");

                    b.HasIndex("Ability1AbilityId");

                    b.HasIndex("Ability2AbilityId");

                    b.HasIndex("Ability3AbilityId");

                    b.HasIndex("ScenarioId");

                    b.ToTable("Foes");
                });

            modelBuilder.Entity("Encounter.Entities.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CharacterId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("UserId");

                    b.HasKey("GameId");

                    b.HasIndex("CharacterId");

                    b.HasIndex("UserId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Encounter.Entities.Scenario", b =>
                {
                    b.Property<int>("ScenarioId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IconUrl");

                    b.Property<string>("Name");

                    b.HasKey("ScenarioId");

                    b.ToTable("Scenarios");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Encounter.Entities.Character", b =>
                {
                    b.HasOne("Encounter.Entities.Ability", "Ability1")
                        .WithMany()
                        .HasForeignKey("Ability1AbilityId");

                    b.HasOne("Encounter.Entities.Ability", "Ability2")
                        .WithMany()
                        .HasForeignKey("Ability2AbilityId");

                    b.HasOne("Encounter.Entities.Ability", "Ability3")
                        .WithMany()
                        .HasForeignKey("Ability3AbilityId");
                });

            modelBuilder.Entity("Encounter.Entities.Event", b =>
                {
                    b.HasOne("Encounter.Entities.Foe", "Foe")
                        .WithMany("Events")
                        .HasForeignKey("FoeId");

                    b.HasOne("Encounter.Entities.Game", "Game")
                        .WithMany("Events")
                        .HasForeignKey("GameId");

                    b.HasOne("Encounter.Entities.Scenario", "Scenario")
                        .WithMany("Events")
                        .HasForeignKey("ScenarioId");
                });

            modelBuilder.Entity("Encounter.Entities.Foe", b =>
                {
                    b.HasOne("Encounter.Entities.Ability", "Ability1")
                        .WithMany()
                        .HasForeignKey("Ability1AbilityId");

                    b.HasOne("Encounter.Entities.Ability", "Ability2")
                        .WithMany()
                        .HasForeignKey("Ability2AbilityId");

                    b.HasOne("Encounter.Entities.Ability", "Ability3")
                        .WithMany()
                        .HasForeignKey("Ability3AbilityId");

                    b.HasOne("Encounter.Entities.Scenario", "Scenario")
                        .WithMany()
                        .HasForeignKey("ScenarioId");
                });

            modelBuilder.Entity("Encounter.Entities.Game", b =>
                {
                    b.HasOne("Encounter.Entities.Character", "Character")
                        .WithMany()
                        .HasForeignKey("CharacterId");

                    b.HasOne("Encounter.Entities.ApplicationUser", "User")
                        .WithMany("Games")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Encounter.Entities.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Encounter.Entities.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Encounter.Entities.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}

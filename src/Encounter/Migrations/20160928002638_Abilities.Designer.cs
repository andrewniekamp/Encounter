using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Encounter.Entities;

namespace Encounter.Migrations
{
    [DbContext(typeof(EncounterDbContext))]
    [Migration("20160928002638_Abilities")]
    partial class Abilities
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

                    b.Property<int?>("CharacterId");

                    b.Property<string>("Name");

                    b.HasKey("AbilityId");

                    b.HasIndex("CharacterId");

                    b.ToTable("Abilities");
                });

            modelBuilder.Entity("Encounter.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Encounter.Entities.Character", b =>
                {
                    b.Property<int>("CharacterId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("SpriteUrl");

                    b.HasKey("CharacterId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("Encounter.Entities.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CharacterId");

                    b.Property<DateTime>("Created");

                    b.HasKey("GameId");

                    b.HasIndex("CharacterId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Encounter.Entities.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<int?>("GameInstanceGameId");

                    b.Property<string>("Name");

                    b.HasKey("PlayerId");

                    b.HasIndex("GameInstanceGameId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Encounter.Entities.Ability", b =>
                {
                    b.HasOne("Encounter.Entities.Character", "Character")
                        .WithMany("Abilities")
                        .HasForeignKey("CharacterId");
                });

            modelBuilder.Entity("Encounter.Entities.Game", b =>
                {
                    b.HasOne("Encounter.Entities.Character", "Character")
                        .WithMany()
                        .HasForeignKey("CharacterId");
                });

            modelBuilder.Entity("Encounter.Entities.Player", b =>
                {
                    b.HasOne("Encounter.Entities.Game", "GameInstance")
                        .WithMany()
                        .HasForeignKey("GameInstanceGameId");
                });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Encounter.Entities;

namespace Encounter.Migrations
{
    [DbContext(typeof(EncounterDbContext))]
    partial class EncounterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Encounter.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Encounter.Entities.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("PlayerId");

                    b.ToTable("Players");
                });
        }
    }
}

﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Novia.PoliceStationManagement.Infrastructure.Data.Ef;

namespace Novia.PoliceStationManagement.Infrastructure.Data.Ef.Migrations
{
    [DbContext(typeof(PoliceStationManagementDbContext))]
    partial class PoliceStationManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Novia.PoliceStationManagement.Domain.Entities.PoliceStation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Chief");

                    b.Property<string>("Name");

                    b.Property<long>("Workers");

                    b.HasKey("Id");

                    b.ToTable("PoliceStations");
                });
#pragma warning restore 612, 618
        }
    }
}

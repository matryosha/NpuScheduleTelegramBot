﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RozkladNpuAspNetCore.Persistence;

namespace RozkladNpuAspNetCore.Migrations
{
    [DbContext(typeof(RozkladBotContext))]
    partial class BaseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("NpuTimetableParser.Group", b =>
                {
                    b.Property<int>("ExternalId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FacultyShortName");

                    b.Property<string>("FullName");

                    b.Property<string>("RozkladUserGuid");

                    b.Property<string>("ShortName");

                    b.HasKey("ExternalId");

                    b.HasIndex("RozkladUserGuid");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("RozkladNpuAspNetCore.Entities.RozkladUser", b =>
                {
                    b.Property<string>("Guid")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ExternalGroupId");

                    b.Property<string>("FacultyShortName");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("LastAction");

                    b.Property<string>("LastName");

                    b.Property<string>("Name");

                    b.Property<int>("QueryCount");

                    b.Property<int>("TelegramId");

                    b.HasKey("Guid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NpuTimetableParser.Group", b =>
                {
                    b.HasOne("RozkladNpuAspNetCore.Entities.RozkladUser")
                        .WithMany("Groups")
                        .HasForeignKey("RozkladUserGuid");
                });
#pragma warning restore 612, 618
        }
    }
}

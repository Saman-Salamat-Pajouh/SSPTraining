﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SSPTraining.DataAccess.Context;

#nullable disable

namespace SSPTraining.DataAccess.Migrations
{
    [DbContext(typeof(SspTrainingContext))]
    partial class SspTrainingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SSPTraining.Model.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Family")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationDate = new DateTime(2022, 6, 8, 22, 38, 12, 215, DateTimeKind.Local).AddTicks(4386),
                            Family = "Hoorbakht",
                            LastUpdated = new DateTime(2022, 6, 8, 22, 38, 12, 215, DateTimeKind.Local).AddTicks(4386),
                            Name = "Mahyar"
                        },
                        new
                        {
                            Id = 2,
                            CreationDate = new DateTime(2022, 6, 8, 22, 38, 12, 215, DateTimeKind.Local).AddTicks(4389),
                            Family = "Amarlu",
                            LastUpdated = new DateTime(2022, 6, 8, 22, 38, 12, 215, DateTimeKind.Local).AddTicks(4389),
                            Name = "Arezu"
                        });
                });

            modelBuilder.Entity("SSPTraining.Model.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationDate = new DateTime(2022, 6, 8, 22, 38, 12, 215, DateTimeKind.Local).AddTicks(4302),
                            Description = "Admin of Application",
                            LastUpdated = new DateTime(2022, 6, 8, 22, 38, 12, 215, DateTimeKind.Local).AddTicks(4302),
                            Title = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            CreationDate = new DateTime(2022, 6, 8, 22, 38, 12, 215, DateTimeKind.Local).AddTicks(4365),
                            Description = "User of Application",
                            LastUpdated = new DateTime(2022, 6, 8, 22, 38, 12, 215, DateTimeKind.Local).AddTicks(4365),
                            Title = "User"
                        });
                });

            modelBuilder.Entity("SSPTraining.Model.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationDate = new DateTime(2022, 6, 8, 22, 38, 12, 215, DateTimeKind.Local).AddTicks(4407),
                            LastUpdated = new DateTime(2022, 6, 8, 22, 38, 12, 215, DateTimeKind.Local).AddTicks(4407),
                            Password = "c7ad44cbad762a5da0a452f9e854fdc1e0e7a52a38015f23f3eab1d80b931dd472634dfac71cd34ebc35d16ab7fb8a90c81f975113d6c7538dc69dd8de9077ec",
                            PersonId = 1,
                            Username = "admin"
                        },
                        new
                        {
                            Id = 2,
                            CreationDate = new DateTime(2022, 6, 8, 22, 38, 12, 215, DateTimeKind.Local).AddTicks(4681),
                            LastUpdated = new DateTime(2022, 6, 8, 22, 38, 12, 215, DateTimeKind.Local).AddTicks(4681),
                            Password = "5dcd58b93f68aea2077c8fdeb74473aa1882ffc7b5a4bf8e73109f92301e93d8502c111388b81bbfeae16dbb740f777ee09cb1fabd88229adb22f8847a181e47",
                            PersonId = 2,
                            Username = "a.amarlu"
                        });
                });

            modelBuilder.Entity("SSPTraining.Model.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationDate = new DateTime(2022, 6, 8, 22, 38, 12, 215, DateTimeKind.Local).AddTicks(4742),
                            LastUpdated = new DateTime(2022, 6, 8, 22, 38, 12, 215, DateTimeKind.Local).AddTicks(4742),
                            RoleId = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreationDate = new DateTime(2022, 6, 8, 22, 38, 12, 215, DateTimeKind.Local).AddTicks(4746),
                            LastUpdated = new DateTime(2022, 6, 8, 22, 38, 12, 215, DateTimeKind.Local).AddTicks(4746),
                            RoleId = 2,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("SSPTraining.Model.Views.UserRolesView", b =>
                {
                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.ToView("UserRolesView");
                });

            modelBuilder.Entity("SSPTraining.Model.Entities.User", b =>
                {
                    b.HasOne("SSPTraining.Model.Entities.Person", "Person")
                        .WithOne("User")
                        .HasForeignKey("SSPTraining.Model.Entities.User", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("SSPTraining.Model.Entities.UserRole", b =>
                {
                    b.HasOne("SSPTraining.Model.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SSPTraining.Model.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SSPTraining.Model.Entities.Person", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("SSPTraining.Model.Entities.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("SSPTraining.Model.Entities.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
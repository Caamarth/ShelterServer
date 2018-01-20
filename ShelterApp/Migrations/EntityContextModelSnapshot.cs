﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using ShelterApp.Enums;
using ShelterApp.Models;
using System;

namespace ShelterApp.Migrations
{
    [DbContext(typeof(EntityContext))]
    partial class EntityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShelterApp.Models.AnimalEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AdmissionDate");

                    b.Property<DateTime>("BirthDate");

                    b.Property<int>("Classification");

                    b.Property<string>("Description");

                    b.Property<double>("Height");

                    b.Property<double>("Length");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Race")
                        .IsRequired();

                    b.Property<int>("RaceType");

                    b.Property<int>("Sex");

                    b.Property<double>("Weight");

                    b.Property<double>("Width");

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("ShelterApp.Models.Apply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AnimalEntityId");

                    b.Property<int>("ApplyStatus");

                    b.Property<string>("Description");

                    b.Property<DateTime>("PublishDate");

                    b.Property<int>("UserEntityId");

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.HasIndex("AnimalEntityId");

                    b.HasIndex("UserEntityId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("ShelterApp.Models.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApplyId");

                    b.Property<double>("RatingValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ApplyId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("ShelterApp.Models.Study", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApplyId");

                    b.Property<string>("Description");

                    b.Property<DateTime>("PublishDate");

                    b.Property<double>("Rating");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ApplyId");

                    b.ToTable("Studies");
                });

            modelBuilder.Entity("ShelterApp.Models.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("Birthdate");

                    b.Property<string>("EmailAddress");

                    b.Property<string>("Firstname");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Lastname");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Role");

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ShelterApp.Models.Apply", b =>
                {
                    b.HasOne("ShelterApp.Models.AnimalEntity", "AnimalEntity")
                        .WithMany("Applications")
                        .HasForeignKey("AnimalEntityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShelterApp.Models.UserEntity", "UserEntity")
                        .WithMany("Applies")
                        .HasForeignKey("UserEntityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShelterApp.Models.Rating", b =>
                {
                    b.HasOne("ShelterApp.Models.Apply")
                        .WithMany("Ratings")
                        .HasForeignKey("ApplyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShelterApp.Models.Study", b =>
                {
                    b.HasOne("ShelterApp.Models.Apply", "Apply")
                        .WithMany("Studies")
                        .HasForeignKey("ApplyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

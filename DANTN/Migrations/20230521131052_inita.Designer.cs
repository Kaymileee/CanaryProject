﻿// <auto-generated />
using System;
using DANTN.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DANTN.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230521131052_inita")]
    partial class inita
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DANTN.Data.Entities.Level", b =>
                {
                    b.Property<int?>("LevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("LevelId"));

                    b.Property<string>("LevelName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Point")
                        .HasColumnType("int");

                    b.HasKey("LevelId");

                    b.ToTable("Levels", (string)null);

                    b.HasData(
                        new
                        {
                            LevelId = 0,
                            LevelName = "Level 1"
                        });
                });

            modelBuilder.Entity("DANTN.Data.Entities.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestionId"));

                    b.Property<string>("Answer_1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer_2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer_3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer_4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IsCorrect")
                        .HasColumnType("int");

                    b.Property<string>("QuesURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuestionString")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TopicId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("isTuluan")
                        .HasColumnType("bit");

                    b.HasKey("QuestionId");

                    b.HasIndex("TopicId");

                    b.ToTable("Questions", (string)null);

                    b.HasData(
                        new
                        {
                            QuestionId = 1,
                            Answer_1 = "Apple",
                            Answer_2 = "Banana",
                            Answer_3 = "Lemon",
                            Answer_4 = "Kiwi",
                            ImageURL = "",
                            IsCorrect = 0,
                            QuestionString = "This is a test question",
                            TopicId = "TPFruits",
                            isTuluan = false
                        },
                        new
                        {
                            QuestionId = 2,
                            Answer_1 = "Apple",
                            Answer_2 = "",
                            Answer_3 = "",
                            Answer_4 = "",
                            ImageURL = "",
                            IsCorrect = 0,
                            QuestionString = "Số táo viết như thế nào",
                            TopicId = "TPFruits",
                            isTuluan = true
                        });
                });

            modelBuilder.Entity("DANTN.Data.Entities.Topic", b =>
                {
                    b.Property<string>("TopicId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("LevelId")
                        .HasColumnType("int");

                    b.Property<string>("NameTopic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentID")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TopicAlias")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TopicDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TopicImage")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ViewCount")
                        .HasMaxLength(255)
                        .HasColumnType("int");

                    b.HasKey("TopicId");

                    b.HasIndex("LevelId");

                    b.ToTable("Topics", (string)null);

                    b.HasData(
                        new
                        {
                            TopicId = "TPFruits",
                            NameTopic = "Fruits",
                            ParentID = "TP01",
                            TopicAlias = "aaa",
                            TopicDesc = "lorem abc das das was we awen",
                            TopicImage = "https://example.com/avatar.jpg",
                            ViewCount = 0
                        });
                });

            modelBuilder.Entity("DANTN.Data.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("EmailConfirm")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("LevelId")
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Point")
                        .HasColumnType("int");

                    b.Property<int>("Role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.HasIndex("LevelId");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("f75de9b6-51cd-4578-bfac-8d5eec4068b5"),
                            Avatar = "https://example.com/avatar.jpg",
                            DateTimeCreated = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Dob = new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@example.com",
                            EmailConfirm = true,
                            FirstName = "John",
                            LastLogin = new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Doe",
                            LevelId = 0,
                            PasswordHash = "0E7517141FB53F21EE439B355B5A1D0A",
                            Role = 0,
                            UserName = "admin"
                        },
                        new
                        {
                            UserId = new Guid("91a2cca2-7bf1-451b-a47e-9f33ad54bd3c"),
                            Avatar = "https://example.com/avatar2.jpg",
                            DateTimeCreated = new DateTime(2022, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Dob = new DateTime(1985, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "user1@example.com",
                            EmailConfirm = true,
                            FirstName = "Jane",
                            LastLogin = new DateTime(2023, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Doe",
                            LevelId = 0,
                            PasswordHash = "0E7517141FB53F21EE439B355B5A1D0A",
                            Role = 1,
                            UserName = "user1"
                        });
                });

            modelBuilder.Entity("DANTN.Data.Entities.Vocabulary", b =>
                {
                    b.Property<int>("VocId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VocId"));

                    b.Property<string>("TopicId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("WordVoc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("level")
                        .HasMaxLength(255)
                        .HasColumnType("int");

                    b.Property<string>("typeVoc")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("vocExample")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("vocIPA")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("vocImgUrl")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("VocId");

                    b.HasIndex("TopicId");

                    b.ToTable("Vocabularies", (string)null);

                    b.HasData(
                        new
                        {
                            VocId = 1,
                            TopicId = "TPFruits",
                            WordVoc = "Orange",
                            level = 1,
                            typeVoc = "N",
                            vocExample = "This is my orange",
                            vocIPA = "orange",
                            vocImgUrl = "https://example.com/avatar.jpg"
                        });
                });

            modelBuilder.Entity("DANTN.Data.Entities.Question", b =>
                {
                    b.HasOne("DANTN.Data.Entities.Topic", "Topic")
                        .WithMany()
                        .HasForeignKey("TopicId");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("DANTN.Data.Entities.Topic", b =>
                {
                    b.HasOne("DANTN.Data.Entities.Level", "Level")
                        .WithMany()
                        .HasForeignKey("LevelId");

                    b.Navigation("Level");
                });

            modelBuilder.Entity("DANTN.Data.Entities.User", b =>
                {
                    b.HasOne("DANTN.Data.Entities.Level", "Level")
                        .WithMany()
                        .HasForeignKey("LevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Level");
                });

            modelBuilder.Entity("DANTN.Data.Entities.Vocabulary", b =>
                {
                    b.HasOne("DANTN.Data.Entities.Topic", "Topic")
                        .WithMany()
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Topic");
                });
#pragma warning restore 612, 618
        }
    }
}

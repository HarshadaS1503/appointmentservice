﻿// <auto-generated />
using System;
using LoginService.EFCoreSetUp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LoginService.Migrations
{
    [DbContext(typeof(LoginContext))]
    partial class LoginContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LoginService.Models.Gender", b =>
                {
                    b.Property<int>("GenderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GenderCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GenderName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenderID");

                    b.ToTable("Gender");
                });

            modelBuilder.Entity("LoginService.Models.Roles", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("LoginService.Models.Status", b =>
                {
                    b.Property<int>("StatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatusCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusID");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("LoginService.Models.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenderID")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoginAttempts")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<int>("StatusID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("created_by")
                        .HasColumnType("int");

                    b.Property<DateTime>("created_on")
                        .HasColumnType("datetime2");

                    b.Property<int>("updated_by")
                        .HasColumnType("int");

                    b.Property<DateTime>("updated_on")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId");

                    b.HasIndex("GenderID");

                    b.HasIndex("RoleID");

                    b.HasIndex("StatusID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LoginService.Models.Users", b =>
                {
                    b.HasOne("LoginService.Models.Gender", "Gender")
                        .WithMany("Users")
                        .HasForeignKey("GenderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LoginService.Models.Roles", "Roles")
                        .WithMany("Users")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LoginService.Models.Status", "Status")
                        .WithMany("Users")
                        .HasForeignKey("StatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyClinicApp.DAL.DBContext;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MyClinicApp.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230112041150_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("MyClinicApp.DAL.Models.AppointmentModel", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("DoctorID")
                        .HasColumnType("numeric(20,0)");

                    b.Property<string>("FinishTime")
                        .HasColumnType("text");

                    b.Property<decimal>("PatientID")
                        .HasColumnType("numeric(20,0)");

                    b.Property<string>("StartTime")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("MyClinicApp.DAL.Models.DoctorModel", b =>
                {
                    b.Property<decimal>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(20,0)");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<decimal?>("SpecializationID")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("ID");

                    b.HasIndex("SpecializationID");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("MyClinicApp.DAL.Models.TimetableModel", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("DoctorID")
                        .HasColumnType("bigint");

                    b.Property<string>("FinishTime")
                        .HasColumnType("text");

                    b.Property<string>("StartTime")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Timetables");
                });

            modelBuilder.Entity("MyClinicApp.DAL.Models.UserModel", b =>
                {
                    b.Property<decimal>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(20,0)");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<decimal>("PhoneNumber")
                        .HasColumnType("numeric(20,0)");

                    b.Property<decimal?>("RoleID")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("ID");

                    b.HasIndex("RoleID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MyClinicApp.Domain.Classes.Role", b =>
                {
                    b.Property<decimal>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("ID");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("MyClinicApp.Domain.Classes.Specialization", b =>
                {
                    b.Property<decimal>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(20,0)");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Specialization");
                });

            modelBuilder.Entity("MyClinicApp.DAL.Models.DoctorModel", b =>
                {
                    b.HasOne("MyClinicApp.Domain.Classes.Specialization", "Specialization")
                        .WithMany()
                        .HasForeignKey("SpecializationID");
                });

            modelBuilder.Entity("MyClinicApp.DAL.Models.UserModel", b =>
                {
                    b.HasOne("MyClinicApp.Domain.Classes.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID");
                });
#pragma warning restore 612, 618
        }
    }
}

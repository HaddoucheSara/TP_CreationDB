﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TP_CreationDB.Data;

#nullable disable

namespace TP_CreationDB.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250402195618_AddTeacherSubjectView")]
    partial class AddTeacherSubjectView
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TP_CreationDB.Models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("TP_CreationDB.Models.Enrollment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ClassId");

                    b.HasIndex("StudentId");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("TP_CreationDB.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonType")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasDiscriminator<string>("PersonType").HasValue("Person");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("TP_CreationDB.Models.Subject", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("TP_CreationDB.Vues.TeacherSubjectView", b =>
                {
                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<string>("TeacherLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable((string)null);

                    b.ToView("V_Teacher_Subject", (string)null);
                });

            modelBuilder.Entity("TP_CreationDB.Models.Student", b =>
                {
                    b.HasBaseType("TP_CreationDB.Models.Person");

                    b.Property<int>("StudentNumber")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("TP_CreationDB.Models.Teacher", b =>
                {
                    b.HasBaseType("TP_CreationDB.Models.Person");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasIndex("SubjectId");

                    b.HasDiscriminator().HasValue("Teacher");
                });

            modelBuilder.Entity("TP_CreationDB.Models.Class", b =>
                {
                    b.HasOne("TP_CreationDB.Models.Teacher", "Teacher")
                        .WithMany("Classes")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("TP_CreationDB.Models.Enrollment", b =>
                {
                    b.HasOne("TP_CreationDB.Models.Class", "Classe")
                        .WithMany("Enrollments")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TP_CreationDB.Models.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classe");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("TP_CreationDB.Models.Teacher", b =>
                {
                    b.HasOne("TP_CreationDB.Models.Subject", "Subject")
                        .WithMany("Teachers")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("TP_CreationDB.Models.Class", b =>
                {
                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("TP_CreationDB.Models.Subject", b =>
                {
                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("TP_CreationDB.Models.Student", b =>
                {
                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("TP_CreationDB.Models.Teacher", b =>
                {
                    b.Navigation("Classes");
                });
#pragma warning restore 612, 618
        }
    }
}

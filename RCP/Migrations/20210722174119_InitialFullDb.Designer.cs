﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RCP.Data;

namespace RCP.Migrations
{
    [DbContext(typeof(RCPDbContext))]
    [Migration("20210722174119_InitialFullDb")]
    partial class InitialFullDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RCP.Models.ActiveMeasurement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTimeStart")
                        .HasColumnName("DateTimeStart")
                        .HasColumnType("datetime");

                    b.Property<int>("MeasurementId")
                        .HasColumnName("MeasurementId");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnName("UserId")
                        .HasMaxLength(8);

                    b.HasKey("Id");

                    b.ToTable("ActiveMeasurements");
                });

            modelBuilder.Entity("RCP.Models.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("Description")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasMaxLength(255);

                    b.Property<int>("ProjectId")
                        .HasColumnName("ProjectId");

                    b.Property<int>("QuestionnaireId")
                        .HasColumnName("QuestionnaireId");

                    b.HasKey("Id");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("RCP.Models.Measurement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActivityId")
                        .HasColumnName("ActivityId");

                    b.Property<DateTime>("DateTimeEnd")
                        .HasColumnName("DateTimeEnd")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateTimeStart")
                        .HasColumnName("DateTimeStart")
                        .HasColumnType("datetime");

                    b.Property<int>("Seconds")
                        .HasColumnName("Seconds");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnName("UserId")
                        .HasMaxLength(8);

                    b.HasKey("Id");

                    b.ToTable("Measurements");
                });

            modelBuilder.Entity("RCP.Models.MeasurementQuestionnaireAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MeasurementId")
                        .HasColumnName("MeasurementId");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnName("Value");

                    b.HasKey("Id");

                    b.ToTable("MeasurementQuestionnaireAnswers");
                });

            modelBuilder.Entity("RCP.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTimeEnd")
                        .HasColumnName("DateTimeEnd")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateTimeStart")
                        .HasColumnName("DateTimeStart")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("Description")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("RCP.Models.Questionnaire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("Description")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasMaxLength(255);

                    b.Property<int>("ProjectId")
                        .HasColumnName("ProjectId");

                    b.Property<bool>("QuestionRequired")
                        .HasColumnName("QuestionRequired")
                        .HasColumnType("bit");

                    b.Property<int>("QuestionType")
                        .HasColumnName("QuestionType")
                        .HasColumnType("int");

                    b.Property<string>("QuestionValue")
                        .IsRequired()
                        .HasColumnName("QuestionValue");

                    b.HasKey("Id");

                    b.ToTable("Questionnaires");
                });

            modelBuilder.Entity("RCP.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("RCP.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasMaxLength(8);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("FirstName")
                        .HasMaxLength(20);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("LastName")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RCP.Models.UserProjectRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProjectId")
                        .HasColumnName("ProjectId");

                    b.Property<int>("RoleId")
                        .HasColumnName("RoleId");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnName("UserId")
                        .HasMaxLength(8);

                    b.HasKey("Id");

                    b.ToTable("UserProjectRoles");
                });
#pragma warning restore 612, 618
        }
    }
}

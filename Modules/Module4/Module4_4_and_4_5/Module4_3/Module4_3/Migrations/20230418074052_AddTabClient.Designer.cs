﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Module4_3;

#nullable disable

namespace Module4_3.Migrations
{
    [DbContext(typeof(ConsoleApplicationContext))]
    [Migration("20230418074052_AddTabClient")]
    partial class AddTabClient
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Module4_3.DbModels.Client", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ClientId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Client", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Good client",
                            Mail = "client1@gmail.com",
                            Name = "Client1",
                            Phone = "000-000-00-01"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Good client",
                            Mail = "client2@gmail.com",
                            Name = "Client2",
                            Phone = "000-000-00-02"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Good client",
                            Mail = "client3@gmail.com",
                            Name = "Client3",
                            Phone = "000-000-00-03"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Good client",
                            Mail = "client4@gmail.com",
                            Name = "Client4",
                            Phone = "000-000-00-04"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Good client",
                            Mail = "client5@gmail.com",
                            Name = "Client5",
                            Phone = "000-000-00-05"
                        });
                });

            modelBuilder.Entity("Module4_3.DbModels.Employee", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("EmployeeId");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("FirstName");

                    b.Property<DateTime>("HiredDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("OfficeId")
                        .HasColumnType("int");

                    b.Property<int>("TitleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId");

                    b.HasIndex("TitleId");

                    b.ToTable("Employee", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfBirth = new DateTime(1985, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Olha",
                            HiredDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Pinchuk",
                            OfficeId = 1,
                            TitleId = 1
                        },
                        new
                        {
                            Id = 2,
                            DateOfBirth = new DateTime(2000, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Maria",
                            HiredDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Glamazda",
                            OfficeId = 1,
                            TitleId = 1
                        },
                        new
                        {
                            Id = 3,
                            DateOfBirth = new DateTime(1984, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Anatolii",
                            HiredDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Anatolii",
                            OfficeId = 1,
                            TitleId = 1
                        },
                        new
                        {
                            Id = 4,
                            DateOfBirth = new DateTime(1995, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Olha",
                            HiredDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Ilchuk",
                            OfficeId = 1,
                            TitleId = 1
                        },
                        new
                        {
                            Id = 5,
                            DateOfBirth = new DateTime(2012, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Kateryna",
                            HiredDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Pinchuk",
                            OfficeId = 1,
                            TitleId = 1
                        });
                });

            modelBuilder.Entity("Module4_3.DbModels.EmployeeProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EmployeeProjectId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<decimal>("Rate")
                        .HasColumnType("money");

                    b.Property<DateTime>("StartedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProjectId");

                    b.ToTable("EmployeeProject", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmployeeId = 2,
                            ProjectId = 2,
                            Rate = 20m,
                            StartedDate = new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            EmployeeId = 3,
                            ProjectId = 4,
                            Rate = 15m,
                            StartedDate = new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            EmployeeId = 1,
                            ProjectId = 4,
                            Rate = 18m,
                            StartedDate = new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            EmployeeId = 5,
                            ProjectId = 1,
                            Rate = 17m,
                            StartedDate = new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            EmployeeId = 3,
                            ProjectId = 1,
                            Rate = 15m,
                            StartedDate = new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Module4_3.DbModels.Office", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("OfficeId");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Office", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Location = "Kyiv",
                            Title = "New office"
                        },
                        new
                        {
                            Id = 2,
                            Location = "Lviv",
                            Title = "Old office"
                        },
                        new
                        {
                            Id = 3,
                            Location = "Varshava",
                            Title = "Poland office"
                        },
                        new
                        {
                            Id = 4,
                            Location = "London",
                            Title = "British office"
                        },
                        new
                        {
                            Id = 5,
                            Location = "New-York",
                            Title = "USA office"
                        });
                });

            modelBuilder.Entity("Module4_3.DbModels.Project", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ProjectId");

                    b.Property<decimal>("Budget")
                        .HasColumnType("money");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("StartedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Project", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Budget = 20000m,
                            ClientId = 5,
                            Name = "One game",
                            StartedDate = new DateTime(2000, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Budget = 30000m,
                            ClientId = 4,
                            Name = "Second game",
                            StartedDate = new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Budget = 100000m,
                            ClientId = 3,
                            Name = "Business1",
                            StartedDate = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Budget = 150000m,
                            ClientId = 2,
                            Name = "Business2",
                            StartedDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            Budget = 1000m,
                            ClientId = 1,
                            Name = "Business3",
                            StartedDate = new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Module4_3.DbModels.Title", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Title", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Developer"
                        },
                        new
                        {
                            Id = 2,
                            Name = "QA Engineer"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Manager"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Scrum master"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Asistent"
                        });
                });

            modelBuilder.Entity("Module4_3.DbModels.Employee", b =>
                {
                    b.HasOne("Module4_3.DbModels.Office", "Office")
                        .WithMany("Employees")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Module4_3.DbModels.Title", "Title")
                        .WithMany()
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Office");

                    b.Navigation("Title");
                });

            modelBuilder.Entity("Module4_3.DbModels.EmployeeProject", b =>
                {
                    b.HasOne("Module4_3.DbModels.Employee", "Employee")
                        .WithMany("EmployeeProject")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Module4_3.DbModels.Project", "Project")
                        .WithMany("EmployeeProject")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Module4_3.DbModels.Project", b =>
                {
                    b.HasOne("Module4_3.DbModels.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Module4_3.DbModels.Employee", b =>
                {
                    b.Navigation("EmployeeProject");
                });

            modelBuilder.Entity("Module4_3.DbModels.Office", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Module4_3.DbModels.Project", b =>
                {
                    b.Navigation("EmployeeProject");
                });
#pragma warning restore 612, 618
        }
    }
}

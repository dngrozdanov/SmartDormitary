﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartDormitary.Data.Context;

namespace SmartDormitary.Data.Migrations
{
    [DbContext(typeof(SmartDormitaryContext))]
    partial class SmartDormitaryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SmartDormitary.Data.Models.Sensor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<bool>("IsPublic");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("RefreshTime");

                    b.Property<Guid>("SensorTypeId");

                    b.Property<DateTime?>("Timestamp");

                    b.Property<string>("UserId");

                    b.Property<string>("Value")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("SensorTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Sensors");
                });

            modelBuilder.Entity("SmartDormitary.Data.Models.SensorType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<int>("MaxAcceptableValue");

                    b.Property<string>("MeasurementType")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("MinAcceptableValue");

                    b.Property<int>("MinRefreshTime");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("SensorTypes");

                    b.HasData(
                        new { Id = new Guid("f1796a28-642e-401f-8129-fd7465417061"), Description = "This sensor will return values between 15 and 28", MaxAcceptableValue = 28, MeasurementType = "°C", MinAcceptableValue = 15, MinRefreshTime = 40, Tag = "TemperatureSensor1" },
                        new { Id = new Guid("81a2e1b1-ea5d-4356-8266-b6b42471653e"), Description = "This sensor will return values between 6 and 18", MaxAcceptableValue = 18, MeasurementType = "°C", MinAcceptableValue = 6, MinRefreshTime = 30, Tag = "TemperatureSensor2" },
                        new { Id = new Guid("92f7dc9a-f2fe-4b60-82f5-400e42f099b4"), Description = "This sensor will return values between 19 and 23", MaxAcceptableValue = 23, MeasurementType = "°C", MinAcceptableValue = 19, MinRefreshTime = 70, Tag = "TemperatureSensor3" },
                        new { Id = new Guid("216fc1e7-1496-4532-b9ee-29565b865ad6"), Description = "This sensor will return values between 0 and 60", MaxAcceptableValue = 60, MeasurementType = "%", MinAcceptableValue = 0, MinRefreshTime = 40, Tag = "HumiditySensor1" },
                        new { Id = new Guid("61ff0614-64fd-4842-9a05-0b1541d2cc61"), Description = "This sensor will return values between 10 and 90", MaxAcceptableValue = 90, MeasurementType = "%", MinAcceptableValue = 10, MinRefreshTime = 50, Tag = "HumiditySensor2" },
                        new { Id = new Guid("08503c1c-963f-4106-9088-82fa67d34f9d"), Description = "This sensor will return values between 1000 and 5000", MaxAcceptableValue = 5000, MeasurementType = "W", MinAcceptableValue = 1000, MinRefreshTime = 70, Tag = "ElectricPowerConsumtionSensor1" },
                        new { Id = new Guid("1f0ef0ff-396b-40cb-ac3d-749196dee187"), Description = "This sensor will return values between 500 and 3500", MaxAcceptableValue = 3500, MeasurementType = "W", MinAcceptableValue = 500, MinRefreshTime = 105, Tag = "ElectricPowerConsumtionSensor2" },
                        new { Id = new Guid("4008e030-fd3a-4f8c-a8ca-4f7609ecdb1e"), Description = "This sensor will return true or false value", MaxAcceptableValue = 1, MeasurementType = "(true/false)", MinAcceptableValue = 0, MinRefreshTime = 50, Tag = "OccupancySensor1" },
                        new { Id = new Guid("7a3b1db5-959d-46ce-82b6-517773327427"), Description = "This sensor will return true or false value", MaxAcceptableValue = 1, MeasurementType = "(true/false)", MinAcceptableValue = 0, MinRefreshTime = 80, Tag = "OccupancySensor2" },
                        new { Id = new Guid("a3b8a078-0409-4365-ace6-6f8b5b93d592"), Description = "This sensor will return true or false value", MaxAcceptableValue = 1, MeasurementType = "(true/false)", MinAcceptableValue = 0, MinRefreshTime = 90, Tag = "DoorSensor1" },
                        new { Id = new Guid("ec3c4770-5d57-4d81-9c83-a02140b883a1"), Description = "This sensor will return true or false value", MaxAcceptableValue = 1, MeasurementType = "(true/false)", MinAcceptableValue = 0, MinRefreshTime = 50, Tag = "DoorSensor2" },
                        new { Id = new Guid("d5d37a46-8ab5-41ec-b7d5-d28c2fd68d3d"), Description = "This sensor will return values between 20 and 70", MaxAcceptableValue = 70, MeasurementType = "dB", MinAcceptableValue = 20, MinRefreshTime = 40, Tag = "NoiseSensor1" },
                        new { Id = new Guid("65d98ff7-b524-49de-8d13-f85753d98858"), Description = "This sensor will return values between 40 and 90", MaxAcceptableValue = 90, MeasurementType = "dB", MinAcceptableValue = 40, MinRefreshTime = 85, Tag = "NoiseSensor2" }
                    );
                });

            modelBuilder.Entity("SmartDormitary.Data.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SmartDormitary.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SmartDormitary.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SmartDormitary.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SmartDormitary.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SmartDormitary.Data.Models.Sensor", b =>
                {
                    b.HasOne("SmartDormitary.Data.Models.SensorType", "SensorType")
                        .WithMany()
                        .HasForeignKey("SensorTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SmartDormitary.Data.Models.User", "User")
                        .WithMany("Sensors")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}

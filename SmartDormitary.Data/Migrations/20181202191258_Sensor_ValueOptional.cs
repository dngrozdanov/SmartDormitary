﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartDormitary.Data.Migrations
{
    public partial class Sensor_ValueOptional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                "AspNetRoles",
                new[] {"Id", "ConcurrencyStamp"},
                new object[] {"72c3f103-7479-464b-9a72-6e8b982fc71d", "8bfb962e-c8a6-4498-b482-01fa080fa42b"});

            migrationBuilder.DeleteData(
                "AspNetRoles",
                new[] {"Id", "ConcurrencyStamp"},
                new object[] {"759094a7-e427-4794-ba83-33bdcf3fe64a", "a9b16ad2-01e4-41d5-8e42-430249b32960"});

            migrationBuilder.AlterColumn<string>(
                "Value",
                "Sensors",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                "Value",
                "Sensors",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                "AspNetRoles",
                new[] {"Id", "ConcurrencyStamp", "Name", "NormalizedName"},
                new object[]
                {
                    "759094a7-e427-4794-ba83-33bdcf3fe64a", "a9b16ad2-01e4-41d5-8e42-430249b32960", "Administrator",
                    "ADMINISTRATOR"
                });

            migrationBuilder.InsertData(
                "AspNetRoles",
                new[] {"Id", "ConcurrencyStamp", "Name", "NormalizedName"},
                new object[]
                    {"72c3f103-7479-464b-9a72-6e8b982fc71d", "8bfb962e-c8a6-4498-b482-01fa080fa42b", "User", "USER"});
        }
    }
}
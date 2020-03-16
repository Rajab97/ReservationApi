﻿// <auto-generated />
using System;
using MeetingRoomApi.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MeetingRoomApi.Migrations
{
    [DbContext(typeof(MeetingRoomDbContext))]
    [Migration("20200210085345_AddRolesToMembers")]
    partial class AddRolesToMembers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MeetingRoomApi.Models.MeetingRoom", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnName("MeetingRoom_Id");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("MeetingRooms");
                });

            modelBuilder.Entity("MeetingRoomApi.Models.Member", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Member_Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.ToTable("Members");

                    b.HasData(
                        new
                        {
                            Id = (short)1,
                            Name = "Receb",
                            Password = "$2b$10$jTemwN6w1KbCQDDEmTOmL.nxkbV8zE31ZT9/J5pkamI7Lhn52G6KK",
                            Surname = "Qarayev",
                            UserName = "Rajab97"
                        },
                        new
                        {
                            Id = (short)2,
                            Name = "Test",
                            Password = "$2b$10$SQj/SOCJmsLzT3A8/ieDzeVERHsfDWYizWEahZ3CuVAXThgN.drDW",
                            Surname = "Test",
                            UserName = "Test123"
                        });
                });

            modelBuilder.Entity("MeetingRoomApi.Models.Role", b =>
                {
                    b.Property<byte>("Id");

                    b.Property<string>("Name")
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = (byte)2,
                            Name = "Administrator"
                        },
                        new
                        {
                            Id = (byte)3,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("MeetingRoomApi.Models.RoomReservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("RoomReservation_Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<bool>("IsActive");

                    b.Property<byte>("MeetingRoomId")
                        .HasColumnName("MeetingRoom_Id");

                    b.Property<short>("MemberId")
                        .HasColumnName("Member_Id");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("date");

                    b.Property<short>("TimeId")
                        .HasColumnName("Time_Id");

                    b.Property<string>("Title")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasAlternateKey("ReservationDate", "TimeId", "MeetingRoomId");

                    b.HasIndex("MeetingRoomId");

                    b.HasIndex("MemberId");

                    b.HasIndex("TimeId");

                    b.ToTable("RoomReservations");
                });

            modelBuilder.Entity("MeetingRoomApi.Models.Time", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ValidRoomTime_Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("EndTime")
                        .IsRequired();

                    b.Property<DateTime?>("StartTime")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("StartTime", "EndTime");

                    b.ToTable("ValidRoomTimes");
                });

            modelBuilder.Entity("MeetingRoomApi.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("MemberId");

                    b.Property<byte>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MemberId = (short)1,
                            RoleId = (byte)2
                        },
                        new
                        {
                            Id = 2,
                            MemberId = (short)2,
                            RoleId = (byte)3
                        });
                });

            modelBuilder.Entity("MeetingRoomApi.Models.RoomReservation", b =>
                {
                    b.HasOne("MeetingRoomApi.Models.MeetingRoom", "MeetingRoom")
                        .WithMany("RoomReservations")
                        .HasForeignKey("MeetingRoomId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MeetingRoomApi.Models.Member", "Member")
                        .WithMany("RoomReservations")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MeetingRoomApi.Models.Time", "Time")
                        .WithMany("RoomReservations")
                        .HasForeignKey("TimeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MeetingRoomApi.Models.UserRole", b =>
                {
                    b.HasOne("MeetingRoomApi.Models.Member", "Member")
                        .WithMany("UserRoles")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MeetingRoomApi.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

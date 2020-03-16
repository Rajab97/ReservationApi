using MeetingRoomApi.Helpers;
using MeetingRoomApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingRoomApi.DAL.EncryptionHelper;
namespace MeetingRoomApi.DAL
{
    public class MeetingRoomDbContext : DbContext
    {
        public MeetingRoomDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<RoomReservation>().HasAlternateKey(m => new { m.ReservationDate, m.TimeId, m.MeetingRoomId});
            modelBuilder.Entity<Time>().HasAlternateKey(m => new { m.StartTime, m.EndTime });

            modelBuilder.Entity<Role>().HasData(
                new Role() { Id = (byte)2, Name = Helpers.Roles.Administrator },
                new Role() { Id = (byte)3, Name = Helpers.Roles.User });

            modelBuilder.Entity<Member>().HasData(
                new Member()
                {
                    Id = (short)1,
                    Name = "Receb",
                    Surname = "Qarayev",
                    UserName = "Rajab97",
                    Password = "admin".EncryptWithBCrypt()
                });
            modelBuilder.Entity<Member>().HasData(
                new Member()
                {
                    Id = (short)2,
                    Name = "Test",
                    Surname = "Test",
                    UserName = "Test123",
                    Password = "user".EncryptWithBCrypt()
                });

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole() { Id = 1, MemberId = (short)1, RoleId = (byte)2 },
                new UserRole() { Id = 2, MemberId = (short)2, RoleId = (byte)3 });

            modelBuilder.Entity<MeetingRoom>().HasData(new MeetingRoom() { Id = 1, RoomName = "Main Room" });
            modelBuilder.Entity<Time>().HasData(
                new Time { Id = 1, StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(9, 30, 0) },
                new Time { Id = 2, StartTime = new TimeSpan(9, 30, 0), EndTime = new TimeSpan(10, 0, 0) },
                new Time { Id = 3, StartTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(10, 30, 0) },
                new Time { Id = 4, StartTime = new TimeSpan(10, 30, 0), EndTime = new TimeSpan(11, 0, 0) },
                new Time { Id = 5, StartTime = new TimeSpan(11, 0, 0), EndTime = new TimeSpan(11, 30, 0) },
                new Time { Id = 6, StartTime = new TimeSpan(11, 30, 0), EndTime = new TimeSpan(12, 0, 0) },
                new Time { Id = 7, StartTime = new TimeSpan(12, 0, 0), EndTime = new TimeSpan(12, 30, 0) },
                new Time { Id = 8, StartTime = new TimeSpan(12, 30, 0), EndTime = new TimeSpan(13, 0, 0) },
                new Time { Id = 9, StartTime = new TimeSpan(14, 0, 0), EndTime = new TimeSpan(14, 30, 0) },
                new Time { Id = 10, StartTime = new TimeSpan(14, 30, 0), EndTime = new TimeSpan(15, 0, 0) },
                new Time { Id = 11, StartTime = new TimeSpan(15, 0, 0), EndTime = new TimeSpan(15, 30, 0) },
                new Time { Id = 12, StartTime = new TimeSpan(15, 30, 0), EndTime = new TimeSpan(16, 0, 0) },
                new Time { Id = 13, StartTime = new TimeSpan(16, 0, 0), EndTime = new TimeSpan(16, 30, 0) },
                new Time { Id = 14, StartTime = new TimeSpan(16, 30, 0), EndTime = new TimeSpan(17, 0, 0) },
                new Time { Id = 15, StartTime = new TimeSpan(17, 0, 0), EndTime = new TimeSpan(17, 30, 0) },
                new Time { Id = 16, StartTime = new TimeSpan(17, 30, 0), EndTime = new TimeSpan(18, 0, 0) });

        }

        public DbSet<MeetingRoom> MeetingRooms { get; set; }

        public DbSet<Member> Members { get; set; }
        public DbSet<Time> ValidTimes { get; set; }
        public DbSet<RoomReservation> Reservations { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<Models.Role> Roles { get; set; }
    }
}

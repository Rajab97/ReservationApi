using MeetingRoomApi.DAL;
using MeetingRoomApi.Models;
using MeetingRoomApi.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.DAL
{
    public class RoomReservationRepository : BaseRepository, IRoomReservationRepository
    {
        public RoomReservationRepository(MeetingRoomDbContext contex) :base(contex) { }

        public async Task<RoomReservation> Create(RoomReservation obj)
        {
             await _context.Reservations.AddAsync(obj);
            return obj;
        }
         
        public async Task Delete(int Id)
        {
            RoomReservation reservation = await GetRoomReservation(Id);
            _context.Reservations.Remove(reservation);
        }

   

        public IQueryable<RoomReservation> GetAllRoomReservations()
        {
            return _context.Reservations;
        }

        public async Task<RoomReservation> GetRoomReservation(int Id)
        {
            return await _context.Reservations.FirstOrDefaultAsync(m => m.Id == Id);
        }

        public async Task<RoomReservation> Update(int Id, RoomReservation obj)
        {
            RoomReservation reservation = await GetRoomReservation(Id);
            reservation.MeetingRoomId = obj.MeetingRoomId;
            reservation.MemberId = obj.MemberId;
            reservation.ReservationDate = obj.ReservationDate;
            reservation.TimeId = obj.TimeId;
            reservation.Title = obj.Title;
            reservation.Description = obj.Description;
            _context.Reservations.Update(reservation);
            return reservation;
        }
    }
}

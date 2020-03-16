using MeetingRoomApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.Repositories
{
    public interface IRoomReservationRepository : IBaseRepository
    { 
        IQueryable<RoomReservation> GetAllRoomReservations();

        Task<RoomReservation> GetRoomReservation(int Id);
        Task<RoomReservation> Create(RoomReservation obj);
        Task<RoomReservation> Update(int Id, RoomReservation obj);

        Task Delete(int Id);

    }
}

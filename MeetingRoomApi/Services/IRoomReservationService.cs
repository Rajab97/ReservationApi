using MeetingRoomApi.DTOs.RoomReservationDtos;
using MeetingRoomApi.Models;
using MeetingRoomApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.Services
{
    public interface IRoomReservationService:IBaseService
    {
        Task<IQueryable<RoomReservation>> GetAllRoomReservationsOfCurrentUser();
        IQueryable<RoomReservation> GetAllRoomReservations();

        Task<RoomReservation> GetRoomReservationOfCurrentUser(int Id);
        Task<RoomReservation> GetRoomReservation(int Id);
        Task<RoomReservation> Create(CreateRoomReservationDto obj);
        Task<RoomReservation> Update(int Id ,UpdateRoomReservationDto obj);

        Task<bool> CheckIfDateExpired(DateTime date,short timeId);
        Task Delete(int Id);

    }
}

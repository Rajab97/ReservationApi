using AutoMapper;
using MeetingRoomApi.DTOs.RoomReservationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingRoomApi.Models;
namespace MeetingRoomApi.DTOs.Profiles
{
    public class RoomReservationProfile :Profile
    {
        public RoomReservationProfile()
        {
            CreateMap<CreateRoomReservationDto,RoomReservation>().ReverseMap();
            CreateMap<UpdateRoomReservationDto, RoomReservation>().ReverseMap();
            CreateMap<RoomReservation, GetRoomReservationDto>()
                 .ForMember(m => m.Time, opt => opt.MapFrom(source => source.Time.StartTime.ToString(@"hh\:mm") + "-" + source.Time.EndTime.ToString(@"hh\:mm")))
                 .ForMember(m=>m.MemberName , opt => opt.MapFrom(source => source.Member.Name))
                 .ForMember(m =>m.BackColor , opt => opt.MapFrom(source => source.Member.ReservationColorCode));
        }
    }
}

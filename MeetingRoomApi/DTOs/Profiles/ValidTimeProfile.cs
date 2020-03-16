using AutoMapper;
using MeetingRoomApi.DTOs.ValidTimes;
using MeetingRoomApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.DTOs.Profiles
{
    public class ValidTimeProfile : Profile
    {
        public ValidTimeProfile()
        {
            CreateMap<Time, ValidTimeViewDto>()
                .ForMember(m => m.StartTime, opt => opt.MapFrom(source => source.StartTime.ToString(@"hh\:mm")))
                    .ForMember(m => m.EndTime, opt => opt.MapFrom(source => source.EndTime.ToString(@"hh\:mm")))
                        .ReverseMap();
        }
    }
}

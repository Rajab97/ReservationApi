using AutoMapper;
using MeetingRoomApi.DTOs.MemberDtos;
using MeetingRoomApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.DTOs.Profiles
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            CreateMap<LoginMemberDto, Member>().ReverseMap();
            CreateMap<ReqisterMemberDto, Member>().ForMember(m => m.UserName, opt => opt.MapFrom(source => source.UserName.Trim())).ReverseMap();
            CreateMap<MemberDetailsDto, Member>()
                .ForMember(m => m.ReservationColorCode, opt => opt.MapFrom(source => source.Color))
                .ReverseMap();
        }
    }
}

using AutoMapper;
using MeetingRoomApi.Models;
using MeetingRoomApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.Services
{
    public class CalendarService : BaseService, ICalendarService
    {
        private readonly IValidTimesRepository _validTimeRepository;

        public CalendarService(IMapper mapper , IValidTimesRepository validTimeRepository):base(mapper, validTimeRepository)
        {
            this._validTimeRepository = validTimeRepository;
        }

        public IQueryable<Time> GetAllValidTimes()
        {
            return _validTimeRepository.GetAllValidTimes();
        }
    }
}

using AutoMapper;
using MeetingRoomApi.Repositories;
using MeetingRoomApi.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.Services
{
    public class BaseService : IBaseService
    {
        protected readonly IMapper _mapper;
        private readonly IBaseRepository _baseRepository;
        public BaseService(IMapper mapper,IBaseRepository baseRepository)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
        }

        public void Commit()
        {
            _baseRepository.Commit();
        }

        public async Task CommitAsync()
        {
            await _baseRepository.CommitAsync();
        }

       
    }
}

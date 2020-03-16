using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.Services
{
     public interface IBaseService
    {
        void Commit();
        Task CommitAsync();
    }
}

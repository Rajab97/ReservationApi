using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.Repositories
{
    public interface IBaseRepository
    {
        void Commit();
        Task CommitAsync();
    }
}

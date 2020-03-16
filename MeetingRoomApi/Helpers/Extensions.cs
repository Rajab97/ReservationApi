using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.Helpers
{
    public static class Extensions
    {
        public static void AddApplicationException(this HttpResponse http, string message)
        {
            http.Headers.Add("Application-Error",message);
            http.Headers.Add("Access-Control-Expose-Headers","Application-Error");
            http.Headers.Add("Access-Control-Allow-Origin","*");
        }
    }
}

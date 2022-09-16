using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.Hubs
{
    public class Notifications
    {
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public int Id { get; set; }
        public int ToUserId { get; set; }
        public int FromUserId { get; set; }
    }
}

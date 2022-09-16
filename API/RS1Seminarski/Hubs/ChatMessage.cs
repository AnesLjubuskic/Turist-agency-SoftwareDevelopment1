using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.Hubs
{
    public class ChatMessage
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public string ConnectionId { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsRead { get; set; }
    }
}

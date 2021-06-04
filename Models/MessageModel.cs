using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChirpServer.Models
{
    public class MessageModel
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string message { get; set; }
        public DateTime timestamp { get; set; }
    }
}

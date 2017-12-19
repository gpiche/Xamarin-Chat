using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTO
{
    public class MessageDTO
    {
        public int ConversationId { get; set; }
        public string Recipient { get; set; }
        public string TextMessage { get; set; }
        public DateTime MessageDateTime { get; set; }
        public string Author { get; set; }
    }
}

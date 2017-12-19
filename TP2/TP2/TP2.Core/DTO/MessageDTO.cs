using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using TP2.Core.Repositories.Entities;

namespace TP2.Core.DTO
{
    public class MessageDTO
    {
        public MessageDTO(Message message, string recipient)
        {
            ConversationId = message.ConversationId;
            Recipient = recipient;
            TextMessage = message.Text;
            MessageDateTime = message.MessageDateTime;
            Author = message.Author;
        }

        public int ConversationId { get; set; }
        public string Recipient { get; set; }
        public string TextMessage { get; set; }
        public DateTime MessageDateTime { get; set; }
        public string Author { get; set; }
    }
}

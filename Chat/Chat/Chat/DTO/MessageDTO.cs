using System;
using System.Collections.Generic;
using System.Text;
using Chat.Repositories.Entities;

namespace Chat.DTO
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

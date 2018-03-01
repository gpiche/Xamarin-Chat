using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Repositories.Entities
{
    public class Message : Entity
    {
        private string _text;
        private string _author;
        private DateTime _messageDateTime;
        private int _conversationId;

        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        public string Author
        {
            get => _author;
            set => SetProperty(ref _author, value);
        }

        public DateTime MessageDateTime
        {
            get => _messageDateTime;
            set => SetProperty(ref _messageDateTime, value);
        }


        //[Indexed]
        public int ConversationId
        {
            get => _conversationId;
            set => SetProperty(ref _conversationId, value);
        }

    }
}

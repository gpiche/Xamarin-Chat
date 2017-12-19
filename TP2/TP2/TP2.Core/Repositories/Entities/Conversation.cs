using System;
using System.Collections.Generic;
using System.Text;
using Prism.Mvvm;

namespace TP2.Core.Repositories.Entities
{
    public class Conversation : Entity
    {
      

        private string _image ="https://cdn3.iconfinder.com/data/icons/internet-and-web-4/78/internt_web_technology-13-512.png";
        private string _lastMessage;
        private string _owner;
        private string _recipient;
        private DateTime _lastDateTime;

        public string Image
        {
            get => _image;
            set => SetProperty(ref _image, value);
        }

        public string LastMessage
        {
            get => _lastMessage;
            set => SetProperty(ref _lastMessage, value);
        }

        public string Owner
        {
            get => _owner;
            set => SetProperty(ref _owner, value);
        }

        public DateTime LastDateTime
        {
            get => _lastDateTime;
            set => SetProperty(ref _lastDateTime, value);
        }

        public string Recipient
        {
            get => _recipient;
            set => SetProperty(ref _recipient, value);
        }

        public string ConversationName => (App.CurrentUser == Owner) ? Recipient : Owner;
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TP2.Core.Repositories.Entities;

namespace TP2.Core.Services
{
    public interface IMessageService
    {
        void UpdateConversation(Message message);
        void SendMessage(Message message, string recipient);
    }
}

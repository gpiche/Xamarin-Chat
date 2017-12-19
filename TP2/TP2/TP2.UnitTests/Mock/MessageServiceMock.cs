using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.Core.Repositories;
using TP2.Core.Repositories.Entities;
using TP2.Core.Services;

namespace TP2.UnitTests.Mock
{
    class MessageServiceMock : IMessageService
    {
        public bool UpdateIsCalled { get; private set; }

        public void SendMessage(Message message, string recipient)
        {
            
        }

        public void UpdateConversation(Message message)
        {
            UpdateIsCalled = true;
        }

   
    }
}

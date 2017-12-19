using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.Core.Domain;
using TP2.Core.DTO;
using TP2.Core.Services;

namespace TP2.UnitTests.Mock
{
    class RessourceServiceMock : IRessourceService
    {
        public bool AddSessionIsCalled { get; private set; }
        public bool SendMessageIsCalled { get; private set; }

        public Task<string> SynchronizeMessage()
        {
            return null;
        }

        public string UserName { get; private set; }


        public void AddSessionInformation(AccessToken token, string username)
        {
            AddSessionIsCalled = true;
            UserName = "test";
        }

        public void SendMessage(MessageDTO messageDto)
        {
            SendMessageIsCalled = true;
        }
    }
}

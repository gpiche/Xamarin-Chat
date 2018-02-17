using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.Services;

namespace NUnit.Lab9.Test.Mock
{
    class NotificationServiceMock : INotificationService
    {
        public bool PlayServiceAvailableIsCalled { get; private set; }

        public void IsPlayServicesAvailable()
        {
            PlayServiceAvailableIsCalled = true;
        }

        public void Suscribe()
        {
            throw new NotImplementedException();
        }
    }
}

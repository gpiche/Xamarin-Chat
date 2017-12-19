using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TP2.Core.Domain;
using TP2.Core.DTO;
using TP2.Core.Repositories.Entities;

namespace TP2.Core.Services
{
    public interface IRessourceService
    {
        void AddSessionInformation(AccessToken token, string username);
        void SendMessage(MessageDTO messageDto);
        Task<string> SynchronizeMessage();
        string UserName { get; }
    }
}

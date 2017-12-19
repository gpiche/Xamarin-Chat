using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TP2.Core.DTO;
using TP2.Core.Repositories;
using TP2.Core.Repositories.Entities;

namespace TP2.Core.Services
{
    public class MessageService : IMessageService
    {
        private readonly IRepository<Conversation> _conversationRepository;
        private readonly IRessourceService _ressourceService;

        public MessageService(IRepository<Conversation> conversationRepository, IRessourceService ressourceService)
        {
            _conversationRepository = conversationRepository;
            _ressourceService = ressourceService;
        }

  
        public void SendMessage(Message message, string recipient)
        {
           _ressourceService.SendMessage(new MessageDTO(message, recipient));
        }

        public void UpdateConversation(Message message)
        {
            var conversationToUpdate = _conversationRepository.GetById(message.ConversationId);
            conversationToUpdate.LastDateTime = message.MessageDateTime;
            conversationToUpdate.LastMessage = message.Text;
            _conversationRepository.Update(conversationToUpdate);

        }
    }
}

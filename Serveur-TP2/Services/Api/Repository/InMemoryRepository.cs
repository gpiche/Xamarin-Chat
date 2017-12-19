using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DTO;
using Api.Repository.Entity;

namespace Api.Repository
{
    public class InMemoryRepository
    {
        public List<MessageDTO> Messages { get; set; }

        public InMemoryRepository()
        {
            Messages = new List<MessageDTO>();


        }

        public void AddMessage(MessageDTO message)
        {
            Messages.Add(message);
        }

        public MessageDTO GetMessageForUser(string username)
        {
            var message = Messages.Where(x => x.Recipient == username).ToList().FirstOrDefault();
            Messages.Remove(message);
            return message ;
        }




    }


 
}

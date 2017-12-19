using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.Core.Repositories;
using TP2.Core.Repositories.Entities;

namespace TP2.UnitTests.Mock
{
    class SQLiteRepositoryMock<T> : IRepository<T> where T : Entity, new()
    {
        public bool GetAllConversationsIsCalled { get; private set; }
        public bool AddIsCalled { get; private set; }
        public bool UpdateIsCalled { get; private set; }
        public string UserName { get; private set; }
        public Conversation Conversation { get; set; }

        public SQLiteRepositoryMock()
        {
            Conversation = new Conversation()
            {
                LastMessage = "old message",
                Id = 10
            };
        }


        public void Add(T entity)
        {
            AddIsCalled = true;
        }

        public void Delete(T entity)
        {
       
        }

        public ICollection<Conversation> GetAllConversations(string username)
        {
            GetAllConversationsIsCalled = true;
            UserName = username;
           return new List<Conversation>();
        }

        public T GetById(int id)
        {
            return (T)(object)Conversation;
        }

        public ICollection<Message> GetMessages(int conversationId)
        {
          return new List<Message>();
        }

        public void Update(T entity)
        {
            UpdateIsCalled = true;
        }
    }
}

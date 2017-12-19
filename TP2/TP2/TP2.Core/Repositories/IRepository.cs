using System;
using System.Collections.Generic;
using System.Text;
using TP2.Core.Repositories.Entities;

namespace TP2.Core.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        ICollection<Conversation> GetAllConversations(string username);
        ICollection<Message> GetMessages(int conversationId);
        T GetById(int id);

        void Delete(T entity);
        void Add(T entity);
        void Update(T entity);
    }
}

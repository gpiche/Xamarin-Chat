using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using TP2.Core.Repositories.Entities;
using TP2.Core.Services;

namespace TP2.Core.Repositories
{
    public class SqLiteRepository<T> : IRepository<T> where T : Entity, new()
    {
        
        private readonly SQLiteConnection _database;

        public SqLiteRepository(SQLiteConnection sqLiteConnection)
        {
            _database = sqLiteConnection;
            _database.CreateTable<T>(); // Si la table existe déjà ne fait rien. 
        }


        public ICollection<Conversation> GetAllConversations(string username)
        {
            return _database.Table<Conversation>().Where(v => v.Owner == username ||v.Recipient == username).ToList();
        }

        public ICollection<Message> GetMessages(int conversationId)
        {
            return _database.Table<Message>().Where(v => v.ConversationId == conversationId).ToList();
        }

        public T GetById(int id)
        {
            return _database.Find<T>(id);
        }

        public void Delete(T entity)
        {
            _database.Delete(entity);
        }

        public void Add(T entity)
        {
            _database.Insert(entity);
        }

        public void Update(T entity)
        {
            _database.Update(entity);
        }
    }

}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Prism.Navigation;
using TP2.Core.Repositories;
using TP2.Core.Repositories.Entities;
using TP2.Core.Services;
using TP2.UnitTests.Mock;

namespace TP2.UnitTests
{
    [TestFixture()]
    class MessageServiceTest
    {
        private IRepository<Conversation> _conversationrepositoryMock;
        private IRessourceService _ressourceServiceMock;
        private IMessageService _messageService;

        [SetUp]
        public void InitializeDatae()
        {
            _conversationrepositoryMock = new SQLiteRepositoryMock<Conversation>();
            _ressourceServiceMock = new RessourceServiceMock();
            _messageService = new MessageService(_conversationrepositoryMock, _ressourceServiceMock);
        }

        [Test]
        public void UpdateConversationMethodMustUpdateTheConversationLastMessage_WithTheNewValue()
        {
            const string expectedValue = "new message";
            var mock = (SQLiteRepositoryMock<Conversation>) _conversationrepositoryMock;
            var message = new Message()
            {
                Text = "new message"
            };
            

            _messageService.UpdateConversation(message);


            Assert.AreEqual(expectedValue, mock.Conversation.LastMessage);
        }

        [Test]
        public void UpdateConversationMethodMustUpdateTheConversationLastMessageDateTime_WithTheNewValue()
        {
            var mock = (SQLiteRepositoryMock<Conversation>)_conversationrepositoryMock;
            var message = new Message()
            {
                MessageDateTime = DateTime.Now    
            };


            _messageService.UpdateConversation(message);


            Assert.AreNotEqual(DateTime.MinValue, mock.Conversation.LastDateTime);
        }

        [Test]
        public void UpdateConversationMustUpdateTheConversationInTheDatabase()
        {
            var mock = (SQLiteRepositoryMock<Conversation>)_conversationrepositoryMock;
            var message = new Message()
            {
                Text = "new message"
            };


            _messageService.UpdateConversation(message);


            Assert.IsTrue(mock.UpdateIsCalled);
        }

        [Test]
        public void SendMethod_MustCallRessourceService()
        {
            var mock = (RessourceServiceMock)_ressourceServiceMock;
            var message = new Message()
            {
                Text = "new message"
            };


            _messageService.SendMessage(message, "test");


            Assert.IsTrue(mock.SendMessageIsCalled);
        }
    }
}

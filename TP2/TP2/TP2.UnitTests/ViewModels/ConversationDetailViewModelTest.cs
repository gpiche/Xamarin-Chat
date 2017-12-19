using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Prism.Navigation;
using TP2.Core.Repositories;
using TP2.Core.Repositories.Entities;
using TP2.Core.Services;
using TP2.Core.ViewModels;
using TP2.UnitTests.Mock;

namespace TP2.UnitTests.ViewModels
{
    [TestFixture]
    class ConversationDetailViewModelTest
    {
        private IRepository<Message> _messageRepositoryMock;
        private IRepository<Conversation> _conversationRepositoryMock;
        private IMessageService _messageServiceMock;
        private ConversationDetailPageViewModel _viewModel;

        [SetUp]
        public void InitializeData()
        {
            _messageRepositoryMock = new SQLiteRepositoryMock<Message>();
            _conversationRepositoryMock = new SQLiteRepositoryMock<Conversation>();
            _messageServiceMock = new MessageServiceMock();
            _viewModel = new ConversationDetailPageViewModel(_messageRepositoryMock,_messageServiceMock);
        }

        [Test]
        public void SendCommand_MustAddTheNewMessageToTheList()
        {
            _viewModel.OutGoingText = "test";
            var navigationParamaters = new NavigationParameters
            {
                { "conversation", new Conversation
                {
                    Id = 10
                }}
            };


            _viewModel.OnNavigatingTo(navigationParamaters);
            _viewModel.SendCommand.Execute(null);


            Assert.IsTrue(_viewModel.Messages.Any());

        }

        [Test]
        public void SendCommand_MustAddTheNewMessageToTheDatabase()
        {
            var mock = (SQLiteRepositoryMock<Message>) _messageRepositoryMock;
            _viewModel.OutGoingText = "test";
            var navigationParamaters = new NavigationParameters
            {
                { "conversation", new Conversation
                {
                    Id = 10
                }}
            };


            _viewModel.OnNavigatingTo(navigationParamaters);
            _viewModel.SendCommand.Execute(null);


            Assert.IsTrue(mock.AddIsCalled);

        }

        [Test]
        public void SendCommand_MustResetValueOfOutGoingText()
        {
            _viewModel.OutGoingText = "test";
            var navigationParamaters = new NavigationParameters
            {
                { "conversation", new Conversation
                {
                    Id = 10
                }}
            };


            _viewModel.OnNavigatingTo(navigationParamaters);
            _viewModel.SendCommand.Execute(null);


            Assert.AreEqual(_viewModel.OutGoingText, string.Empty);

        }



        [Test]
        public void SendCommand_MustCallMessageService_ToUpdateConversationWithNewValue()
        {
            _viewModel.OutGoingText = "test";
            var mock = (MessageServiceMock) _messageServiceMock;
            var navigationParamaters = new NavigationParameters
            {
                { "conversation", new Conversation
                {
                    Id = 10
                }}
            };


            _viewModel.OnNavigatingTo(navigationParamaters);
            _viewModel.SendCommand.Execute(null);


            Assert.IsTrue(mock.UpdateIsCalled);
        }
    }
}

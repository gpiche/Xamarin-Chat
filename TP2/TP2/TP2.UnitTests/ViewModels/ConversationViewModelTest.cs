using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Prism.Navigation;
using TP2.Core.Repositories;
using TP2.Core.Repositories.Entities;
using TP2.Core.Services;
using TP2.Core.ViewModels;
using TP2.UnitTests.Mock;

namespace TP2.UnitTests.ViewModels
{
    [TestFixture]
    class ConversationViewModelTest
    {
        private ConversationsPageViewModel _viewModel;
        private IRepository<Conversation> _conversationrepositoryMock;
        private IRepository<Message> _messageRepositoryMock;
        private IRessourceService _ressourceServiceMock;
        private INavigationService _navigationMock;
        private IMessageService _messageServiceMock;

        [SetUp]
        public void InitializeData()
        {
            _conversationrepositoryMock = new SQLiteRepositoryMock<Conversation>();
            _messageRepositoryMock = new SQLiteRepositoryMock<Message>();
            _ressourceServiceMock = new RessourceServiceMock();
            _navigationMock = new NavigationMock();
            _messageServiceMock = new MessageServiceMock();
            _viewModel = new ConversationsPageViewModel(_conversationrepositoryMock, _ressourceServiceMock, _navigationMock, _messageRepositoryMock, _messageServiceMock);
        }

        [Test]
        public void NavigateCommand_MustCallNavigationService()
        {
            var mock = (NavigationMock) _navigationMock;
            _viewModel.NavigateCommand.Execute(null);


            Assert.IsTrue(mock.IsCalled);
        }

    

        [Test]
        public void ConversationPageViewModel_MustCallTheRepository_WhitTheRessourceServiceData()
        {
            var repositoryMock = (SQLiteRepositoryMock<Conversation>)_conversationrepositoryMock;
            var ressourceMock = (RessourceServiceMock) _ressourceServiceMock;


            Assert.AreEqual(repositoryMock.UserName, ressourceMock.UserName);
        }
    }
}

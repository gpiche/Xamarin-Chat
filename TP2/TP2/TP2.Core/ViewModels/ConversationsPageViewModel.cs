using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Prism.Navigation;
using TP2.Core.DTO;
using TP2.Core.Repositories;
using TP2.Core.Repositories.Entities;
using TP2.Core.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TP2.Core.ViewModels
{
    public class ConversationsPageViewModel : BindableBase, INavigationAware
    {
        private readonly IRessourceService _ressourceService;
        private readonly INavigationService _navigationService;
        private readonly IRepository<Message> _messageRepository;
        private readonly IMessageService _messageService;
        private readonly IRepository<Conversation> _conversationRepository;
        private ObservableCollection<Conversation> _conversationsList;

        public ObservableCollection<Conversation> ConversationsList
        {
            get => _conversationsList;
            private set => SetProperty(ref _conversationsList, value);
        }

        public ICommand NavigateCommand => new Command(Navigate);


        public ConversationsPageViewModel(IRepository<Conversation> conversationRepository, IRessourceService ressourceService,
            INavigationService navigationService, IRepository<Message> messageRepository, IMessageService messageService)
        {
            _ressourceService = ressourceService;
            _navigationService = navigationService;
            _messageRepository = messageRepository;
            _messageService = messageService;
            _conversationRepository = conversationRepository;

            var timer = new System.Threading.Timer((e) => { SynchronizeMessage(); }, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(5));
        }

        private async void SynchronizeMessage()
        {
            string messagesDtos = await _ressourceService.SynchronizeMessage();
            

            if (messagesDtos != null)
            {
                JObject message = JObject.Parse(messagesDtos);
           
                var newMessage = new Message
                {
                     ConversationId  = (int) message["conversationId"],
                     Text            = (string) message["textMessage"],
                     MessageDateTime = (DateTime) message["messageDateTime"],
                     Author = (string) message["author"]
                };
                    _messageRepository.Add(newMessage);
                    _messageService.UpdateConversation(newMessage);
                     UpdateLocalConversation(newMessage);
            }
         
        }

        private void UpdateLocalConversation(Message message)
        {
            var conversation = ConversationsList.FirstOrDefault(x => x.Id == message.ConversationId);
            if (conversation != null)
            {
                conversation.LastMessage = message.Text;
                conversation.LastDateTime = message.MessageDateTime;
            }

        }


        private void Navigate(object item)
        {
            var conversation = (Conversation) item;

            var parameters = new NavigationParameters
            {
                {"conversation", conversation}
            };
            _navigationService.NavigateAsync("ConversationDetailPage", parameters);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
           
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            ConversationsList =
                new ObservableCollection<Conversation>(_conversationRepository.GetAllConversations(_ressourceService.UserName));
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
           
        }
    }
}
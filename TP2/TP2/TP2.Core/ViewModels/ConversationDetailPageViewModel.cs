using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Prism.Navigation;
using TP2.Core.DTO;
using TP2.Core.Repositories;
using TP2.Core.Repositories.Entities;
using TP2.Core.Services;
using Xamarin.Forms;

namespace TP2.Core.ViewModels
{
	public class ConversationDetailPageViewModel : BindableBase, INavigationAware
	{
		private Conversation _conversation;
		private string _outgoingText = string.Empty;

		private readonly IRepository<Message> _messageRepository;
		private readonly IMessageService _messageService;
		private ObservableCollection<Message> _messages = new ObservableCollection<Message>();

		public ObservableCollection<Message> Messages {
			get => _messages;
			set => SetProperty(ref _messages, value);
		} 

		public string OutGoingText
		{
			get => _outgoingText;
			set => SetProperty(ref _outgoingText, value);
		}

		public ICommand SendCommand => new DelegateCommand(SendMessage);


		public ConversationDetailPageViewModel(IRepository<Message> messageRepository,IMessageService messageService)
		{
		    _messageRepository = messageRepository;
			_messageService = messageService;
		}

	

		private void SendMessage()
		{
			var message = new Message
			{
				Text = OutGoingText,
				MessageDateTime = DateTime.Now,
				ConversationId = _conversation.Id,
				Author = App.CurrentUser
			};


			 Messages.Add(message);
			_messageRepository.Add(message);
			_messageService.UpdateConversation(message);
			_messageService.SendMessage(message, _conversation.ConversationName);
			 OutGoingText = string.Empty;
		}



	
		public void OnNavigatedFrom(NavigationParameters parameters)
		{
			
		}

		public void OnNavigatedTo(NavigationParameters parameters)
		{
			
		}

		public void OnNavigatingTo(NavigationParameters parameters)
		{
			_conversation = (Conversation)parameters["conversation"];
			Messages = new ObservableCollection<Message>(_messageRepository.GetMessages(_conversation.Id));
		}

		
	}
}

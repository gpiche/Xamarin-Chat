using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.Practices.Unity;
using Prism.Unity;
using SQLite;
using TP2.Core.Helper;
using TP2.Core.Repositories;
using TP2.Core.Repositories.Entities;
using TP2.Core.Services;
using TP2.Core.Views;
using Xamarin.Forms;

namespace TP2.Core
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }
        public static string CurrentUser { get; set; }

        protected override void OnInitialized()
        {
            InitializeComponent();

           SeedTestDatas();

            NavigationService.NavigateAsync("LoginPage");
        }

        protected override void RegisterTypes()
        {
            //Navigation registration
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<LoginPage>();
            Container.RegisterTypeForNavigation<ConversationsPage>();
            Container.RegisterTypeForNavigation<ConversationDetailPage>();

            //Database
            var databasePath = DependencyService.Get<IFileHelper>().GetLocalFilePath("test200.db3");
            var database = new SQLiteConnection(databasePath);

            //Injection registration
            Container.RegisterType<IAuthorizationService, AuthorizationService>(
                new ContainerControlledLifetimeManager(),
                new InjectionConstructor()
               );


            Container.RegisterType<IRessourceService, RessourceService>(
                new ContainerControlledLifetimeManager(),
                new InjectionConstructor(new HttpClient())
            );


            Container.RegisterType<IRepository<Conversation>, SqLiteRepository<Conversation>>(
                new ContainerControlledLifetimeManager(),
                new InjectionConstructor(database));

            Container.RegisterType<IRepository<Message>, SqLiteRepository<Message>>(
                new ContainerControlledLifetimeManager(),
                new InjectionConstructor(database));

            var conversationRepository = Container.Resolve<IRepository<Conversation>>();
            var ressourceService = Container.Resolve<IRessourceService>();

            Container.RegisterType<IMessageService, MessageService>(
                new InjectionConstructor(conversationRepository, ressourceService)
            );


        }

        private void SeedTestDatas()
        {
            var conversationRepository = Container.Resolve<IRepository<Conversation>>();
            var messageRepository = Container.Resolve <IRepository<Message>>();


            if (!conversationRepository.GetAllConversations("a").Any())
            {
                var conversationA = new Conversation
                {
                    LastMessage = "some private message for a",
                    Owner = "a",
                    Recipient = "b",
                };
                var conversationA1 = new Conversation
                {
                    LastMessage = "22222",
                    Owner = "a",
                    Recipient = "b",
                };


                conversationRepository.Add(conversationA);
                conversationRepository.Add(conversationA1);



            }

            if (!conversationRepository.GetAllConversations("b").Any())
            {
                var conversationB = new Conversation
                {
                    LastMessage = "some private message for b",
                    Owner = "b",
                    Recipient = "a",

                };

                conversationRepository.Add(conversationB);


            }
     
            
        }
    }
}



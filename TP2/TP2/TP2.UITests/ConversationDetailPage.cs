using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TP2.UITests.PageObjects;
using Xamarin.UITest;
using Xamarin.UITest.Android;

namespace TP2.UITests
{
    [TestFixture]
    public class ConversationDetailPage
    {
        private AndroidApp _app1;
        private AndroidApp _app2;


        [SetUp]
        public void BeforeEachTest()
        {
            _app1 = ConfigureApp.Android
                .ApkFile(@"c:\temp\release.apk")
                .StartApp();
        }

        [Test]
        public void ConversationDetailPage_WhenNewMessageSend_DisplayIt()
        {
            var mainPage = new MainPage(_app1);
            const string messageToSend = "@this is a test";

            mainPage.SendMessage(messageToSend);

            Assert.IsTrue(mainPage.IsTextDisplayed(messageToSend));
        }

        [Test]
        public void ConversationDetailPage_UpdateTheConversation_WhenNewMessageIsRecieve()
        {
            var mainPage1 = new MainPage(_app1);
            const string messageToSend = "@this is a test";
            mainPage1.SendMessage(messageToSend);
            StartReceiverApp();
            var mainPage2 = new MainPage(_app2);


            mainPage2.PressConnexionButtonWithCredentials("b","b");

            Assert.IsTrue(mainPage2.IsTextDisplayed(messageToSend));    
        }

        [Test]
        public void ConversationDetailPage_UpdateMessage_WhenMessageIsReceive()
        {
            var mainPage1 = new MainPage(_app1);
            const string messageToSend = "@this is a test";
            mainPage1.SendMessage(messageToSend);
            StartReceiverApp();
            var mainPage2 = new MainPage(_app2);

            mainPage2.GoToConversationDetailPage("b","b", messageToSend);

            Assert.IsTrue(mainPage2.IsTextDisplayed(messageToSend));
        }

        private void StartReceiverApp()
        {
            _app2 = ConfigureApp.Android
                .ApkFile(@"c:\temp\release.apk")
                .StartApp();
        }
    }
}

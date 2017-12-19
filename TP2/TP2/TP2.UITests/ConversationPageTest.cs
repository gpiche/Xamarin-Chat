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
    public class ConversationPageTest
    {
        private AndroidApp _app;

        [SetUp]
        public void BeforeEachTest()
        {
            _app = ConfigureApp.Android
                .ApkFile(@"c:\temp\release.apk")
                .StartApp();
        }

        [Test]
        public void ConversationPage_UpdateConversation_WhenThereIsANewMessage()
        {
            var mainPage = new MainPage(_app);
            const string textToSend = "@this is a test!!";

            mainPage.SendAmessageAndGetBackToConversationPage(textToSend);

            Assert.IsTrue(mainPage.IsTextDisplayed(textToSend));

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.UITests.Helpers;
using Xamarin.UITest;

namespace TP2.UITests.PageObjects
{
    class MainPage : BasePageObject
    {
        public MainPage(IApp app) : base(app)
        {
            
        }

        public void PressConnexionButtonWithCredentials(string username, string password)
        {
            App.Tap(UiText.GlobalsId.ConnexionUserNameField);
            App.EnterText(username);
            App.DismissKeyboard();
            App.Tap(UiText.GlobalsId.ConnexionPasswordField);
            App.EnterText(password);
            App.DismissKeyboard();
            App.Tap(UiText.GlobalsId.ConnexionButton);
        }

        public void SendAmessageAndGetBackToConversationPage(string textToSend)
        {
            SendMessage(textToSend);
            App.Back();
        }

        public void SendMessage(string textToSend)
        {
            GoToConversationDetailPage("a", "a");
            App.Tap(UiText.GlobalsId.SendMessageField);
            App.EnterText(textToSend);
            App.DismissKeyboard();
            App.Tap(UiText.GlobalsId.SendMessageButton);
        }

        public void GoToConversationDetailPage(string userName, string password, string recieverConversationLastmessage=null)
        {
            PressConnexionButtonWithCredentials(userName, password);
            App.Tap(recieverConversationLastmessage ?? UiText.GlobalsId.ConversationLastMessage);
        }


        public bool IsTextDisplayed(string errorMessage)
        {
            return UiTestHelper.IsTextDisplayed(App, errorMessage);
        }
    }
}

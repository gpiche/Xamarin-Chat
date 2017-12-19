using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using TP2.UITests.PageObjects;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Android;

namespace TP2.UITests
{
    [TestFixture]
    public class LoginPageTest
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
        public void LoginPage_ConnexionButtonPressWithWrongCredentials_DisplayErrorMessage()
        {
            var mainPage = new MainPage(_app);
            const string worngUserName = "wrong userName";
            const string wrongPassword = "wrongPassword";
            const string errorMessage = "Wrong username or password.";

            mainPage.PressConnexionButtonWithCredentials(worngUserName, wrongPassword);

            Assert.IsTrue(mainPage.IsTextDisplayed(errorMessage));
        }

        [Test]
        public void LoginPage_ConnexionButtonPressWithGoodCredentials_DoNoyDisplayErrorMessage()
        {
            var mainPage = new MainPage(_app);
            const string goodUsername = "a";
            const string goodPassword = "a";
            const string errorMessage = "Wrong username or password.";

            mainPage.PressConnexionButtonWithCredentials(goodUsername, goodPassword);

            Assert.IsFalse(mainPage.IsTextDisplayed(errorMessage));
        }


    }
}


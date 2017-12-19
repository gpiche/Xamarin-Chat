
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using RichardSzalay.MockHttp;
using TP2.Core;
using TP2.Core.Domain;
using TP2.Core.DTO;
using TP2.Core.Repositories.Entities;
using TP2.Core.Services;
using TP2.UnitTests.Mock;

namespace TP2.UnitTests.Services
{
    [TestFixture()]
    class RessourceServiceTest
    {
        private MockHttpMessageHandler _mockHttp;
        private HttpClient _httpClient;
        private IRessourceService _ressourceService;

        [SetUp]
        public void InitialiseData()
        {
            _mockHttp = new MockHttpMessageHandler();
            _httpClient = new HttpClient(_mockHttp);
            _ressourceService = new RessourceService(_httpClient);
        }


        [Test]
        public void SendMessage_MustCallPostAsync_WithTheGoodUrl()
        {

            _mockHttp.Expect(GlobalSetting.Instance.RestApiEndPoint + "/identity");
            var messageDto = new MessageDTO(new Message(), "test user");

            _ressourceService.SendMessage(messageDto);

            //Vérifie que l'url a bien été appelé
            _mockHttp.VerifyNoOutstandingExpectation();
            _mockHttp.Clear();
        }

        [Test]
        public void SendMessage_MustCallPostAsync_WithTheGoodContent()
        {
            const int expectedMatchCount = 1;
            var messageDto = new MessageDTO(new Message()
            {
                Author = "test",
                ConversationId = 1,
                Id = 1,
                MessageDateTime = DateTime.MinValue,
                Text = "this is a test"
            },"a");
            var request = _mockHttp.When(GlobalSetting.Instance.RestApiEndPoint + "/identity")
                .WithPartialContent(convertToJson(messageDto));

            _ressourceService.SendMessage(messageDto);

            Assert.AreEqual(expectedMatchCount, _mockHttp.GetMatchCount(request));
            _mockHttp.Clear();
        }

        [Test]
        public void SynchronizeMessage_MustCallGetAsync_WithTheGoodUrl()
        {
            const string user = "test user";
            _ressourceService.AddSessionInformation(new AccessToken("token"), user);
            _mockHttp.Expect(GlobalSetting.Instance.RestApiEndPoint + "/identity?userName=" + user);

             _ressourceService.SynchronizeMessage();

            _mockHttp.VerifyNoOutstandingExpectation();
            _mockHttp.Clear();

        }

        [Test]
        public async Task SynchronizeMessage_MustReturnNull_WhenResponseIsInvalid()
        {
            const string user = "test user";
            _ressourceService.AddSessionInformation(new AccessToken("token"), user);
            _mockHttp.When(GlobalSetting.Instance.RestApiEndPoint + "/identity?userName=" + user)
                .Respond("application/json", "null");

           var response =  await _ressourceService.SynchronizeMessage();

            Assert.AreEqual(null, response);
            _mockHttp.Clear();
        }

        [Test]
        public async Task SynchronizeMessage_MustReturnContent_WhenResponseIsValid()
        {
            const string user = "test user";
            const string content = "{content: valid}";
            _ressourceService.AddSessionInformation(new AccessToken("token"), user);
            _mockHttp.When(GlobalSetting.Instance.RestApiEndPoint + "/identity?userName=" + user)
                .Respond("application/json", content);

            var response = await _ressourceService.SynchronizeMessage();

            Assert.AreEqual(content, response);
            _mockHttp.Clear();
        }


        private string convertToJson(MessageDTO messageDto)
        {
            return  JsonConvert.SerializeObject(messageDto);  
        }
    }
}

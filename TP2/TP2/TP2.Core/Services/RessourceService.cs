using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TP2.Core.Domain;
using TP2.Core.DTO;
using TP2.Core.Repositories.Entities;

namespace TP2.Core.Services
{
    public class RessourceService : IRessourceService
    {
        private AccessToken _accessToken;
        private readonly HttpClient _httpClient;

        public string UserName { get; private set; }

        public RessourceService(HttpClient client)
        {
            _httpClient = client;
        }

        public void AddSessionInformation(AccessToken token, string username)
        {
            _accessToken = token;
            UserName = username;
            _httpClient.SetBearerToken(_accessToken.Token);
        }

        public async void SendMessage(MessageDTO messageDto)
        {
            var jsonRequest = JsonConvert.SerializeObject(messageDto);

            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            await _httpClient.PostAsync(GlobalSetting.Instance.RestApiEndPoint + "/identity", content);
        }

        public async Task<string> SynchronizeMessage()
        {
            var response =
                await _httpClient.GetAsync(GlobalSetting.Instance.RestApiEndPoint + "/identity?userName=" + UserName);
            var content = await response.Content.ReadAsStringAsync();

            if (content == "[]" || content == "null")
            {
                return null;
            }

            return content;
        }

        public async void Register(RegistrationInformation registrationInformation)
        {
            var jsonRequest = JsonConvert.SerializeObject(registrationInformation);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            await _httpClient.PostAsync(GlobalSetting.Instance.RegistrationEndPoint, content);
        }
    }
}
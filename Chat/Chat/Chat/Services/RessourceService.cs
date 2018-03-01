using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Chat.Domain;
using Chat.DTO;
using Newtonsoft.Json;

namespace Chat.Services
{
    public class RessourceService : IRessourceService
    {
        private readonly HttpClient _httpClient;

        public RessourceService()
        {
            _httpClient = new HttpClient();
        }

        public async void Register(RegistrationInformationDTO registrationInformation)
        {
            var jsonRequest = JsonConvert.SerializeObject(registrationInformation);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            await _httpClient.PostAsync(GlobalSetting.Instance.RegistrationEndPoint, content);
        }
    }
}

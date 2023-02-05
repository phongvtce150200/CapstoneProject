using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Text.Json;
using ClinicManageAPI.DTO;
using BusinessObject.Entity;

namespace ClinicManageAPI.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SignalRHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public static int numberOfConnection = 0;

        public override async Task OnConnectedAsync()
        {
            numberOfConnection++;
            await base.OnConnectedAsync();
            System.Console.WriteLine($"{Context.User.Identity.Name} ===> Number Of Connection: {numberOfConnection}");
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            numberOfConnection--;
            await base.OnDisconnectedAsync(exception);
            System.Console.WriteLine($"{Context.User.Identity.Name} leave ===> Number Of Connection: {numberOfConnection}");
        }
        public async Task<List<GetQueueDTO>> GetQueue(string doctorId)
        {
            try
            {
                var response = await _httpClientFactory.CreateClient().GetAsync("https://localhost:5001/api/Queue?doctorId=" + doctorId);
                var data = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                List<GetQueueDTO> list = JsonSerializer.Deserialize<List<GetQueueDTO>>(data, options);
                await Clients.All.SendAsync("LoadQueue", list);
                return list;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"An error occurred while making the API call: {ex}");
                return null;
            }
        }
        public async Task CreateQueue(QueueDTO queueDTO)
        {
            string data = JsonSerializer.Serialize(queueDTO);
            var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClientFactory.CreateClient().PostAsync("https://localhost:5001/api/Queue", content);
            if (response.IsSuccessStatusCode)
            {
                await Clients.All.SendAsync("CreateQueue");
            }
        }
    }
}

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
    }
}

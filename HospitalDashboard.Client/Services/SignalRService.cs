using Microsoft.AspNetCore.SignalR.Client;
using System;

using System.Threading.Tasks;



namespace HospitalDashboard.Client.Services
{
    public class SignalRService
    {
        private HubConnection _connection;

        public event Action<string> OnUpdateReceived;

        public async Task Connect()
        {
            _connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/resourcehub")
                .WithAutomaticReconnect()
                .Build();

            _connection.On<string>("ReceiveUpdate", (message) =>
            {
                OnUpdateReceived?.Invoke(message);
            });

            await _connection.StartAsync();
        }
    }
}

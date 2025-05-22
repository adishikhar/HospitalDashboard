using HospitalDashboard.Client.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;



namespace HospitalDashboard.Client.Services
{
    public class ApiService
    {
        private readonly HttpClient _client = new HttpClient();

        public ApiService()
        {
            _client.BaseAddress = new Uri("http://localhost:5000/");
        }

        public async Task<List<Resource>> GetAllResources()
        {
            return await _client.GetFromJsonAsync<List<Resource>>("api/resource");
        }

        public async Task AddResource(Resource resource)
        {
            await _client.PostAsJsonAsync("api/resource", resource);
        }

        public async Task DeleteResource(string id)
        {
            await _client.DeleteAsync($"api/resource/{id}");
        }
    }
}

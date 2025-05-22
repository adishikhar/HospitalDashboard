using HospitalDashboard.API.Models;
using HospitalDashboard.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using HospitalDashboard.API.Hubs;

namespace HospitalDashboard.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResourceController : ControllerBase
    {
        private readonly MongoDbService _service;
        private readonly IHubContext<ResourceHub> _hub;

        public ResourceController(MongoDbService service, IHubContext<ResourceHub> hub)
        {
            _service = service;
            _hub = hub;
        }

        [HttpGet]
        public async Task<IActionResult> Get() =>
            Ok(await _service.GetAll());

        [HttpPost]
        
public async Task<IActionResult> Post(Resource resource)
{
    Console.WriteLine($"Received: {resource.Name}, {resource.Type}, {resource.Status}");

    var created = await _service.Create(resource);
    await _hub.Clients.All.SendAsync("ReceiveUpdate", "Resource Added");
    return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
}


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, Resource updated)
        {
            await _service.Update(id, updated);
            await _hub.Clients.All.SendAsync("ReceiveUpdate", "Resource Updated");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _service.Delete(id);
            await _hub.Clients.All.SendAsync("ReceiveUpdate", "Resource Deleted");
            return NoContent();
        }
    }
}

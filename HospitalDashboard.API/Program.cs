using HospitalDashboard.API.Hubs;
using HospitalDashboard.API.Services;

var builder = WebApplication.CreateBuilder(args);

// MongoDB + SignalR services
builder.Services.AddSingleton<MongoDbService>();
builder.Services.AddSignalR();

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

app.UseCors();
app.UseAuthorization();
app.MapControllers();
app.MapHub<ResourceHub>("/resourcehub");

app.Run();

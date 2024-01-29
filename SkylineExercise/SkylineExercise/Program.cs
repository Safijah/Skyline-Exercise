using Newtonsoft.Json;
using SkylineExercise.Models;
using SkylineExercise.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddConsole();
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// JSON data
string jsonData = @"
        {
            ""Device"": ""Arista"",
            ""Model"": ""X-Video"",
            ""NIC"": [{
                ""Description"": ""Linksys ABR"",
                ""MAC"": ""14:91:82:3C:D6:7D"",
                ""Timestamp"": ""2020-03-23T18:25:43.511Z"",
                ""Rx"": ""3698574500"",
                ""Tx"": ""122558800""
            }]
        }";

// Deserialize JSON data
DeviceData deviceData = JsonConvert.DeserializeObject<DeviceData>(jsonData);

// Calculate bitrates
BitrateCalculator.CalculateBitrates(deviceData);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

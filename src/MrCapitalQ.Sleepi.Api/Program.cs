using MrCapitalQ.Sleepi.Api.Endpoints;
using MrCapitalQ.Sleepi.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ISoundPlayer, SoundPlayer>();
builder.Services.AddTransient<ISoundFilePathFactory, SoundFilePathFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.RegisterSoundsEndpoints();

app.Run();

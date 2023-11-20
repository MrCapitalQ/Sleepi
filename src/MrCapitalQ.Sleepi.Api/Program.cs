using MrCapitalQ.Sleepi.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ISoundPlayer, SoundPlayer>();
builder.Services.AddTransient<ISoundFilePathFactory, SoundFilePathFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
var soundsEndpoint = app.MapGroup("api/Sounds");
soundsEndpoint.MapPut("Play",
    (ISoundPlayer soundPlayer, SoundType soundType = SoundType.Rain) =>
    {
        soundPlayer.Play(soundType);
        return TypedResults.NoContent();
    });

soundsEndpoint.MapPut("Stop",
    (ISoundPlayer soundPlayer) =>
    {
        soundPlayer.Stop();
        return TypedResults.NoContent();
    });

app.Run();

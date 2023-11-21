using Microsoft.AspNetCore.Http.HttpResults;
using MrCapitalQ.Sleepi.Api.Services;

namespace MrCapitalQ.Sleepi.Api.Endpoints
{
    public static class SoundsEndpoints
    {
        public static IEndpointRouteBuilder RegisterSoundsEndpoints(this IEndpointRouteBuilder builder)
        {
            var soundsEndpoint = builder.MapGroup("api/Sounds");
            soundsEndpoint.MapPut("Play", PlaySoundsAsync);
            soundsEndpoint.MapPut("Stop", StopSoundsAsync);

            return builder;
        }

        public static async Task<NoContent> PlaySoundsAsync(ISoundPlayer soundPlayer, SoundType soundType = SoundType.Rain)
        {
            await soundPlayer.PlayAsync(soundType);
            return TypedResults.NoContent();
        }

        public static async Task<NoContent> StopSoundsAsync(ISoundPlayer soundPlayer)
        {
            await soundPlayer.StopAsync();
            return TypedResults.NoContent();
        }
    }
}

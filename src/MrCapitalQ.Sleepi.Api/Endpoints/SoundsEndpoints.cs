using Microsoft.AspNetCore.Http.HttpResults;
using MrCapitalQ.Sleepi.Api.Services;

namespace MrCapitalQ.Sleepi.Api.Endpoints
{
    public static class SoundsEndpoints
    {
        public static IEndpointRouteBuilder RegisterSoundsEndpoints(this IEndpointRouteBuilder builder)
        {
            var soundsEndpoint = builder.MapGroup("api/Sounds");
            soundsEndpoint.MapPut("Play", PlaySounds);
            soundsEndpoint.MapPut("Stop", StopSounds);

            return builder;
        }

        public static NoContent PlaySounds(ISoundPlayer soundPlayer, SoundType soundType = SoundType.Rain)
        {
            soundPlayer.Play(soundType);
            return TypedResults.NoContent();
        }

        public static NoContent StopSounds(ISoundPlayer soundPlayer)
        {
            soundPlayer.Stop();
            return TypedResults.NoContent();
        }
    }
}

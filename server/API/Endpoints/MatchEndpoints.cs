using System;

namespace LolCoach.API.Endpoints;

public static class MatchEndpoints
{
    public static void MapMatchEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/matches/{matchId}", async context =>
        {
            // Handle getting match by ID
        });

        routes.MapGet("/matches/recent/{summonerId}", async context =>
        {
            // Handle getting recent matches for a summoner
        });
    }
}

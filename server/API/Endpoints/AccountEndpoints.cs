using LolCoach.API.Providers;
using Microsoft.AspNetCore.Mvc;

namespace LolCoach.API.Endpoints;

public static class AccountEndpoints
{
    public static void MapAccountEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/account/{gameName}/{tagLine}", async (string gameName, string tagLine, [FromServices] IRiotApi riotApi) =>
        {
            var acct = await riotApi.GetAccountByNameAndTagline(gameName, tagLine);
            return acct is null
                ? Results.NotFound(new { message = "Account not found" })
                : Results.Ok(acct);
        });
    }
}

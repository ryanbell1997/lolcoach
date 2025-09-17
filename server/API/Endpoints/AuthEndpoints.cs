namespace LolCoach.API.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapPost("/auth/login", async context =>
        {
            // Handle login
        });

        routes.MapPost("/auth/logout", async context =>
        {
            // Handle logout
        });
    }
}

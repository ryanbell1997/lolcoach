using LolCoach.API.Endpoints;
using LolCoach.API.Options;
using LolCoach.API.Providers;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.Configure<RiotOptions>(builder.Configuration.GetSection("Riot"));

builder.Services.AddHttpClient<IRiotApi, RiotApi>((serviceProvider, client) =>
{
    var options = serviceProvider.GetRequiredService<IOptions<RiotOptions>>().Value;
    if (string.IsNullOrWhiteSpace(options.Region))
        throw new InvalidOperationException("Riot:Region configuration missing");
    if (string.IsNullOrWhiteSpace(options.ApiKey))
        throw new InvalidOperationException("Riot:ApiKey configuration missing");
    client.BaseAddress = new Uri($"https://{options.Region}.api.riotgames.com/");
    client.DefaultRequestHeaders.Add("X-Riot-Token", options.ApiKey);
    client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
});


// Add CORS policy for local frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy.WithOrigins("http://localhost:5173", "https://lolcoach.net")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowFrontend");
    app.MapOpenApi();
}


app.UseHttpsRedirection();

AuthEndpoints.MapAuthEndpoints(app);
AccountEndpoints.MapAccountEndpoints(app);
MatchEndpoints.MapMatchEndpoints(app);
    
app.Run();

using GameStore.Api.Endpoints;
using GameStore.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<GameRepository>(); 

var app = builder.Build();


app.UseRouting();

app.MapGamesEndPoints();



app.Run();
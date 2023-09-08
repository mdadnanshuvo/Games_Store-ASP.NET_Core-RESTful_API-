// GamesEndPoints.cs
using GameStore.Api.Dtos;
using GameStore.Api.Entities;
using GameStore.Api.Repositories;

namespace GameStore.Api.Endpoints
{
    public static class GamesEndPoints
    {
        public static string GameNameWithID = "WithGameNamesWithID";

        public static RouteGroupBuilder MapGamesEndPoints(this IEndpointRouteBuilder routes)
        {
            GameRepository repo = new GameRepository(); // Create an instance of the repository

            routes.MapGet("/games", () => repo.GetAll().Select(game => game.asDto()));

            routes.MapGet("/games/{id}", (int id) =>
            {
                Game? game = repo.Get(id);

                return game is not null ? Results.Ok(game.asDto()) : Results.NotFound();
            }).WithName(GameNameWithID);

            routes.MapPost("/games", (createGameDto gameDto) =>
            {  Game game = new()
            {
              Name = gameDto.Name,
              Genre = gameDto.Genre,
              Price = gameDto.Price,
              ReleaseDate = gameDto.ReleaseDate,
              ImageURI = gameDto.ImageURI  
            };
                repo.Create(game);

                return Results.CreatedAtRoute(GameNameWithID, new { id = game.Id }, game);
            }).WithParameterValidation();




            routes.MapPut("/games/{id}", (int id, updateGameDto updatedGameDto) =>
            {
                Game? existingGame = repo.Get(id);

                if (existingGame is null)
                {
                    return Results.NotFound();
                }

                existingGame.Name = updatedGameDto.Name;
                existingGame.Price = updatedGameDto.Price;
                existingGame.Genre = updatedGameDto.Genre;
                existingGame.ReleaseDate = updatedGameDto.ReleaseDate;
                existingGame.ImageURI = updatedGameDto.ImageURI;

                repo.Update(existingGame);

                return Results.NoContent();
            });

            routes.MapDelete("/games/{id}", (int id) =>
            {
                Game? game = repo.Get(id);

                if (game is not null)
                {
                    repo.Delete(id);
                }

                return Results.NoContent();
            });
            
            return routes.MapGroup("/games");
        }
    }
}
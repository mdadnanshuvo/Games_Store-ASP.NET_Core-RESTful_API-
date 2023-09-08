using GameStore.Api.Dtos;

namespace GameStore.Api.Entities
{
    public static class EntityExtensions
    {
        public static GameDto asDto(this Game game)
        {
            return new GameDto(
                game.Id,
                game.Name,
                game.Genre,
                game.Price,
                game.ReleaseDate,
                game.ImageURI
            );
        }
    }
}
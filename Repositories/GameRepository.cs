using GameStore.Api.Entities;

namespace GameStore.Api.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly List<Game> games = new List<Game>
        {
            new Game
            {
                Id = 1,
                Name = "Street Fighter II",
                Genre = "Fighting",
                Price = 19.99M,
                ReleaseDate = new DateTime(1991, 2, 1),
                ImageURI = "https://placehold.co/100",
            },
            new Game()
    {
        Id = 2,
        Name = "Final Fantasy XIV",
        Genre = "RolePlaying",
        Price = 59.99M,
        ReleaseDate = new DateTime(2010,9,30),
        ImageURI = "https://placehold.co/100",
    },

    new Game()
    {
        Id = 3,
        Name = "Fifa 23",
        Genre = "Sports",
        Price = 69.99M,
        ReleaseDate = new DateTime(2022,9,27),
        ImageURI = "https://placehold.co/100",
    }
};


        public IEnumerable<Game> GetAll()
        {
            return games;
        }

        public Game? Get(int id)
        {
            return games.FirstOrDefault(game => game.Id == id);
        }

        public void Create(Game game)
        {
            if (game == null)
            {
                throw new ArgumentNullException(nameof(game));
            }

            if (games.Any(existingGame => existingGame.Id == game.Id))
            {
                throw new InvalidOperationException("A game with the same ID already exists.");
            }

            game.Id = games.Count > 0 ? games.Max(existingGame => existingGame.Id) + 1 : 1;
            games.Add(game);
        }

        public void Update(Game updatedGame)
        {
            if (updatedGame == null)
            {
                throw new ArgumentNullException(nameof(updatedGame));
            }

            var existingGame = games.FirstOrDefault(game => game.Id == updatedGame.Id);
            if (existingGame == null)
            {
                throw new InvalidOperationException("Game not found for update.");
            }

            // Update the existing game with the properties of updatedGame
            existingGame.Name = updatedGame.Name;
            existingGame.Genre = updatedGame.Genre;
            existingGame.Price = updatedGame.Price;
            existingGame.ReleaseDate = updatedGame.ReleaseDate;
            existingGame.ImageURI = updatedGame.ImageURI;
        }

        public void Delete(int id)
        {
            var gameToRemove = games.FirstOrDefault(game => game.Id == id);
            if (gameToRemove != null)
            {
                games.Remove(gameToRemove);
            }
            else
            {
                throw new InvalidOperationException("Game not found for deletion.");
            }
        }
    }
}

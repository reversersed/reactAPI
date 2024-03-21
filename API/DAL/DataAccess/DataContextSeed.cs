using API.DAL.Models;

namespace API.DAL.DataAccess
{
    public static class DataContextSeed
    {
        public static async Task SeedAsync(DataContext context)
        {
            try
            {
                context.Database.EnsureCreated();
                if (context.Movies.Any())
                    return;
                var genres = new Genre[]
                {
                    new Genre {Name = "Экшен"},
                    new Genre {Name = "Сверхъестественное"},
                    new Genre {Name = "Романтика" }
                };
                genres.ToList().ForEach(gen => context.Genres.Add(gen));

                var movies = new Movie[]
                {
                    new Movie{ Name = "Властелин колец", Genres=genres.ToList().Take(2).ToList() },
                    new Movie{ Name = "Сумерки", Genres=genres.ToList().Skip(1).ToList()}
                };
                movies.ToList().ForEach(movie => context.Movies.Add(movie));

                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}

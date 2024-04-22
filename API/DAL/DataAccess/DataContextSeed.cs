using API.DAL.Models;
using API.DAL.Models.Data;

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
                    new Genre {Name = "Комедия"},
                    new Genre {Name = "Сверхъестественное"},
                    new Genre {Name = "Романтика" }
                };
                genres.ToList().ForEach(gen => context.Genres.Add(gen));

                var movies = new Movie[]
                {
                    new Movie{ 
                        Name = "Совместная поездка", 
                        Genres=genres.ToList().Take(2).ToList(),
                        Cover = "https://i.imgur.com/LXqqUTl.jpg",
                        Description = "Охранник Бен отправляется вместе со своим шурином Джеймсом в патруль по Атланте, чтобы доказать, что он достоин жениться на Анджеле, сестре Джеймса.",
                        Rating = 0,
                        Year = 2014,
                        Url = "https://vk.com/video_ext.php?oid=-138993550&id=456243467&hash=d86fdb367e8663f7",
                        Tagline = "Propose to this cop's sister? Rookie mistake",
                        Director = "Тим Стори",
                        Screenwriter = "Джейсон Манцукас, Фил Хэй, Мэтт Манфреди",
                        Producer = "Мэтт Альварес, Ларри Брэзнер, Айс Кьюб",
                        Videographer = "Ларри Блэнфорд",
                        Composer = "Кристофер Леннерц",
                        Drawer = "Крис Корнвэлл, Пол Лютер Джексон, Роб Саймонс",
                        Montage = "Крэйг Элперт",
                        Budget = 25000000,
                        Collected = 154468902,
                        Premier = new DateOnly(2014, 1, 17),
                        Age = 16
                    },
                    new Movie{ Name = "Сумерки", Genres=genres.ToList().Skip(2).ToList()}
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

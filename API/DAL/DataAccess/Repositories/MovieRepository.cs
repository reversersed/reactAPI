using API.DAL.DataAccess.Interfaces;
using API.DAL.Models;
using API.DAL.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace API.DAL.DataAccess.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private DataContext context;
        public MovieRepository(DataContext context) => this.context = context;

        private bool isExists(int id) => context.Movies.Any(i => i.Id == id);

        public async Task<Movie> CreateMovie(Movie movie)
        {
            var genres = new List<Genre>();
            movie.Genres.ToList().ForEach(i =>
            {
                genres.Add(context.Genres.Find(i.Id));
            });
            movie.Genres = genres;

            var entity = await context.Movies.AddAsync(movie);
            context.SaveChanges();
            return entity.Entity;
        }
        public async Task<IEnumerable<Movie>> GetByGenre(int genreid)
        { 
            return await context.Movies.Include(i => i.Genres).Where(i => i.Genres.Where(x => x.Id == genreid).Any()).ToListAsync();
        }
        public async Task<bool> DeleteMovie(int id)
        {
            var movie = await this.GetMovie(id);
            if(movie == null)
                return false;
            try
            {
                context.Remove(movie);
                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
            return true;
        }
        public async Task<IEnumerable<Movie>> GetMovie()
        {
            return await context.Movies
                .Include(i => i.Genres)
                .Include(i => i.Reviews)
                    .ThenInclude(x => x.user)
                .ToListAsync();
        }

        public async Task<Movie?> GetMovie(int id)
        {
            var movie = await context.Movies
                .Include(i => i.Genres)
                .Include(i => i.Reviews)
                    .ThenInclude(x => x.user)
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
            if(movie is not null)
                movie.Reviews = movie.Reviews.OrderByDescending(i => i.Id).ToList();

            return movie;
        }

        public async Task<Movie?> UpdateMovie(Movie movie)
        {
            if(!isExists(movie.Id)) 
                return null;
            context.Entry(movie).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
            return movie;
        }

        public async Task<Review> InsertReview(Review review)
        {
            var response = await context.Reviews.AddAsync(review);
            await context.SaveChangesAsync();

            var movie = await context.Movies.FindAsync(review.movie.Id);
            movie.Rating = (float)Math.Round(context.Reviews.Include(i => i.movie).Where(i => i.movie.Id == movie.Id).Average(x => x.Rating), 1);
            context.Movies.Update(movie);
            await context.SaveChangesAsync();

            return response.Entity;
        }

        public async Task<IEnumerable<Genre>> GetAllGenre()
        {
            return await context.Genres.ToListAsync();
        }

        public async Task<Genre?> AddGenre(Genre genre)
        {
            if (context.Genres.Where(i => i.Name.Equals(genre.Name)).Any())
                return null;
            var result = await context.Genres.AddAsync(genre);
            if(result.State == EntityState.Added)
            {
                await context.SaveChangesAsync();
                return result.Entity;
            }
            return null;
        }

        public async Task<IEnumerable<Movie>> GetMovie(string? name, int[]? genre)
        {
            var response = await context.Movies
                .Where(i => i.Name.Contains(name != null ? name : ""))
                .Include(i => i.Genres)
                .Include(i => i.Reviews)
                    .ThenInclude(x => x.user)
                .ToListAsync();
            return response.Where(x => genre == null ? true : genre.All(g => x.Genres.Any(j => j.Id == g)));
        }

        public async Task<float?> DeleteReview(int id)
        {
            var review = await context.Reviews.Include(i => i.movie).Where(i => i.Id == id).FirstOrDefaultAsync();
            if (review == null)
                return null;
            context.Reviews.Remove(review);

            var reviews = context.Reviews.Include(i => i.movie).Where(i => i.movie.Id == review.movie.Id && i.Id != review.Id);
            var newRating = review.movie.Rating = (float)Math.Round(reviews.Any() ? reviews.Average(x => x.Rating) : 0, 1);

            context.Movies.Update(review.movie);
            await context.SaveChangesAsync();
            return newRating;
        }
    }
}

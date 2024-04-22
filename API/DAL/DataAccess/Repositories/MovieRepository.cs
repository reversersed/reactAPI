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
            movie.Genres.ToList().ForEach(async i =>
            {
                genres.Add(await context.Genres.FindAsync(i.Id));
            });
            movie.Genres = genres;

            var entity = await context.Movies.AddAsync(movie);
            context.SaveChanges();
            return entity.Entity;
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
                .ToListAsync();
        }

        public async Task<Movie?> GetMovie(int id)
        {
            return await context.Movies
                .Include(i => i.Genres)
                .Include(i => i.Reviews)
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
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

            return response.Entity;
        }
    }
}

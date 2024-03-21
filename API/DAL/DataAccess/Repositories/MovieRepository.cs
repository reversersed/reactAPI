using API.DAL.DataAccess.Interfaces;
using API.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace API.DAL.DataAccess.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private DataContext context;
        public MovieRepository(DataContext context) => this.context = context;

        private bool isExists(int id) => context.Movies.Any(i => i.Id == id);

        public Movie CreateMovie(Movie movie)
        {
            var genres = new List<Genre>();
            movie.Genres.ToList().ForEach(i =>
            {
                genres.Add(context.Genres.Find(i.Id));
            });
            movie.Genres = genres;

            var entity = context.Movies.Add(movie);
            context.SaveChanges();
            return entity.Entity;
        }

        public bool DeleteMovie(int id)
        {
            var movie = this.GetMovie(id);
            if(movie == null)
                return false;
            try
            {
                context.Remove(movie);
                context.SaveChanges();
            }
            catch
            {
                throw;
            }
            return true;
        }

        public IEnumerable<Movie> GetMovie()
        {
            return context.Movies
                .Include(i => i.Genres)
                .ToList();
        }

        public Movie? GetMovie(int id)
        {
            return context.Movies
                .Include(i => i.Genres)
                .Where(i => i.Id == id).FirstOrDefault();
        }

        public Movie? UpdateMovie(Movie movie)
        {
            if(!isExists(movie.Id)) 
                return null;
            context.Entry(movie).State = EntityState.Modified;

            try
            {
                context.SaveChanges();
            }
            catch
            {
                throw;
            }
            return movie;
        }
    }
}

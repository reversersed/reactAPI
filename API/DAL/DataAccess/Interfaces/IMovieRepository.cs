using API.BLL.DTO;
using API.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.DAL.DataAccess.Interfaces
{
    public interface IMovieRepository
    {
        public IEnumerable<Movie> GetMovie();
        public Movie? GetMovie(int id);
        public Movie CreateMovie(Movie movie);
        public bool DeleteMovie(int id);
        public Movie? UpdateMovie(Movie movie);
    }
}

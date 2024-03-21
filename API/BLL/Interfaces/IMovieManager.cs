using API.BLL.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace API.BLL.Interfaces
{
    public interface IMovieManager
    {
        public IEnumerable<MovieDTO> GetMovies();
        public MovieDTO? GetMovie(int id);
        public MovieDTO CreateMovie(MovieDTO movie);
        public bool DeleteMovie(int id);
        public MovieDTO? UpdateMovie(MovieDTO movie);
    }
}

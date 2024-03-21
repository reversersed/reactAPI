using API.BLL.DTO;
using API.BLL.Interfaces;
using API.DAL.DataAccess.Interfaces;
using API.DAL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.BLL
{
    public class MovieManager : IMovieManager
    {
        private IMovieRepository movieRepository { get; }
        private IMapper mapper { get; }
        public MovieManager(IMovieRepository movieRepository, IMapper mapper)
        {
            this.movieRepository = movieRepository;
            this.mapper = mapper;
        }
        public MovieDTO CreateMovie(MovieDTO movie)
        {
            var entity = mapper.Map<Movie>(movie);
            var response = movieRepository.CreateMovie(entity);
            return mapper.Map<MovieDTO>(response);
        }

        public bool DeleteMovie(int id)
        {
            return movieRepository.DeleteMovie(id);
        }

        public MovieDTO? GetMovie(int id)
        {
            var response = movieRepository.GetMovie(id);
            if (response == null)
                return null;
            return mapper.Map<MovieDTO>(response);
        }

        public IEnumerable<MovieDTO> GetMovies()
        {
            var response = movieRepository.GetMovie();
            return mapper.Map<IEnumerable<MovieDTO>>(response);
        }

        public MovieDTO? UpdateMovie(MovieDTO movie)
        {
            var entity = mapper.Map<Movie>(movie);
            var response = movieRepository.UpdateMovie(entity);
            if (response == null)
                return null;
            return mapper.Map<MovieDTO>(response);
        }
    }
}

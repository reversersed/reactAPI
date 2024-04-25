using API.BLL.DTO;
using API.BLL.Interfaces;
using API.DAL.DataAccess.Interfaces;
using API.DAL.Models.Data;
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
        public async Task<MovieDTO> CreateMovie(MovieDTO movie)
        {
            var entity = mapper.Map<Movie>(movie);
            var response = await movieRepository.CreateMovie(entity);
            return mapper.Map<MovieDTO>(response);
        }

        public async Task<bool> DeleteMovie(int id)
        {
            return await movieRepository.DeleteMovie(id);
        }

        public async Task<MovieDTO?> GetMovie(int id)
        {
            var response = await movieRepository.GetMovie(id);
            if (response == null)
                return null;
            return mapper.Map<MovieDTO>(response);
        }

        public async Task<IEnumerable<MovieDTO>> GetMovies()
        {
            var response = await movieRepository.GetMovie();
            return mapper.Map<IEnumerable<MovieDTO>>(response);
        }

        public async Task<MovieDTO?> UpdateMovie(MovieDTO movie)
        {
            var entity = mapper.Map<Movie>(movie);
            var response = await movieRepository.UpdateMovie(entity);
            if (response == null)
                return null;
            return mapper.Map<MovieDTO>(response);
        }
        public async Task<IEnumerable<GenreDTO>> GetGenres()
        {
            return mapper.Map<IEnumerable<GenreDTO>>(await movieRepository.GetAllGenre());
        }
        public async Task<ReviewDTO> InsertReview(int movie, User user, ReviewDTO review)
        {
            var review_data = mapper.Map<Review>(review);
            var movie_data = await movieRepository.GetMovie(movie);
            if (movie_data is null)
                throw new ArgumentNullException("empty movie");
            review_data.movie = movie_data;
            review_data.user = user;

            var responsne = await movieRepository.InsertReview(review_data);
            return mapper.Map<ReviewDTO>(responsne);
        }

        public async Task<GenreDTO?> AddGenre(GenreDTO genre)
        {
            var genre_data = mapper.Map<Genre>(genre);
            var response = await movieRepository.AddGenre(genre_data);
            if (response is null)
                return null;
            return mapper.Map<GenreDTO>(response);
        }
        public async Task<IEnumerable<MovieDTO>> GetByGenre(int genreid)
        {
            var response = await movieRepository.GetByGenre(genreid);
            return mapper.Map<IEnumerable<MovieDTO>>(response);
        }
    }
}

using APIMovies.DAL.Models;
using APIMovies.DAL.Models.Dtos;
using APIMovies.Repository;
using APIMovies.Repository.IRepository;
using APIMovies.Services.IServices;
using AutoMapper;

namespace APIMovies.Services
{
    public class MovieServices : IMovieServices
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public MovieServices(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;

            _mapper = mapper;
        }

        public async Task<ICollection<MovieDto>> GetMoviesAsync()
        {
            var movies = await _movieRepository.GetMoviesAsync();
            return _mapper.Map<ICollection<MovieDto>>(movies);
        }

        public async Task<MovieDto> GetMovieAsync(int id)
        {
            var movie = await _movieRepository.GetMovieAsync(id);
            return _mapper.Map<MovieDto>(movie);
        }

        public Task<bool> MovieExistsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> MovieExistsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMovieAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<MovieDto> CreateMovieAsync(MovieCreateDto movieCreateDto)
        {
            var movieExist = await _movieRepository.MovieExistsByNameAsync(movieCreateDto.Name);

            if (movieExist)
            {
                throw new InvalidCastException($"Ya existe una pelicula con el nombre de {movieCreateDto.Name}");
            }
            var movie = _mapper.Map<Movie>(movieCreateDto);

            var movieCreated = await _movieRepository.CreateMovieAsync(movie);

            if (!movieCreated)
            {
                throw new Exception("Error al crear la pelicula");
            }

            return _mapper.Map<MovieDto>(movie);
        }

        Task<MovieDto> IMovieServices.UpdateMovieAsync(Movie movieDto)
        {
            throw new NotImplementedException();
        }
    }
}

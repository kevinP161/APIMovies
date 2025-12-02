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
            var movieExist = _movieRepository.GetMovieAsync(id);

            if (movieExist == null)
            {
                throw new InvalidCastException($"No se encontro la pelicula con ID: {id}");
            }

            var movieDeleted = _movieRepository.DeleteMovieAsync(id);

            if (!movieDeleted.Result)
            {
                throw new Exception("Error al eliminar la pelicula");
            }
            return movieDeleted;
        }

        public async Task<MovieDto> CreateMovieAsync(MovieCreateUpdateDto movieCreateDto)
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

        public async Task<MovieDto> UpdateMovieAsync(MovieCreateUpdateDto dto, int id)
        {

            var movieExist = await _movieRepository.GetMovieAsync(id);

            if (movieExist == null)
            {
                throw new InvalidCastException($"No se encontro la pelicula con ID: {id}");
            }

            var nameExist = await _movieRepository.MovieExistsByNameAsync(dto.Name);

            if (nameExist)
            {
                throw new InvalidCastException($"Ya existe esa categoria con el nombre de {dto.Name}");
            }

            _mapper.Map(dto, movieExist);

            var movieUpdated = await _movieRepository.UpdateMovieAsync(movieExist);

            if (!movieUpdated)
            {
                throw new Exception("Error al actualizar la categoria");
            }

            return _mapper.Map<MovieDto>(movieExist);
        }
    }
}

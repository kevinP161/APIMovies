using APIMovies.DAL.Models;
using APIMovies.DAL.Models.Dtos;

namespace APIMovies.Services.IServices
{
    public interface IMovieServices
    {
        Task<ICollection<MovieDto>> GetMoviesAsync();
        Task<MovieDto> GetMovieAsync(int id);
        Task<bool> MovieExistsByIdAsync(int id);
        Task<bool> MovieExistsByNameAsync(string name);
        Task<MovieDto> CreateMovieAsync(MovieCreateDto movieDto);
        Task<MovieDto> UpdateMovieAsync(Movie movieDto);
        Task<bool> DeleteMovieAsync(int id);
    }
}

using APIMovies.DAL.Models.Dtos;
using APIMovies.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIMovies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Movies : ControllerBase
    {
        private readonly IMovieServices _movieServices;
        public Movies(IMovieServices movieServices)
        {
            _movieServices = movieServices;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ICollection<MovieDto>>> GetMovies()
        {
            var movies = await _movieServices.GetMoviesAsync();
            return Ok(movies);
        }
    }
}

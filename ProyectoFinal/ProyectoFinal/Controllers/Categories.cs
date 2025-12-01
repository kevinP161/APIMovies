using APIMovies.DAL.Models.Dtos;
using APIMovies.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIMovies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Categories : ControllerBase
    {

        private readonly ICategoryServices _categoryServices;
        public Categories(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ICollection<CategoryDto>>> GetCategories()
        {
            var categories = await _categoryServices.GetCategoriesAsync();
            return Ok(categories);
        }
    }
}

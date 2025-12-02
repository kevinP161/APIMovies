using APIMovies.DAL.Models;
using APIMovies.DAL.Models.Dtos;
using APIMovies.Repository.IRepository;
using APIMovies.Services.IServices;
using AutoMapper;

namespace APIMovies.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryServices(ICategoryRepository categoryRepository, IMapper mapper) 
        {
            _categoryRepository = categoryRepository;

            _mapper = mapper;
        }

        public Task<bool> CategoryExistsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CategoryExistsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryDto> CreateCategoryAsync(CategoryCreateUpdateDto categoryCreateDto)
        {
            var categoryExist = await _categoryRepository.CategoryExistsByNameAsync(categoryCreateDto.Name);

            if (categoryExist)
            {
                throw new InvalidCastException($"Ya existe una categoria con el nombre de {categoryCreateDto.Name}");
            }
            var category = _mapper.Map<Category>(categoryCreateDto);

            var categoryCreated = await _categoryRepository.CreateCategoryAsync(category);

            if (!categoryCreated)
            {
                throw new Exception("Error al crear la categoria");
            }

            return _mapper.Map<CategoryDto>(category);
        }

        public Task<bool> DeleteCategoryAsync(int id)
        {
            var categoryExist = _categoryRepository.GetCategoryAsync(id);

            if (categoryExist == null)
            {
                throw new InvalidCastException($"No se encontro la categoria con ID: {id}");
            }

            var categoryDeleted = _categoryRepository.DeleteCategoryAsync(id);

            if (!categoryDeleted.Result)
            {
                throw new Exception("Error al eliminar la categoria");
            }
            return categoryDeleted;
        }

        public async Task<ICollection<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetCategoriesAsync();
            return _mapper.Map<ICollection<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryAsync(id);
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<CategoryDto> UpdateCategoryAsync(CategoryCreateUpdateDto dto, int id)
        {
            var categoryExist = await _categoryRepository.GetCategoryAsync(id);

            if (categoryExist == null)
            {
                throw new InvalidCastException($"No se encontro la categoria con ID: {id}");
            }

            var nameExist = await _categoryRepository.CategoryExistsByNameAsync(dto.Name);

            if(nameExist )
            {
                throw new InvalidCastException($"Ya existe esa categoria con el nombre de {dto.Name}");
            }
            
            _mapper.Map(dto, categoryExist);

            var categoryUpdated = await _categoryRepository.UpdateCategoryAsync(categoryExist);

            if (!categoryUpdated)
            {
                throw new Exception("Error al actualizar la categoria");
            }

            return _mapper.Map<CategoryDto>(categoryExist);

        }

        
    }
}

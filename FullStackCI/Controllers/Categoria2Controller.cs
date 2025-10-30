using Asp.Versioning;
using FullStackCI.Dtos;
using FullStackCI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FullStackCI.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/Categorias")]
    [ApiController]
    public class Categories2Controller(ICategoryService categoryService, ICategoryCommandService categoryCommandService) : CategoriesController(categoryService, categoryCommandService)
    {
        private readonly ICategoryService _categoryService = categoryService;
        private readonly ICategoryCommandService _categorycommandService = categoryCommandService;

        [MapToApiVersion("2.0")]
        [HttpGet("{id}")]
        public new async Task<ActionResult<CategoryDto2>> GetCategory(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsyncV2(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
    }
}

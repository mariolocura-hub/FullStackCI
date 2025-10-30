using Asp.Versioning;
using FullStackCI.Dtos;
using FullStackCI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FullStackCI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ICategoryCommandService _categorycommandService;

        public CategoriesController(ICategoryService categoryService, ICategoryCommandService categoryCommandService)
        {
            _categoryService = categoryService;
            _categorycommandService = categoryCommandService;
        }

        [HttpGet]
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }


        [HttpGet("{id}")]
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        //[HttpGet("{id}")]
        ////[MapToApiVersion("2.0")]
        //public async Task<ActionResult<CategoryDto2>> GetCategoryV2(int id)
        //{
        //    var category = await _categoryService.GetCategoryByIdAsyncV2(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(category);
        //}

        [HttpPost]
        //[MapToApiVersion("1.0")]
        public async Task<ActionResult<CategoryDto>> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var category = await _categorycommandService.CreateCategoryAsync(createCategoryDto);
            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        //[MapToApiVersion("1.0")]
        public async Task<IActionResult> UpdateCategory(int id, CreateCategoryDto updateCategoryDto)
        {
            var category = await _categorycommandService.UpdateCategoryAsync(id, updateCategoryDto);
            if (category == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        //[MapToApiVersion("1.0")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categorycommandService.DeleteCategoryAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}

using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController(ICategoryService categoryService) : ControllerBase
	{
		private readonly ICategoryService _categoryService = categoryService;
		[HttpPost("AddCategories")]
		public IActionResult AddCategory(Category category)
		{
			var result = _categoryService.Add(category);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("GetAll")]
		public IActionResult GetAll()
		{
			var result = _categoryService.GetAll();
			if (result != null)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("DeleteCategory")]
		public IActionResult Delete(int id)
		{
			var result = _categoryService.Delete(id);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("GetByCategoryId")]
		public IActionResult Get(int id)
		{
			var result = _categoryService.Get(id);
            if (result !=null)
            {
				return Ok(result);
            }
			return BadRequest(result);
        }

		[HttpPost("UpdateCategory")]
		public IActionResult Update(Category id)
		{
			var result = _categoryService.Update(id);
			if (result != null)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

	}
}

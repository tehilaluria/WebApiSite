using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryServices _categoryServices;
        IMapper _mapper;

        public CategoryController(ICategoryServices icategoryServices, IMapper mapper)
        {
            _categoryServices = icategoryServices;
            _mapper = mapper;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Category> categories = await _categoryServices.getCategoriesAsync();//
            IEnumerable<CategoryDTO> categoryDTOs = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(categories);
            return Ok(categoryDTOs);
        }

        
    }
}

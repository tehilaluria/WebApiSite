using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IBookServices _bookServices;
        private readonly IMapper _mapper;
       
        public BookController(IBookServices ibookServices, IMapper mapper)
        {
            _bookServices = ibookServices;
            _mapper = mapper;
        }
        // GET: api/<BookController>
        [HttpGet]
        public async Task<IEnumerable<BookDTO>> Get([FromQuery] string? desc, [FromQuery] int? minPrice, [FromQuery] int? maxPrice, [FromQuery] int?[] categoryIds)
        {
            IEnumerable<Book> books =await _bookServices.getBooksAsync( desc,  minPrice,  maxPrice, categoryIds);
            IEnumerable<BookDTO> bookDTOs = _mapper.Map < IEnumerable<Book>, IEnumerable<BookDTO>>(books);
            return bookDTOs;
        }

    }
}

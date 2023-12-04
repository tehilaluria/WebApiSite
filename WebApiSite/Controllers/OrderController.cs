using AutoMapper;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderServices _orderServices;
        IMapper _mapper;
        public OrderController(IOrderServices iorderServices, IMapper mapper)
        {
            _orderServices = iorderServices;
            _mapper = mapper;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderDTO orderDTO)
        {
            Order order = _mapper.Map<OrderDTO, Order>(orderDTO);
            Order newOrder = await _orderServices.AddOrderAsync(order);
            if (newOrder != null)
            {
                OrderDTO orderFormat = _mapper.Map<Order, OrderDTO>(newOrder);

                return CreatedAtAction(nameof(Get), new { id = orderFormat.OrderId }, orderFormat);
            }
            return NoContent();
        }
        
       
    }
}

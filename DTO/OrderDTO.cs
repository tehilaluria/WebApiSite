using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal OrderSum { get; set; }

        public int UserId { get; set; }

        public virtual ICollection<OrderBookDTO> OrderBooks { get; set; } = new List<OrderBookDTO>();
    }
}

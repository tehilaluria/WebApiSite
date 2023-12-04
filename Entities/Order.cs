using System;
using System.Collections.Generic;

namespace Entities;

public partial class Order
{
    public int OrderId { get; set; }

    public DateTime OrderDate { get; set; }

    public decimal OrderSum { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<OrderBook> OrderBooks { get; set; } = new List<OrderBook>();

    public virtual User User { get; set; } = null!;
}

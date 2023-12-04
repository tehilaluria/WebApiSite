using System;
using System.Collections.Generic;

namespace Entities;

public partial class OrderBook
{
    public int OrderBookId { get; set; }

    public int BookId { get; set; }

    public int OrderId { get; set; }

    public int Quantity { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}

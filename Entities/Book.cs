using System;
using System.Collections.Generic;

namespace Entities;

public partial class Book
{
    public int BookId { get; set; }

    public string? BookName { get; set; }

    public int CategoryId { get; set; }

    public string? Auther { get; set; }

    public int? NumOfPages { get; set; }

    public string? Image { get; set; }

    public decimal? Price { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrderBook> OrderBooks { get; set; } = new List<OrderBook>();
}

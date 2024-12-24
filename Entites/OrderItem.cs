using System;
using System.Collections.Generic;

namespace Entites;

public partial class OrderItem
{
    public int Id { get; set; }

    public int ProuductId { get; set; }

    public int OrderId { get; set; }

    public int? Quantity { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Prouduct { get; set; } = null!;
}

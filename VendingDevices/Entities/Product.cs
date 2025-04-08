using System;
using System.Collections.Generic;

namespace VendingDevices.Entities;

public partial class Product
{
    public int IdProduct { get; set; }

    public string Name { get; set; } = null!;

    public string Information { get; set; } = null!;

    public double Cost { get; set; }

    public int Count { get; set; }

    public int MinCount { get; set; }

    public string InfoSell { get; set; } = null!;

    public virtual ICollection<Sell> Sells { get; set; } = new List<Sell>();
}

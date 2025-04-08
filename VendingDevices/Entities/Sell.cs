using System;
using System.Collections.Generic;

namespace VendingDevices.Entities;

public partial class Sell
{
    public int IdSell { get; set; }

    public int IdDevice { get; set; }

    public int IdProduct { get; set; }

    public int Count { get; set; }

    public double Sum { get; set; }

    public DateTime DateSell { get; set; }

    public string Method { get; set; } = null!;

    public virtual Device IdDeviceNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}

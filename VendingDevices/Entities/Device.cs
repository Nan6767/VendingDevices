using System;
using System.Collections.Generic;

namespace VendingDevices.Entities;

public partial class Device
{
    public int IdDevice { get; set; }

    public string Place { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateOnly DateStart { get; set; }

    public DateOnly DateLastCheck { get; set; }

    public double Sum { get; set; }

    public virtual ICollection<Check> Checks { get; set; } = new List<Check>();

    public virtual ICollection<Sell> Sells { get; set; } = new List<Sell>();
}

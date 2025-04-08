using System;
using System.Collections.Generic;

namespace VendingDevices.Entities;

public partial class Check
{
    public int IdCheck { get; set; }

    public int IdDevice { get; set; }

    public DateOnly DateCheck { get; set; }

    public string InfoCheck { get; set; } = null!;

    public string? Problems { get; set; }

    public int IdUser { get; set; }

    public virtual Device IdDeviceNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}

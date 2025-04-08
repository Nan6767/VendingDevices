using System;
using System.Collections.Generic;

namespace VendingDevices.Entities;

public partial class User
{
    public int IdUser { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Number { get; set; } = null!;

    public int IdRole { get; set; }
    
    public string Password { get; set; } = null!;

    public virtual ICollection<Check> Checks { get; set; } = new List<Check>();
}

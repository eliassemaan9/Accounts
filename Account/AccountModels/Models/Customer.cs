using System;
using System.Collections.Generic;

namespace AccountModels.Models;

public partial class Customer
{
    public long CustomerId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
}

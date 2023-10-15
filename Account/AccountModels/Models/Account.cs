using System;
using System.Collections.Generic;

namespace AccountModels.Models;

public partial class Account
{
    public long CustomerId { get; set; }

    public decimal? InitialCred { get; set; }

    public decimal? Balance { get; set; }

    public int? Type { get; set; }

    public long AccountId { get; set; }
}

using System;
using System.Collections.Generic;

namespace AccountModels.Models;

public partial class Transaction
{
    public DateTime? CreatedDate { get; set; }

    public decimal? TransactionAmout { get; set; }

    public long? AccountId { get; set; }

    public long TransactionId { get; set; }
}

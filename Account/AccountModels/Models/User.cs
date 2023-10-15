using System;
using System.Collections.Generic;

namespace AccountModels.Models;

public partial class User
{
    public long Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string PasswordHash { get; set; }

    public string PhoneNumber { get; set; }

    public short? IsActive { get; set; }

    public short? IsDeleted { get; set; }

    public string Salt { get; set; }
}

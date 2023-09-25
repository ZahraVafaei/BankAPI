using System;
using System.Collections.Generic;

namespace BankAPI.Data;

public class BankCustomersTb
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int AccountNumber { get; set; }

    public int? PostNumber { get; set; }
}

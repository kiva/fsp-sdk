/*
 * These classes are here just to show the structure of the Repayment Json
 * in typed format.
 */

using System.Collections.Generic;

class RepaymentHeader
{
    public int user_id { get; set; }
    public List<Repayment> Repayments { get; set; } = new();
}

class Repayment
{
    public string loan_id { get; set; }
    public decimal amount { get; set; }
}
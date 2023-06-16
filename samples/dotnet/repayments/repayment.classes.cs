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
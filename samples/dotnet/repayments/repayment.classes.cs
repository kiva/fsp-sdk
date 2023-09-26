/*
 * These classes are here just to show the structure of the Repayment Json
 * in typed format.
 */

using System.Collections.Generic;
using System.Text.Json.Serialization;

class RepaymentHeader
{
    [JsonPropertyName("repayments")] 
    public List<Repayment> Repayments { get; set; } = new();
}

class Repayment
{
    [JsonPropertyName("loan_id")] 
    public string LoanId { get; set; }
    [JsonPropertyName("amount")] 
    public decimal Amount { get; set; }
    [JsonPropertyName("client_id")] 
    public string ClientId { get; set; }
}
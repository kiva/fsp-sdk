using System.Text.Json.Serialization;

public class Journal
{
    [JsonPropertyName("body")]
    public string Body { get; set; }
    
    [JsonPropertyName("image_url")]
    public string ImageUrl { get; set; }
    
    [JsonPropertyName("internal_client_id")]
    public string InternalClientId { get; set; }
    
    [JsonPropertyName("internal_loan_id")]
    public string InternalLoanId { get; set; }
    
    [JsonPropertyName("subject")]
    public string Subject { get; set; }
}
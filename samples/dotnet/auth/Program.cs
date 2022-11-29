using System.Net.Http.Headers;
using System.Net;

Console.WriteLine("Kiva Partner API for authorization");

using HttpClient client = new();
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/json"));

var parameters = new Dictionary<string, string> {
    { "client_id", System.Environment.GetEnvironmentVariable("client_id") },
    { "client_secret", System.Environment.GetEnvironmentVariable("client_secret") },
    { "audience", System.Environment.GetEnvironmentVariable("audience") },
    { "grant_type", "client_credentials" },
    { "scope", System.Environment.GetEnvironmentVariable("scope") }
};

var encodedContent = new FormUrlEncodedContent(parameters);

var response = await client.PostAsync("https://auth-stage.dk1.kiva.org/oauth/token", encodedContent);

if (response.StatusCode == HttpStatusCode.OK) {
    var json = await response.Content.ReadAsStringAsync();
    Console.WriteLine($"\r\nResults returned: \r\n {json}\r\n");
} else {
    Console.WriteLine($"error: {response.StatusCode}");
}

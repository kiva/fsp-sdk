using System.Net.Http.Headers;
using System.Net;



/*
   Data
*/

string PartnerId = "";
string BearerToken = "";


/*
   functions
*/
async Task GetAuthorizationToken()
{
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

        // TODO: parse out auth token and partner id
    } else {
        Console.WriteLine($"error: {response.StatusCode}");
        System.Environment.Exit(1);
    }

}

async Task GetLoans()
{
    using HttpClient client = new();
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BearerToken);

    var response = await client.GetAsync($"https://partner-api-stage.dk1.kiva.org/v3/partner/{PartnerId}/loans");
    if (response.StatusCode == HttpStatusCode.OK) {
        var json = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"\r\nGet Loans returned: \r\n {json}\r\n");

    } else {
        Console.WriteLine($"error: {response.StatusCode}");
    }
}


/*
   execution
*/
Console.WriteLine("Kiva Partner API for listing loans");
Console.WriteLine("    -- Step 1 Getting authorization token");
await GetAuthorizationToken();


Console.WriteLine("    -- Step 2 listing the loans for the partner");
await GetLoans();
/*
   Data
*/

using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

string PartnerId = "";
string BearerToken = "";
string dataFileName = "data.json";
string AuthDomain = "auth-stage.dk1.kiva.org"; 
string PartnerDomain = "partner-api-stage.dk1.kiva.org";


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

    var response = await client.PostAsync($"https://{AuthDomain}/oauth/token", encodedContent);

    if (response.StatusCode == HttpStatusCode.OK)
    {
        using Stream responseBody = await response.Content.ReadAsStreamAsync();
        var kivaAuthorization = await JsonSerializer.DeserializeAsync<KivaAuthorization>(responseBody);
        
        PartnerId = kivaAuthorization.PartnerId;
        BearerToken = kivaAuthorization.AuthToken;

    } else {
        Console.WriteLine($"error: {response.StatusCode}");
        System.Environment.Exit(1);
    }

}

StringContent GetJsonData()
{
    string allText = File.ReadAllText(dataFileName);
    var content = new StringContent(allText, Encoding.UTF8, "application/json");
    return content;
}


async Task DoRepayment()
{

    var content = GetJsonData();
    using HttpClient client = new();
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BearerToken);

    var response = await client.PostAsync($"https://{PartnerDomain}/v3/partner/{PartnerId}/repayments",
        content);
    
    var json = await response.Content.ReadAsStringAsync();
    
    if (response.StatusCode == HttpStatusCode.OK) 
    {
        Console.WriteLine($"\r\nGet Loans returned: \r\n {json}\r\n");
    } 
    else 
    {
        Console.WriteLine($"error: {response.StatusCode}: {json}");
    }
}


Console.WriteLine("Kiva Partner API for repayment on loans");
Console.WriteLine("\tExample will use 'data.json' in current directory unless the file name is passed in as command line argument");
Console.WriteLine("\teg: ");
Console.WriteLine("\t\tdotnet run --project repayments/repayments.csproj data.json\r\n");

if (args.Length > 0)
{
    foreach (string arg in args)
    {
        dataFileName = arg;
        break;
    }
}


Console.WriteLine("\t -- Step 1 Getting authorization token");
await GetAuthorizationToken();
Console.WriteLine($"\t Authorization Received for Partner: {PartnerId}\r\n");

Console.WriteLine("\t -- Step 2 make repayments");
await DoRepayment();

Console.WriteLine("\t -- Completed.  See above for more details.");





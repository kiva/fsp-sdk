using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


string PartnerId = "";
string BearerToken = "";
string dataFileName = "data.json";
string AuthDomain = "auth-stage.dk1.kiva.org"; 
string PartnerDomain = "partner-api-stage.dk1.kiva.org";
ActivityList activities = null;                                 // loaded by GetActivities()
LocaleList locales = null;                                      // loaded by GetLocales()
ThemeList themes = null;                                        // loaded by GetThemes()
LocationList locations = null;                                  // loaded by GetLocations()

// ---------------------------------------------------------------------------
//   functions
// ---------------------------------------------------------------------------


// ---------------------------------------------------------------------------
// Please see the auth sample project for discussion how authorization works
async Task GetAuthorizationToken()
{
    using HttpClient client = new();
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));

    var parameters = new Dictionary<string, string> 
    {
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

    } 
    else 
    {
        string result = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"error: {response.StatusCode}: {result}");
        System.Environment.Exit(1);
    }

}

async Task GetActivities()
{
    // https://partner-api-stage.dk1.kiva.org/v3/partner/{{PARTNER_ID}}/config/activities
    
    using HttpClient client = new();
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BearerToken);
    
    var response = await client.GetAsync($"https://{PartnerDomain}/v3/partner/{PartnerId}/config/activities");
    
    if (response.StatusCode == HttpStatusCode.OK) 
    {
        using Stream responseBody = await response.Content.ReadAsStreamAsync();
        activities = await JsonSerializer.DeserializeAsync<ActivityList>(responseBody);
        Console.WriteLine($"Found {activities.Activities.Count} activities");
    } 
    else 
    {
        var result = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"error: {response.StatusCode}: {result}");
        throw new ApplicationException();
    }
}

// ---------------------------------------------------------------------------
async Task GetLocales()
{
    // https://partner-api-stage.dk1.kiva.org/v3/partner/{{PARTNER_ID}}/config/locales
    using HttpClient client = new();
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BearerToken);
    
    var response = await client.GetAsync($"https://{PartnerDomain}/v3/partner/{PartnerId}/config/locales");
    
    if (response.StatusCode == HttpStatusCode.OK)
    {
        using Stream responseBody = await response.Content.ReadAsStreamAsync();
        locales = await JsonSerializer.DeserializeAsync<LocaleList>(responseBody);
        Console.WriteLine($"Found {locales.Locales.Count} locales");
    } 
    else 
    {
        var result = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"error: {response.StatusCode}: {result}");
        throw new ApplicationException();
    }
}

// ---------------------------------------------------------------------------
async Task GetThemes()
{
    // https://partner-api-stage.dk1.kiva.org/v3/partner/{{PARTNER_ID}}/config/themes
    using HttpClient client = new();
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BearerToken);
    
    var response = await client.GetAsync($"https://{PartnerDomain}/v3/partner/{PartnerId}/config/themes");
    
    if (response.StatusCode == HttpStatusCode.OK)
    {
        using Stream responseBody = await response.Content.ReadAsStreamAsync();
        themes = await JsonSerializer.DeserializeAsync<ThemeList>(responseBody);
        Console.WriteLine($"Found {themes.Themes.Count} themes");
    } 
    else 
    {
        var result = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"error: {response.StatusCode}: {result}");
        throw new ApplicationException();
    }
}

// ---------------------------------------------------------------------------
async Task GetLocations()
{
    // https://partner-api-stage.dk1.kiva.org/v3/partner/{{PARTNER_ID}}/config/locations
    using HttpClient client = new();
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BearerToken);
    
    var response = await client.GetAsync($"https://{PartnerDomain}/v3/partner/{PartnerId}/config/locations");
    
    if (response.StatusCode == HttpStatusCode.OK)
    {
        // var json = await response.Content.ReadAsStringAsync();
        // Console.WriteLine($"results: {json}");
        
        using Stream responseBody = await response.Content.ReadAsStreamAsync();
        locations = await JsonSerializer.DeserializeAsync<LocationList>(responseBody);
        Console.WriteLine($"Found {locations.Locations.Count} locations");
    } 
    else 
    {
        var result = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"error: {response.StatusCode}: {result}");
        throw new ApplicationException();
    }
}

// ---------------------------------------------------------------------------
async Task PostLoanDraft()
{
    throw new NotImplementedException();
}



// ---------------------------------------------------------------------------
// Program execution
// ---------------------------------------------------------------------------


Console.WriteLine("Kiva Partner API example loans draft");

Console.WriteLine("\t -- Step 1 Getting authorization token");
await GetAuthorizationToken();
Console.WriteLine($"\t Authorization Received for Partner: {PartnerId}");

Console.WriteLine("\r\n\t -- Step 2a Get Activities");
await GetActivities();

Console.WriteLine("\r\n\t -- Step 2b Get Locales");
await GetLocales();

Console.WriteLine("\r\n\t -- Step 2c Get Themes");
await GetThemes();

Console.WriteLine("\r\n\t -- Step 2d Get Locations");
await GetLocations();

Console.WriteLine("\r\n\t -- Step 3 Post the loan");
await PostLoanDraft();

Console.WriteLine("\t -- Done!");


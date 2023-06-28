
using System.Text.Json.Serialization;

public class ActivityItem
{
    [JsonPropertyName("activity")]
    public string Activity { get; set; } = string.Empty;

    [JsonPropertyName("activity_id")]
    public int Id { get; set; } = -1;
}

public class ActivityList
{
    [JsonPropertyName("as_of_date_time")]
    public DateTime AsOfDateTime { get; set; } = DateTime.Now;

    [JsonPropertyName("activities")]
    public List<ActivityItem> Activities { get; set; } = new ();
}

public class Locale
{
    [JsonPropertyName("currency")]
    public string Currency { get; set; }

    [JsonPropertyName("language_code")]
    public string LanguageCode { get; set; }

    [JsonPropertyName("language_name")]
    public string LanguageName { get; set; }

    [JsonPropertyName("language_id")]
    public int LanguageId { get; set; }
}

public class LocaleList
{
    [JsonPropertyName("as_of_date_time")]
    public DateTime AsOfDateTime { get; set; } = DateTime.Now;

    [JsonPropertyName("locales")]
    public List<Locale> Locales { get; set; } = new ();
}

public class ThemeList
{
    [JsonPropertyName("as_of_date_time")]
    public DateTime AsOfDateTime { get; set; } = DateTime.Now;

    [JsonPropertyName("themes")]
    public List<Theme> Themes { get; set; } = new ();
}

public class Theme
{
    [JsonPropertyName("theme_type_id")]
    public int ThemeTypeId { get; set; }

    [JsonPropertyName("theme_type")]
    public string ThemeType { get; set; }
}


public class Location
{
    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("location")]
    public string LocationName { get; set; }

    [JsonPropertyName("full_name")]
    public string FullName { get; set; }
}

public class LocationList
{
    [JsonPropertyName("as_of_date_time")]
    public DateTime AsOfDateTime { get; set; } = DateTime.Now;

    [JsonPropertyName("locations")]
    public List<Location> Locations { get; set; } = new ();
}


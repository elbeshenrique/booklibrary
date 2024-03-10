using System.Text.Json.Serialization;

namespace BookLibrary.Models.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SearchBy
{
    Unknown = 0,
    Author = 1,
    Isbn = 2,
    Title = 3
}
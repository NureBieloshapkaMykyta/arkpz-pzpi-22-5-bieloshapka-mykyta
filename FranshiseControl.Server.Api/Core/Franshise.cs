using System.Text.Json.Serialization;

namespace Core;

public class Franshise
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long AppUserId { get; set; }
}

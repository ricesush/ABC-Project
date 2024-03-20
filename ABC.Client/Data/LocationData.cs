namespace ABC.Client.Data;
public partial class LocationData
{
    public static List<string> Provinces = new List<string> { "Province 1", "Province 2", "Province 3" };

    public static Dictionary<string, List<string>> Cities = new Dictionary<string, List<string>>
        {
            { "Province 1", new List<string> { "City 1-1", "City 1-2", "City 1-3" } },
            { "Province 2", new List<string> { "City 2-1", "City 2-2", "City 2-3" } },
            { "Province 3", new List<string> { "City 3-1", "City 3-2", "City 3-3" } }
        };
}


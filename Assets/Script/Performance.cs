using System.Numerics;
using System.Collections.Generic;
using Newtonsoft.Json;

public class Performance
{
    public static Dictionary<string, string> Performances = new Dictionary<string, string>()
    {
        {"EarnMoney", "1000"}
    };
    public static void SetPerformance(string code)
    {
        Performances = JsonConvert.DeserializeObject<Dictionary<string, string>>(code);
    }
    public static string GetPerformance()
    {
        return JsonConvert.SerializeObject(Performances);
    }
}

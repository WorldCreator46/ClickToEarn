using System.Numerics;
using System.Collections.Generic;
using Newtonsoft.Json;

public class Property
{
    public static Dictionary<string, object> Propertys = new Dictionary<string, object>()
    {
        {"Money", BigInteger.Parse("10000") }
    };
    public static void SetPropert(string code)
    {
        Propertys = JsonConvert.DeserializeObject<Dictionary<string, object>>(code);
    }
    public static string GetProperty()
    {
        return JsonConvert.SerializeObject(Propertys);
    }
}

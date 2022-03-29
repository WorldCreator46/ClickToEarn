using System.Numerics;
using System.Collections.Generic;
using Newtonsoft.Json;

public class Property
{
    /*public static Dictionary<string, string> Propertys = new Dictionary<string, string>()
    {
        {"Money", "10000" }
    };*/
    private static Dictionary<string, string> Propertys = new Dictionary<string, string>()
    {
        {"Money", "10000" }
    };
    public static void AddMoney(BigInteger money)
    {
        Propertys["Money"] = BigInteger.Add(BigInteger.Parse(Propertys["Money"]), money).ToString();
    }
    public static string GetMoney()
    {
        return MoneyCalculation.Convert(Propertys["Money"]);
    }
    public static void SetPropert(string code)
    {
        Propertys = JsonConvert.DeserializeObject<Dictionary<string, string>>(code);
    }
    public static string GetProperty()
    {
        return JsonConvert.SerializeObject(Propertys);
    }
}

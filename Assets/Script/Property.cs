using System.Numerics;
using System.Collections.Generic;
using Newtonsoft.Json;

public class Property
{
    /*public static Dictionary<string, string> Propertys = new Dictionary<string, string>()
    {
        {"Money", "10000" }
    };*/
    private Dictionary<string, string> Propertys = new Dictionary<string, string>()
    {
        {"Money", "10000" }
    };
    public void AddMoney(string money)
    {
        Propertys["Money"] = BigInteger.Add(BigInteger.Parse(Propertys["Money"]), BigInteger.Parse(money)).ToString();
    }
    public string GetMoney()
    {
        return MainSystem.MC.Compress(Propertys["Money"]);
    }
    public void SetPropert(string code)
    {
        Propertys = JsonConvert.DeserializeObject<Dictionary<string, string>>(code);
    }
    public string GetProperty()
    {
        return JsonConvert.SerializeObject(Propertys);
    }
}

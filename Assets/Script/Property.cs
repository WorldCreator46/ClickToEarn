using System.Numerics;
using System.Collections.Generic;
using Newtonsoft.Json;

public class Property
{
    private static Dictionary<string, string> Propertys = new Dictionary<string, string>()
    {
        {"Money", "0" }
    };
    public static void AddMoney(BigInteger money)
    {
        Propertys["Money"] = BigInteger.Add(BigInteger.Parse(Propertys["Money"]), money).ToString();
    }
    public static void SetMoney(string money)
    {
        Propertys["Money"] = money;
    }
    public static bool SubtractMoney(BigInteger money)
    {
        BigInteger temp = BigInteger.Subtract(BigInteger.Parse(Propertys["Money"]), money);
        if (temp >= BigInteger.Zero)
        {
            Propertys["Money"] = temp.ToString();
            return true;
        }
        else
        {
            return false;
        }            
    }
    public static string GetMoney()
    {
        return MoneyCalculation.Convert(Propertys["Money"]);
    }
    public static string GetMoney(object pass)
    {
        return Propertys["Money"];
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

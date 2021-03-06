using System.Collections.Generic;
using System.Numerics;
using Newtonsoft.Json;
using UnityEngine;

public class Performance : MonoBehaviour
{
    /* ????Ʈ ???? {"?ʱⰡ??", "???? ???? ??", "???? ???? ??", "???? Ƚ??"}*/
    private static Dictionary<string, List<string>> Performances = new Dictionary<string, List<string>>()
    {
        {"??? ?? ???? ????",  new List<string> { "10", "2", "1", "0" }},
        {"??? ?ڷ? ???? ????",  new List<string> { "10", "2", "1", "0" } },
        {"??? ?? ???? ??ȭ",  new List<string> { "100000", "2", "12500", "0" } },
        {"??? ?ڷ? ???? ??ȭ",  new List<string> { "100000", "2", "12500", "0" } },
        {"?尩 ???? ??ȭ",  new List<string> { "1000000", "2", "150000", "0" } },
        {"?Ź? ???? ??ȭ",  new List<string> { "1000000", "2", "150000", "0" } },
        {"?????? ???? ??ȭ",  new List<string> { "1000000", "2", "150000", "0" } }
    };
    public static BigInteger GetMultiplicand()
    {
        BigInteger result = BigInteger.Parse("1000");
        foreach(string name in Performances.Keys)
        {
            result += GetIncreaseValue(name);
        }
        return result;
    }
    public static BigInteger GetIncreaseValue(string ProductName)
    {
        BigInteger value = BigInteger.Parse(Performances[ProductName][2]);
        if(Performances[ProductName][3] == "0") { return BigInteger.Zero; }
        else if(Performances[ProductName][3] == "1") { return value;}
        BigInteger Temp = MoneyCalculation.Pow(2, BigInteger.Parse(Performances[ProductName][3])) - 1;
        value *= Temp;
        return value;
    }
    public static string PriceCalculation(string ProductName)
    {
        BigInteger result = BigInteger.Parse(Performances[ProductName][0]);
        result *= MoneyCalculation.Pow(Performances[ProductName][1], Performances[ProductName][3]);
        return result.ToString();
    }
    public static void Upgrade(string ProductName)
    {
        Performances[ProductName][3] = (BigInteger.Parse(Performances[ProductName][3]) + 1).ToString();
    }
    public static bool IsProduct(string ProductName)
    {
        return Performances.ContainsKey(ProductName);
    }
    public static string GetNumberOfPurchases(string ProductName)
    {
        return Performances[ProductName][3];
    }
    public static void SetPerformance(string code)
    {
        Performances = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(code);
    }
    public static string GetPerformance()
    {
        return JsonConvert.SerializeObject(Performances);
    }
}

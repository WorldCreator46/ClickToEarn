using System.Collections.Generic;
using System.Numerics;
using Newtonsoft.Json;
using UnityEngine;

public class Performance : MonoBehaviour
{
    /* 리스트 구성 {"초기가격", "가격 증가 폭", "성능 증가 폭", "구매 횟수"}*/
    private static Dictionary<string, List<string>> Performances = new Dictionary<string, List<string>>()
    {
        {"곡괭이 날 강도 증가",  new List<string> { "10", "2", "1", "0" }},
        {"곡괭이 자루 강도 증가",  new List<string> { "10", "2", "1", "0" } },
        {"곡괭이 날 재질 강화",  new List<string> { "100000", "2", "12500", "0" } },
        {"곡괭이 자루 재질 강화",  new List<string> { "100000", "2", "12500", "0" } },
        {"장갑 재질 강화",  new List<string> { "1000000", "2", "150000", "0" } },
        {"신발 재질 강화",  new List<string> { "1000000", "2", "150000", "0" } },
        {"안전모 재질 강화",  new List<string> { "1000000", "2", "150000", "0" } }
    };
    public static BigInteger GetMultiplicand()
    {
        BigInteger result = BigInteger.Parse("1000");
        foreach(string name in Performances.Keys)
        {
            result = BigInteger.Add(result, GetIncreaseValue(name));
        }
        return result;
    }
    public static BigInteger GetIncreaseValue(string ProductName)
    {
        BigInteger value = BigInteger.Parse(Performances[ProductName][2]);
        if (Performances[ProductName][3] == "0") { return BigInteger.Zero; }
        for(int i = 1; i < int.Parse(Performances[ProductName][3]); i++)
        {
            value = BigInteger.Add(value, value);
        }
        return value;
    }
    public static string PriceCalculation(string ProductName)
    {
        return BigInteger.Multiply(BigInteger.Parse(Performances[ProductName][0]), BigInteger.Pow(BigInteger.Parse(Performances[ProductName][1]), int.Parse(Performances[ProductName][3]))).ToString();
    }
    public static void Upgrade(string ProductName)
    {
        Performances[ProductName][3] = (int.Parse(Performances[ProductName][3]) + 1).ToString();
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

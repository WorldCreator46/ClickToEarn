using System.Collections.Generic;
using System.Numerics;
using Newtonsoft.Json;
using UnityEngine;

public class Performance : MonoBehaviour
{
    /* ����Ʈ ���� {"�ʱⰡ��", "���� ���� ��", "���� ���� ��", "���� Ƚ��"}*/
    private static List<string> PickaxeBladeRobber = new List<string> { "10", "2", "1", "0" };
    private static List<string> PickaxeGripRobber = new List<string> { "10", "2", "1", "0" };
    private static List<string> PickaxeBladeQuality = new List<string> { "100000", "2", "12500", "0" };
    private static List<string> PickaxeGripQuality = new List<string> { "100000", "2", "12500", "0" };
    private static List<string> GlovesQuality = new List<string> { "1000000", "2", "150000", "0" };
    private static List<string> ShoesQuality = new List<string> { "1000000", "2", "150000", "0" };
    private static List<string> SafetyHelmetQuality = new List<string> { "1000000", "2", "150000", "0" };
    private static Dictionary<string, List<string>> Performances = new Dictionary<string, List<string>>()
    {
        {"��� �� ���� ����",  PickaxeBladeRobber },
        {"��� �ڷ� ���� ����",  PickaxeGripRobber },
        {"��� �� ���� ��ȭ",  PickaxeBladeQuality },
        {"��� �ڷ� ���� ��ȭ",  PickaxeGripQuality },
        {"�尩 ���� ��ȭ",  GlovesQuality },
        {"�Ź� ���� ��ȭ",  ShoesQuality },
        {"������ ���� ��ȭ",  SafetyHelmetQuality }
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

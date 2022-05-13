using System.Collections.Generic;
using System.Numerics;
using Newtonsoft.Json;
using UnityEngine;

public class Skill : MonoBehaviour
{
    /* ����Ʈ ���� {"�ʱⰡ��", "���� ���� ��", "���� ���� ��", "���� Ƚ��"}*/
    private static Dictionary<string, List<string>> Skills = new Dictionary<string, List<string>>()
    {
        {"�Ƿ� ����", new List<string>(){ "1000000", "2", "3", "0"} },
        {"�÷� ����", new List<string>() { "1000000000", "2", "3", "0" } },
        {"�ٷ� ����", new List<string>() { "1000000000000", "3", "4", "0" } },
        {"ü�� ����", new List<string>() { "1000000000000000", "3", "4", "0" } }
    };
    public static BigInteger GetMultiplier()
    {
        BigInteger result = BigInteger.Zero;
        foreach (string name in Skills.Keys)
        {
            result = BigInteger.Add(result, GetIncreaseValue(name));
        }
        return result;
    }
    public static BigInteger GetIncreaseValue(string ProductName)
    {
        BigInteger value = BigInteger.Parse(Skills[ProductName][2]);
        if (Skills[ProductName][3] == "0") { return BigInteger.Zero; }
        else if (Skills[ProductName][3] == "1") { return value; }
        BigInteger Temp = MoneyCalculation.Pow(2, BigInteger.Parse(Skills[ProductName][3]));
        Temp = BigInteger.Subtract(Temp, 1);
        value = BigInteger.Multiply(value, Temp);
        return value;
    }
    public static string PriceCalculation(string ProductName)
    {
        return BigInteger.Multiply(BigInteger.Parse(Skills[ProductName][0]), MoneyCalculation.Pow(BigInteger.Parse(Skills[ProductName][1]), BigInteger.Parse(Skills[ProductName][3]))).ToString();
    }
    public static void Upgrade(string ProductName)
    {
        Skills[ProductName][3] = (int.Parse(Skills[ProductName][3]) + 1).ToString();
    }
    public static void SetSkill(string code)
    {
        Skills = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(code);
    }
    public static string GetSkill()
    {
        return JsonConvert.SerializeObject(Skills);
    }
    public static bool IsProduct(string ProductName)
    {
        return Skills.ContainsKey(ProductName);
    }
    public static string GetNumberOfPurchases(string ProductName)
    {
        return Skills[ProductName][3];
    }
}

using System.Collections.Generic;
using System.Numerics;
using Newtonsoft.Json;
using UnityEngine;

public class Skill : MonoBehaviour
{
    /* ����Ʈ ���� {"�ʱⰡ��", "���� ���� ��", "���� ���� ��", "���� Ƚ��"}*/
    private static List<string> GripStrength = new List<string>(){ "1000000", "2", "3", "0"};
    private static List<string> Sight = new List<string>() { "1000000000", "2", "3", "0" };
    private static List<string> MuscularStrength = new List<string>() { "1000000000000", "3", "4", "0" };
    private static List<string> Stamina = new List<string>() { "1000000000000000", "3", "4", "0" };
    private static Dictionary<string, List<string>> Skills = new Dictionary<string, List<string>>()
    {
        {"�Ƿ� ����", GripStrength },
        {"�÷� ����", Sight },
        {"�ٷ� ����", MuscularStrength },
        {"ü�� ����", Stamina }
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
        BigInteger value = BigInteger.Parse(Skills[ProductName][3]);
        BigInteger result = BigInteger.Zero;
        if (Skills[ProductName][3] == "0") { return BigInteger.Zero; }
        for (int i = 0; i < int.Parse(Skills[ProductName][3]); i++)
        {
            result = BigInteger.Add(result, value);
            value = BigInteger.Add(value, value);
        }
        return result;
    }
    public static string PriceCalculation(string ProductName)
    {
        return BigInteger.Multiply(BigInteger.Parse(Skills[ProductName][0]), BigInteger.Pow(BigInteger.Parse(Skills[ProductName][1]), int.Parse(Skills[ProductName][3]))).ToString();
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

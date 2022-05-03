using System.Collections.Generic;
using System.Numerics;
using Newtonsoft.Json;
using UnityEngine;
using System.Linq;

public class Skill : MonoBehaviour
{
    /* ����Ʈ ���� {"��ǰ��", "�ʱⰡ��", "���� ���� ��", "���� ������", "���� Ƚ��"}*/
    private static List<string>[] Skills = new List<string>[]
    {
        new List<string>(){ "�Ƿ� ����", "1000000", "2", "3", "0"},
        new List<string>(){ "�÷� ����", "1000000000", "2", "3", "0"},
        new List<string>(){ "�ٷ� ����", "1000000000000", "3", "4", "0"},
        new List<string>(){ "ü�� ����", "1000000000000000", "3", "4", "0"}
    };
    public static BigInteger GetMultiplier()
    {
        BigInteger result = BigInteger.One;
        for (int idx = 0; idx < Skills.Length; idx++)
        {
            result = BigInteger.Add(result, GetIncreaseValue(idx));
        }
        if (!result.IsOne)
        {
            result = BigInteger.Subtract(result, BigInteger.One);
        }
        return result;
    }
    public static Dictionary<string, BigInteger> PriceCalculationMenu()
    {
        Dictionary<string, BigInteger> menu = new Dictionary<string, BigInteger>();
        for (int idx = 0; idx < Skills.Length; idx++)
        {
            menu[Skills[idx][0]] = BigInteger.Multiply(BigInteger.Parse(Skills[idx][1]), BigInteger.Pow(BigInteger.Parse(Skills[idx][2]), int.Parse(Skills[idx][4])));
        }
        return menu;
    }
    public static string PriceCalculation(string ProductName)
    {
        int idx = GetProductNumber(ProductName);
        return BigInteger.Multiply(BigInteger.Parse(Skills[idx][1]), BigInteger.Pow(BigInteger.Parse(Skills[idx][2]), int.Parse(Skills[idx][4]))).ToString();
    }
    public static void Upgrade(string ProductName)
    {
        int idx = GetProductNumber(ProductName);
        Skills[idx][4] = (int.Parse(Skills[idx][4]) + 1).ToString();
    }
    public static void SetSkill(string code)
    {
        Skills = JsonConvert.DeserializeObject<List<string>[]>(code);
    }
    public static string GetSkill()
    {
        return JsonConvert.SerializeObject(Skills);
    }
    public static int GetProductNumber(string ProductName)
    {
        for (int idx = 0; idx < Skills.Length; idx++)
        {
            if (Skills[idx][0] == ProductName)
            {
                return idx;
            }
        }
        return -1;
    }
    public static bool IsProduct(string ProductName)
    {
        int num = GetProductNumber(ProductName);
        return num < 0 ? false : true;
    }
    public static string GetNumberOfPurchases(string ProductName)
    {
        return Skills[GetProductNumber(ProductName)][4];
    }
    public static string GetIncreaseValue(string ProductName)
    {
        int idx = GetProductNumber(ProductName);
        if (Skills[idx][4] == "0") { return "0"; }
        return GetIncreaseValue(idx).ToString();
    }
    public static BigInteger GetIncreaseValue(int idx)
    {
        BigInteger value = BigInteger.Parse(Skills[idx][3]);
        BigInteger result = BigInteger.Zero;
        if (Skills[idx][4] == "0") { return BigInteger.Zero; }
        for (int i = 0; i < int.Parse(Skills[idx][4]); i++)
        {
            result = BigInteger.Add(result, value);
            value = BigInteger.Add(value, value);
        }
        return result;
    }
}

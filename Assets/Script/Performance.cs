using System.Collections.Generic;
using System.Numerics;
using Newtonsoft.Json;
using UnityEngine;

public class Performance : MonoBehaviour
{
    /* ����Ʈ ���� {"��ǰ��", "�ʱⰡ��", "���� ���� ��", "���� ������", "���� Ƚ��"}*/
    private static List<string>[] Performances = new List<string>[]
    {
        new List<string>(){ "��� �� ���� ����", "10", "2", "1", "0"},
        new List<string>(){ "��� �ڷ� ���� ����", "10", "2", "1", "0"},
        new List<string>(){ "��� �� ���� ��ȭ", "100000", "2", "12500", "0"},
        new List<string>(){ "��� �ڷ� ���� ��ȭ", "100000", "2", "12500", "0"},
        new List<string>(){ "�尩 ���� ��ȭ", "1000000", "2", "150000", "0"},
        new List<string>(){ "�Ź� ���� ��ȭ", "1000000", "2", "150000", "0"},
        new List<string>(){ "������ ���� ��ȭ", "1000000", "2", "150000", "0"}
    };
    public static BigInteger GetMultiplicand()
    {
        BigInteger result = BigInteger.Parse("1000");
        for (int idx = 0; idx < Performances.Length; idx++)
        {
            result = BigInteger.Add(result, GetIncreaseValue(idx));
        }
        return result;
    }
    public static Dictionary<string, BigInteger> PriceCalculationMenu()
    {
        Dictionary<string, BigInteger> menu = new Dictionary<string, BigInteger>();
        for (int idx = 0; idx < Performances.Length; idx++)
        {
            menu[Performances[idx][0]] = BigInteger.Multiply(BigInteger.Parse(Performances[idx][1]), BigInteger.Pow(BigInteger.Parse(Performances[idx][2]), int.Parse(Performances[idx][4])));
        }
        return menu;
    }
    public static string PriceCalculation(string ProductName)
    {
        int idx = GetProductNumber(ProductName);
        return BigInteger.Multiply(BigInteger.Parse(Performances[idx][1]), BigInteger.Pow(BigInteger.Parse(Performances[idx][2]), int.Parse(Performances[idx][4]))).ToString();
    }
    public static void Upgrade(string ProductName)
    {
        int idx = GetProductNumber(ProductName);
        Performances[idx][4] = (int.Parse(Performances[idx][4]) + 1).ToString();
    }
    public static int GetProductNumber(string ProductName)
    {
        for (int idx = 0; idx < Performances.Length; idx++)
        {
            if (Performances[idx][0] == ProductName)
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
        return Performances[GetProductNumber(ProductName)][4];
    }
    public static string GetIncreaseValue(string ProductName)
    {
        int idx = GetProductNumber(ProductName);
        if (Performances[idx][4] == "0") { return "0"; }
        return GetIncreaseValue(idx).ToString();
    }
    public static BigInteger GetIncreaseValue(int idx)
    {
        BigInteger value = BigInteger.Parse(Performances[idx][3]);
        if (Performances[idx][4] == "0") { return BigInteger.Zero; }
        for(int i = 1; i < int.Parse(Performances[idx][4]); i++)
        {
            value = BigInteger.Add(value, value);
        }
        return value;
    }
    public static void SetPerformance(string code)
    {
        Performances = JsonConvert.DeserializeObject<List<string>[]>(code);
    }
    public static string GetPerformance()
    {
        return JsonConvert.SerializeObject(Performances);
    }
}

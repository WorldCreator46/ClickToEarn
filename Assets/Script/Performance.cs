using System.Collections.Generic;
using System.Numerics;
using Newtonsoft.Json;
using UnityEngine;

public class Performance : MonoBehaviour
{
    /* ����Ʈ ���� {"��ǰ��", "�ʱⰡ��", "���� ���� ��", "���� ������", "���� Ƚ��"}*/
    private static List<string>[] Performances = new List<string>[]
    {
        new List<string>(){ "��� �� ���� ����", "10", "2", "100", "0"},
        new List<string>(){ "��� �ڷ� ���� ����", "10", "2", "100", "0"},
        new List<string>(){ "��� �� ���� ��ȭ", "100000", "3", "10000", "0"},
        new List<string>(){ "��� �ڷ� ���� ��ȭ", "100000", "3", "10000", "0"},
        new List<string>(){ "�尩 ���� ��ȭ", "1000000", "5", "500000", "0"},
        new List<string>(){ "�Ź� ���� ��ȭ", "1000000", "5", "500000", "0"},
        new List<string>(){ "������ ���� ��ȭ", "1000000", "5", "500000", "0"}
    };
    public static BigInteger GetMultiplicand()
    {
        BigInteger result = BigInteger.Parse("1000");
        for (int idx = 0; idx < Performances.Length; idx++)
        {
            result = BigInteger.Add(result, BigInteger.Multiply(BigInteger.Parse(Performances[idx][3]), BigInteger.Parse(Performances[idx][4])));
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
        for(int idx = 0; idx < Performances.Length; idx++)
        {
            if(Performances[idx][0] == ProductName)
            {
                return BigInteger.Multiply(BigInteger.Parse(Performances[idx][1]), BigInteger.Pow(BigInteger.Parse(Performances[idx][2]), int.Parse(Performances[idx][4]))).ToString();
            }
        }
        return "";
    }
    public static void Upgrade(string ProductName)
    {
        for (int idx = 0; idx < Performances.Length; idx++)
        {
            if (Performances[idx][0] == ProductName)
            {
                Performances[idx][4] = (int.Parse(Performances[idx][4]) + 1).ToString();
            }
        }
    }
    public static bool IsProduct(string ProductName)
    {
        for (int idx = 0; idx < Performances.Length; idx++)
        {
            if (Performances[idx][0] == ProductName)
            {
                return true;
            }
        }
        return false;
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

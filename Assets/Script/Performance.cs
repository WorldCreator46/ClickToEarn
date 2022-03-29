using System.Collections.Generic;
using System.Numerics;
using Newtonsoft.Json;
using UnityEngine;
using System.Linq;

public class Performance : MonoBehaviour
{
    /* ����Ʈ ���� {"��ǰ��", "�ʱⰡ��", "���� ���� ��", "���� ������", "���� Ƚ��"}*/
    private static List<string>[] Performances = new List<string>[]
    {
        new List<string>(){ "��� �� ���� ����", "10", "2", "10", "0"},
        new List<string>(){ "��� �ڷ� ���� ����", "10", "2", "10", "0"},
        new List<string>(){ "��� �� ���� ��ȭ", "100000", "3", "1000", "0"},
        new List<string>(){ "��� �ڷ� ���� ��ȭ", "100000", "3", "1000", "0"},
        new List<string>(){ "�尩 ���� ��ȭ", "1000000", "5", "50000", "0"},
        new List<string>(){ "�Ź� ���� ��ȭ", "1000000", "5", "50000", "0"},
        new List<string>(){ "������ ���� ��ȭ", "1000000", "5", "50000", "0"}
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
    public static List<string>[] PriceCalculation()
    {
        List<string>[] menu = new List<string>[Performances.Length];
        for (int idx = 0; idx < Performances.Length; idx++)
        {
            List<string> temp = new List<string>()
            {
                Performances[idx][0],
                BigInteger.Multiply(BigInteger.Parse(Performances[idx][1]), BigInteger.Pow(BigInteger.Parse(Performances[idx][2]), int.Parse(Performances[idx][4]))).ToString()
            };
            menu[idx] = temp.ToList();
        }
        return menu;
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

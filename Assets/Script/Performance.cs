using System.Collections.Generic;
using System.Numerics;
using Newtonsoft.Json;

public class Performance
{
    static string DefaultMoney = "1000";
    /* ����Ʈ ���� {"��ǰ��", "�ʱⰡ��", "���� ���� ��", "���� ������", "���� Ƚ��"}*/
    public static List<string>[] Performances = new List<string>[]
    {
        new List<string>(){ "��� �� ���� ����", "10", "2", "10", "0"},
        new List<string>(){ "��� �ڷ� ���� ����", "10", "2", "10", "0"},
        new List<string>(){ "��� �� ���� ��ȭ", "100000", "3", "1000", "0"},
        new List<string>(){ "��� �ڷ� ���� ��ȭ", "100000", "3", "1000", "0"},
        new List<string>(){ "�尩 ���� ��ȭ", "1000000", "5", "50000", "0"},
        new List<string>(){ "�Ź� ���� ��ȭ", "1000000", "5", "50000", "0"},
        new List<string>(){ "������ ���� ��ȭ", "1000000", "5", "50000", "0"}
    };
    public static string EranMoney()
    {
        BigInteger result = BigInteger.Parse(DefaultMoney);
        for(int idx = 0; idx < Performances.Length; idx++)
        {
            if(Performances[idx][4] != "0")
            {
                BigInteger x = BigInteger.Parse(Performances[idx][1]), y = BigInteger.Parse(Performances[idx][2]);
                BigInteger.Add(result, BigInteger.Multiply(x, BigInteger.Pow(y, int.Parse(Performances[idx][4]))));
            }
        }
        return result.ToString();
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

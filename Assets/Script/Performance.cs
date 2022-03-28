using System.Collections.Generic;
using System.Numerics;
using Newtonsoft.Json;

public class Performance
{ 
    /* ����Ʈ ���� {"��ǰ��", "�ʱⰡ��", "���� ���� ��", "���� ������", "���� Ƚ��"}*/
    private List<string>[] Performances = new List<string>[]
    {
        new List<string>(){ "��� �� ���� ����", "10", "2", "10", "0"},
        new List<string>(){ "��� �ڷ� ���� ����", "10", "2", "10", "0"},
        new List<string>(){ "��� �� ���� ��ȭ", "100000", "3", "1000", "0"},
        new List<string>(){ "��� �ڷ� ���� ��ȭ", "100000", "3", "1000", "0"},
        new List<string>(){ "�尩 ���� ��ȭ", "1000000", "5", "50000", "0"},
        new List<string>(){ "�Ź� ���� ��ȭ", "1000000", "5", "50000", "0"},
        new List<string>(){ "������ ���� ��ȭ", "1000000", "5", "50000", "0"}
    };
    public BigInteger GetMultiplicand()
    {
        BigInteger result = BigInteger.Parse("1000");
        for (int idx = 0; idx < Performances.Length; idx++)
        {
            result = BigInteger.Add(result, BigInteger.Multiply(BigInteger.Parse(Performances[idx][3]), BigInteger.Parse(Performances[idx][4])));
        }
        return result;
    }
    public void SetPerformance(string code)
    {
        Performances = JsonConvert.DeserializeObject<List<string>[]>(code);
    }
    public string GetPerformance()
    {
        return JsonConvert.SerializeObject(Performances);
    }
}

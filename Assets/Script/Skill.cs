using System.Collections.Generic;
using System.Numerics;
using Newtonsoft.Json;

public class Skill
{
    /* ����Ʈ ���� {"��ǰ��", "�ʱⰡ��", "���� ���� ��", "���� ������", "���� Ƚ��"}*/
    private List<string>[] Skills = new List<string>[]
    {
        new List<string>(){ "�Ƿ� ����", "1000000", "5", "10", "0"},
        new List<string>(){ "�÷� ����", "1000000000", "5", "20", "0"},
        new List<string>(){ "�ٷ� ��ȭ", "1000000000000", "10", "30", "0"},
        new List<string>(){ "ü�� ��ȭ", "1000000000000000", "10", "50", "0"}
    };
    public BigInteger GetMultiplier()
    {
        BigInteger result = BigInteger.Parse("100");
        for (int idx = 0; idx < Skills.Length; idx++)
        {
            result = BigInteger.Add(result, BigInteger.Multiply(BigInteger.Parse(Skills[idx][3]), BigInteger.Parse(Skills[idx][4])));
        }
        return result;
    }
    public void SetSkill(string code)
    {
        Skills = JsonConvert.DeserializeObject<List<string>[]>(code);
    }
    public string GetSkill()
    {
        return JsonConvert.SerializeObject(Skills);
    }
}

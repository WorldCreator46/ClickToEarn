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
        new List<string>(){ "�Ƿ� ����", "1000000", "5", "10", "0"},
        new List<string>(){ "�÷� ����", "1000000000", "5", "20", "0"},
        new List<string>(){ "�ٷ� ����", "1000000000000", "10", "30", "0"},
        new List<string>(){ "ü�� ����", "1000000000000000", "10", "50", "0"}
    };
    public static BigInteger GetMultiplier()
    {
        BigInteger result = BigInteger.Parse("100");
        for (int idx = 0; idx < Skills.Length; idx++)
        {
            result = BigInteger.Add(result, BigInteger.Multiply(BigInteger.Parse(Skills[idx][3]), BigInteger.Parse(Skills[idx][4])));
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
        for (int idx = 0; idx < Skills.Length; idx++)
        {
            if (Skills[idx][0] == ProductName)
            {
                return BigInteger.Multiply(BigInteger.Parse(Skills[idx][1]), BigInteger.Pow(BigInteger.Parse(Skills[idx][2]), int.Parse(Skills[idx][4]))).ToString();
            }
        }
        return "";
    }
    public static void Upgrade(string ProductName)
    {
        for (int idx = 0; idx < Skills.Length; idx++)
        {
            if (Skills[idx][0] == ProductName)
            {
                Skills[idx][4] = (int.Parse(Skills[idx][4]) + 1).ToString();
            }
        }
    }
    public static void SetSkill(string code)
    {
        Skills = JsonConvert.DeserializeObject<List<string>[]>(code);
    }
    public static string GetSkill()
    {
        return JsonConvert.SerializeObject(Skills);
    }
}

using System.Numerics;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MoneyCalculation : MonoBehaviour
{
    readonly static char[] Units = {'K', 'M', 'G', 'T', 'P', 'E', 'Z', 'Y' };
    public static string Convert(string _Money)
    {
        BigInteger Quotient = BigInteger.Parse(_Money);
        BigInteger Remainder = BigInteger.Zero;
        Dictionary<int, char> TempUnit = new Dictionary<int, char>();
        for (int Sequence = 0; Sequence >= 0; Sequence++)
        {
            if (-1 == BigInteger.Compare(Quotient, BigInteger.Parse("1000")))
            {
                break;
            }
            TempUnit[Sequence / 8] = Units[Sequence % 8];
            Quotient = BigInteger.DivRem(Quotient, BigInteger.Parse("1000"), out Remainder);
        }

        string Unit;
        if (TempUnit.Count >= 2 && TempUnit[TempUnit.Count - 1] == 'Y')
        {
            Unit = TempUnit[TempUnit.Count - 1].ToString() + TempUnit.Count.ToString();
        }
        else if (TempUnit.Count == 2 && TempUnit[TempUnit.Count - 1] != 'Y')
        {
            Unit = TempUnit[TempUnit.Count - 1].ToString() + TempUnit[0].ToString();
        }
        else if (TempUnit.Count > 2)
        {
            Unit = TempUnit[TempUnit.Count - 1].ToString() + TempUnit[0].ToString() + (TempUnit.Count - 1).ToString();
        }
        else
        {
            Unit = TempUnit[0].ToString();
        }
        return $"{Quotient}.{Remainder}{Unit}";
    }
    public static BigInteger EranMoney()
    {
        BigInteger result = BigInteger.Multiply(Performance.GetMultiplicand(), Skill.GetMultiplier());        
        return BigInteger.Divide(result, BigInteger.Parse("100"));
    }
    public static string GetEranMoney()
    {
        return Convert(EranMoney().ToString());
    }
    public static List<string>[] GetPrice()
    {
        List<string>[] menu = Performance.PriceCalculation().Concat(Skill.PriceCalculation()).ToArray();
        return menu;
    }
}

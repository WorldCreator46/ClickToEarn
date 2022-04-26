using System.Numerics;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.Text;

public class MoneyCalculation : MonoBehaviour
{
    readonly static char[] Units = {'K', 'M', 'G', 'T', 'P', 'E', 'Z', 'Y' };
    public static string Convert(string _Money)
    {
        BigInteger Quotient = BigInteger.Parse(_Money);
        if (-1 == BigInteger.Compare(Quotient, BigInteger.Parse("1000")))
        {
            return _Money;
        }
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
        StringBuilder remainder;
        if (Remainder.ToString() == "0")
        {
            return $"{Quotient}{Unit}";
        }
        else
        {
            remainder = new StringBuilder(Remainder.ToString().PadLeft(4, '0'));
            for(int i = 3; i > 0; i--)
            {
                if(remainder[i] == '0')
                {
                    remainder.Remove(i, 1);
                }
                else
                {
                    break;
                }
            }
        }
        return $"{Quotient}.{remainder}{Unit}";
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
    public static Dictionary<string,BigInteger> GetPriceMenu()
    {
        Dictionary<string, BigInteger> menu = new Dictionary<string, BigInteger>();
        Performance.PriceCalculationMenu().ToList().ForEach(x => menu.Add(x.Key, x.Value));
        Skill.PriceCalculationMenu().ToList().ForEach(x => menu.Add(x.Key, x.Value));
        return menu;
    }
    public static string GetPrice(string ProductName)
    {
        string price = Performance.PriceCalculation(ProductName);
        if (price == "")
        {
            price = Skill.PriceCalculation(ProductName);
        }
        return price;
    }
    public static void Upgrade(string ProductName)
    {
        if (Performance.IsProduct(ProductName))
        {
            Performance.Upgrade(ProductName);
        }
        else if (Skill.IsProduct(ProductName))
        {
            Skill.Upgrade(ProductName);
        }
    }
    public static string GetEnhanceCost(int Grade, int Class)
    {
        BigInteger Cost = new BigInteger(1000000);
        Cost = BigInteger.Multiply(Cost, BigInteger.Pow(BigInteger.Parse(Grade.ToString()), Grade));
        Cost = BigInteger.Multiply(Cost, Class * 10);
        return Convert(Cost.ToString());
    }
}

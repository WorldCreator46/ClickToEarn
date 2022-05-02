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
            remainder = new StringBuilder(Remainder.ToString().PadLeft(3, '0'));
            for(int i = 2; i > 0; i--)
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
        return BigInteger.Multiply(result, BigInteger.Parse(CrystalUpgrade.GetPerformance()));
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
    public static string GetUpgradeCost()
    {
        //.PadRight(0, '0');
        StringBuilder Cost = new StringBuilder();
        int Grade = CrystalUpgrade.GetCrystalGrade();
        int Class = int.Parse(CrystalUpgrade.GetCrystalClass());
        if (Grade == 0 || Grade % 2 != 0)
        {
            Cost.Append(1);
        }
        else
        {
            Cost.Append(5);
        }
        Cost.Append(Class);
        Grade *= 12;
        Grade += 6;
        Cost.Append("".PadRight(Grade, '0'));
        Cost.Append("".PadRight(Class, '0'));
        return Cost.ToString();
    }
    public static string GetEvolutionCost()
    {
        return BigInteger.Multiply(BigInteger.Parse(GetUpgradeCost()), BigInteger.Parse("10")).ToString();
    }
    public static bool CostComparison()
    {
        bool Cost = false;
        switch(BigInteger.Compare(BigInteger.Parse(GetUpgradeCost()), BigInteger.Parse(Property.GetMoney(true))))
        {
            case -1:
                Cost = true;
                break;
            case 0:
                Cost = true;
                break;
            case 1:
                Cost = false;
                break;
        }
        return Cost;
    }
}

using System.Numerics;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class MoneyCalculation : MonoBehaviour
{
    static char[] Units = {'K', 'M', 'G', 'T', 'P', 'E', 'Z', 'Y' };
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
    public static string Convert(BigInteger _Money)
    {
        return Convert(_Money.ToString()); 
    }
    private static BigInteger EarnMoneyValue = BigInteger.Zero;
    private static string EarnMoneyString = "";
    private static string CheckString = "";
    public static BigInteger EarnMoney()
    {
        if (CheckEarnMoney())
        {
            BigInteger performance = Performance.GetMultiplicand();
            BigInteger skill = Skill.GetMultiplier();
            BigInteger Temp = performance * skill;
            performance *= BigInteger.Parse("100");
            EarnMoneyValue = performance + Temp;
            EarnMoneyValue /= BigInteger.Parse("100");
            EarnMoneyValue *= CrystalUpgrade.GetPerformance();
        }
        return EarnMoneyValue;
    }
    public static string GetEarnMoney()
    {
        if(CheckEarnMoney()) EarnMoneyString = Convert(EarnMoney());
        return EarnMoneyString;
    }
    public static bool CheckEarnMoney()
    {
        bool Check = true;
        string _CheckString = $"{Performance.GetPerformance()}{Skill.GetSkill()}";
        if (CheckString.Equals(_CheckString) && !EarnMoneyValue.Equals("") && !EarnMoneyString.Equals("")) Check = false;
        else CheckString = _CheckString;
        return Check;
    }
    public static string GetPrice(string ProductName)
    {
        string price = "";
        if (Performance.IsProduct(ProductName))
        {
            price = Performance.PriceCalculation(ProductName);
        }
        else if (Skill.IsProduct(ProductName))
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
    public static string GetNumberOfPurchases(string ProductName)
    {
        if (Performance.IsProduct(ProductName))
        {
            return Convert(Performance.GetNumberOfPurchases(ProductName));
        }
        else if (Skill.IsProduct(ProductName))
        {
            return Convert(Skill.GetNumberOfPurchases(ProductName));
        }
        return "";
    }
    public static string GetEvolutionCost()
    {
        return Convert((BigInteger.Parse(GetUpgradeCost()) * BigInteger.Parse("10")).ToString());
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
    public static string GetIncreaseValue(string ProductName)
    {
        string result = "";
        if (Performance.IsProduct(ProductName))
        {
            result = Performance.GetIncreaseValue(ProductName).ToString();
        }
        else if (Skill.IsProduct(ProductName))
        {
            result = Skill.GetIncreaseValue(ProductName).ToString();
        }
        return Convert(result);
    }
    public static BigInteger Pow(BigInteger Base, BigInteger exp)
    {
        BigInteger Result = BigInteger.One;
        while(exp > 0)
        {
            if(!exp.IsEven)
            {
                Result *= Base;
            }
            Base *= Base;
            exp /= 2;
        }
        return Result;
    }
    public static BigInteger Pow(string Base, string exp)
    {
        return Pow(BigInteger.Parse(Base), BigInteger.Parse(exp));
    }
}

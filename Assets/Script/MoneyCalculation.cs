using System.Numerics;
using UnityEngine;
using System.Collections.Generic;

public class MoneyCalculation : MonoBehaviour
{
    static readonly char[] Units = {'K', 'M', 'G', 'T', 'P', 'E', 'Z', 'Y' };
    public static string Compress(BigInteger _Money)
    {
        BigInteger Quotient = _Money;
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
}

using System.Numerics;
using UnityEngine;
using System.Collections.Generic;
using System.Text;

public class MoneyCalculation : MonoBehaviour
{
    static readonly char[] Units = {'K', 'M', 'G', 'T', 'P', 'E', 'Z', 'Y' };
    public static string Compress(BigInteger _Money)
    {
        BigInteger Quotient = _Money;
        Dictionary<int, char> TempUnit = new Dictionary<int, char>();
        StringBuilder Unit = new StringBuilder();
        for (int Sequence = 0; Sequence >= 0; Sequence++)
        {
            if (-1 == BigInteger.Compare(Quotient, BigInteger.Parse("1000")))
            {
                break;
            }
            TempUnit[Sequence / 8] = Units[Sequence % 8];
            Quotient = BigInteger.Divide(Quotient, BigInteger.Parse("1000"));
        }
        for(int Sequence = TempUnit.Count-1; Sequence >= 0; Sequence--)
        {
            Unit.Append(TempUnit[Sequence]);
        }
        return Quotient.ToString() + Unit.ToString();
    }
}

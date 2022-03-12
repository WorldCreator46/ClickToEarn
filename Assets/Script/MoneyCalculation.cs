using System.Numerics;
using UnityEngine;

public class MoneyCalculation : MonoBehaviour
{
    public static string Compress(BigInteger _Money)
    {
        string[] Units = {"", "K", "M", "G", "T", "P", "E", "Z", "Y" };
        BigInteger Quotient = _Money, Remainder = BigInteger.Zero;
        int Sequence = 0;
        for(Sequence = 0; Sequence < 8; Sequence++)
        {
            if (-1 == BigInteger.Compare(Quotient, BigInteger.Parse("1000")))
            {
                break;
            }
            Quotient = BigInteger.DivRem(Quotient, BigInteger.Parse("1000"), out Remainder);
        }
        return Quotient.ToString()+Units[Sequence];
    }
}

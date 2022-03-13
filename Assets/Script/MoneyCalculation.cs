using System.Numerics;
using UnityEngine;

public class MoneyCalculation : MonoBehaviour
{
    static readonly string[] Units = {
        "", "K", "M", "G", "T", "P", "E", "Z", "Y" ,
        "KY", "MY", "GY", "TY", "PY", "EY", "ZY", "YY",
        "KYY", "MYY", "GYY", "TYY", "PYY", "EYY", "ZYY", "YYY",
        "KYYY", "MYYY", "GYYY", "TYYY", "PYYY", "EYYY", "ZYYY", "YYYY",
        "KYYYY", "MYYYY", "GYYYY", "TYYYY", "PYYYY", "EYYYY", "ZYYYY", "YYYYY",
        "KYYYYY", "MYYYYY", "GYYYYY", "TYYYYY", "PYYYYY", "EYYYYY", "ZYYYYY", "YYYYYY",
        "KYYYYYY", "MYYYYYY", "GYYYYYY", "TYYYYYY", "PYYYYYY", "EYYYYYY", "ZYYYYYY", "YYYYYYY",
        "KYYYYYYY", "MYYYYYYY", "GYYYYYYY", "TYYYYYYY", "PYYYYYYY", "EYYYYYYY", "ZYYYYYYY", "YYYYYYYY",
        "KYYYYYYYY", "MYYYYYYYY", "GYYYYYYYY", "TYYYYYYYY", "PYYYYYYYY", "EYYYYYYYY", "ZYYYYYYYY", "YYYYYYYYY",
        "KYYYYYYYYY", "MYYYYYYYYY", "GYYYYYYYYY", "TYYYYYYYYY", "PYYYYYYYYY", "EYYYYYYYYY", "ZYYYYYYYYY", "YYYYYYYYYY" };
    public static string Compress(BigInteger _Money)
    {
        BigInteger Quotient = _Money;
        int Sequence = 0;
        for(Sequence = 0; Sequence < Units.Length; Sequence++)
        {
            if (-1 == BigInteger.Compare(Quotient, BigInteger.Parse("1000")))
            {
                break;
            }
            Quotient = BigInteger.Divide(Quotient, BigInteger.Parse("1000"));
        }
        return Quotient.ToString()+Units[Sequence];
    }
}

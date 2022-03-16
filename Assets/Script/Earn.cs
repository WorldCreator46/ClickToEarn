using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Earn : MonoBehaviour
{
    public void TouchToEarn()
    {
        Property.Propertys["Money"] = BigInteger.Add(BigInteger.Parse(Property.Propertys["Money"]), BigInteger.Parse(Performance.Performances["EarnMoney"])).ToString();
    }
}

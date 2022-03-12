using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Earn : MonoBehaviour
{
    public void TouchToEarn()
    {
        Debug.Log(MoneyCalculation.Compress(BigInteger.Parse("17171")));
    }
    private void Update()
    {

    }
}

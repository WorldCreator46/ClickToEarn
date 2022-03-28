using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Earn : MonoBehaviour
{
    public void TouchToEarn()
    {
        Property.AddMoney(MoneyCalculation.EranMoney());
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Earn : MonoBehaviour
{
    public void TouchToEarn()
    {
        Debug.Log(Property.GetProperty());
        Property.SetPropert("");
        Debug.Log(Property.GetProperty());
    }
    private void Update()
    {

    }
}

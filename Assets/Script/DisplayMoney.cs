using System.Numerics;
using UnityEngine;

public class DisplayMoney : MonoBehaviour
{
    TextMesh tm;
    private void Start()
    { 
        tm = GetComponent<TextMesh>();
    }
    void Update()
    {
        tm.text = Property.GetMoney();
    }
}

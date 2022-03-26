using UnityEngine;
using System.Numerics;

public class MoneyAddText : MonoBehaviour
{
    private void Start()
    {
        TextMesh tm = GetComponent<TextMesh>();
        tm.text = MoneyCalculation.Compress(BigInteger.Parse(Performance.EranMoney()));
    }
}

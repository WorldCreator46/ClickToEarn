using UnityEngine;

public class Earn : MonoBehaviour
{
    public void TouchToEarn()
    {
        Property.AddMoney(MoneyCalculation.EranMoney());
    }
}

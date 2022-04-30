using UnityEngine;
using UnityEngine.UI;
public class Earn : MonoBehaviour
{
    public Button B;
    public void TouchToEarn()
    {
        if (B.interactable)
        {
            Property.AddMoney(MoneyCalculation.EranMoney());
            B.interactable = false;
            Invoke("Possibility", 0.08f);
        }
    }
    public void Possibility()
    {
        B.interactable = true;
    }
}

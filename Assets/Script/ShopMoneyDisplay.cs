using UnityEngine;
using UnityEngine.UI;

public class ShopMoneyDisplay : MonoBehaviour
{
    public Text t;
    private void Start()
    {
        SetMoney();
    }
    public void SetMoney()
    {
        t.text = Property.GetMoney();
    }
}

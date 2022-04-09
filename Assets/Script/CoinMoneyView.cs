using UnityEngine;
using UnityEngine.UI;

public class CoinMoneyView : MonoBehaviour
{
    public Text t;
    private void Start()
    {
        t.text = MoneyCalculation.GetEranMoney();
    }
}

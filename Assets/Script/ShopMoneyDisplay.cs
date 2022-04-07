using UnityEngine;
using UnityEngine.UI;

public class ShopMoneyDisplay : MonoBehaviour
{
    Text t;
    private void Start()
    {
        t = GetComponent<Text>();
    }
    void Update()
    {
        t.text = Property.GetMoney();
    }
}

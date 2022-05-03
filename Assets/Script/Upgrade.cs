using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    public Text[] ProductNames;
    public GameObject Panel;
    public Text PanelText;

    public void Purchase(Text BuyProductName)
    {
        BigInteger Price = BigInteger.Parse(MoneyCalculation.GetPrice(BuyProductName.text));
        if (Property.SubtractMoney(Price))
        {
            MoneyCalculation.Upgrade(BuyProductName.text);
            PanelCreate(true);
        }
        else
        {
            PanelCreate(false);
        }
    }
    public void PanelCreate(bool tf)
    {
        if (tf)
        {
            PanelText.text = "구매 성공!";
        }
        else
        {
            PanelText.text = "구매 실패";
        }
        Panel.SetActive(true);
        Invoke("PanelActiveOff", 0.5f);
    }
    public void PanelActiveOff()
    {
        Panel.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    public Text[] ProductNames;
    public Text[] Prices;
    public Dictionary<string, BigInteger> Menu;
    public GameObject Panel;
    public Text PanelText;

    private void Start()
    {
        SetPrices();
    }
    public void Purchase(Text BuyProductName)
    {
        BigInteger Price = BigInteger.Parse(MoneyCalculation.GetPrice(BuyProductName.text));
        if (Property.SubtractMoney(Price))
        {
            MoneyCalculation.Upgrade(BuyProductName.text);
            Property.SubtractMoney(Price);
            PanelCreate(true);
        }
        else
        {
            PanelCreate(false);
        }
        SetPrices();
    }
    public void PanelCreate(bool tf)
    {
        if (tf)
        {
            PanelText.text = "���� ����!";
        }
        else
        {
            PanelText.text = "���� ����";
        }
        Panel.SetActive(true);
        Invoke("PanelActiveOff", 0.5f);
    }
    public void PanelActiveOff()
    {
        Panel.SetActive(false);
    }
    public void SetPrices()
    {
        Menu = MoneyCalculation.GetPriceMenu();
        for (int i = 0; i < ProductNames.Length; i++)
        {
            Prices[i].text = "���� : " + MoneyCalculation.Convert(Menu[ProductNames[i].text].ToString());
        }
    }
}

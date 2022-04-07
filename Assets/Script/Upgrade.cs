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
    public Text BuyProductName;

    private void Start()
    {
        SetPrices();
    }
    public void Purchase()
    {
        BigInteger Price = BigInteger.Parse(MoneyCalculation.GetPrice(BuyProductName.text));
        if (Property.SubtractMoney(Price))
        {
            Property.SubtractMoney(Price);
            MoneyCalculation.Upgrade(BuyProductName.text);
        }
        else
        {

        }
        SetPrices();
    }
    public void SetPrices()
    {
        Menu = MoneyCalculation.GetPriceMenu();
        for (int i = 0; i < ProductNames.Length; i++)
        {
            Prices[i].text = "АЁАн : " + MoneyCalculation.Convert(Menu[ProductNames[i].text].ToString());
        }
    }
}

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

    public void Purchase()
    {
        BigInteger Price = BigInteger.Parse(MoneyCalculation.GetPrice(BuyProductName.text));
        if (Property.SubtractMoney(Price))
        {
            Debug.Log("���� ����");
        }
        else
        {
            Debug.Log("���� �Ұ�");
        }
        SetPrices();
    }
    private void Start()
    {
        SetPrices();
    }
    public void SetPrices()
    {
        SetPriceMenu();
        for(int i = 0; i < ProductNames.Length; i++)
        {
            Prices[i].text = "���� : " + MoneyCalculation.Convert(Menu[ProductNames[i].text].ToString());
        }
    }
    public void SetPriceMenu()
    {
        Menu = MoneyCalculation.GetPriceMenu();
    }
}

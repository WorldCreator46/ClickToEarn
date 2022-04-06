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
    public GameObject SuccessPanelPrefab;
    public GameObject FailurePanelPrefab;

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
        UnityEngine.Vector3 pos = new UnityEngine.Vector3(0, 0, 0);
        if (tf)
        {
            GameObject temp = Instantiate(SuccessPanelPrefab);
            temp.transform.position = pos;
            Destroy(temp, 0.35f);
        }
        else
        {
            GameObject temp = Instantiate(FailurePanelPrefab);
            temp.transform.position = pos;
            Destroy(temp, 0.35f);
        }
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
